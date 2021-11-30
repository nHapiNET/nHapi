#if NETFRAMEWORK
namespace NHapi.Base.NUnit.Util
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using global::NUnit.Framework;

    using NHapi.Base.Util;

    [TestFixture]
    public class SynchronizedCacheTests
    {
        [Test]
        public void Indexer_Get_ExistsInCache_ReturnsValue()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string> { { "key", "value" } };

            // Act
            var result = sut["key"];

            // Assert
            Assert.AreEqual("value", result);
        }

        [Test]
        public void Indexer_Get_DoesNotExistsInCache_ThrowsKeyNotFoundException()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();

            // Act / Assert
            Assert.Throws<KeyNotFoundException>(() =>
            {
                var unused = sut["key"];
            });
        }

        [Test]
        public void Indexer_Add_DoesNotExistsInCache_AddsValue()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string> { { "key", "value" } };

            // Act
            sut["key"] = "new value";

            // Assert
            Assert.AreEqual("new value", sut["key"]);
        }

        [Test]
        public void Indexer_Add_DoesExistsInCache_ReplacesValue()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();

            // Act
            sut["key"] = "value";

            // Assert
            Assert.AreEqual("value", sut["key"]);
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(11)]
        [TestCase(110)]
        public void Count_ReturnsNumberOfItemsInCache(int numberOfItemsToAdd)
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();

            // Act
            for (var i = 0; i < numberOfItemsToAdd; i++)
            {
                sut.Add($"{i}", "value");
            }

            // Assert
            Assert.AreEqual(numberOfItemsToAdd, sut.Count);
        }

        [Test]
        public void Add_WhenItemExistsInCache_ThrowsArgumentException()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string> { { "key", "value" } };

            // Act / Assert
            var exception = Assert.Throws<ArgumentException>(() => sut.Add("key", "value"));
            Assert.AreEqual("An item with the same key has already been added.", exception?.Message);
        }

        [Test]
        public void TryAdd_WhenItemExistsInCache_DuplicateItemNotAdded()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();
            sut.TryAdd("key", "value");

            // Act
            sut.TryAdd("key", "value");

            // Assert
            Assert.AreEqual(1, sut.Count);
        }

        [Test]
        [Repeat(100)]
        public void TryAdd_WhenItemExistsInCache_DuplicateItemNotAdded_Concurrent()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();

            Parallel.For(0, 100, _ => sut.TryAdd("key", "value"));

            // Assert
            Assert.AreEqual(1, sut.Count);
        }

        [Test]
        public void TryGetValue_WhenItemExists_ReturnsTrueAndValue()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string> { { "key", "value" } };

            // Act
            var exists = sut.TryGetValue("key", out var result);

            // Assert
            Assert.True(exists);
            Assert.AreEqual("value", result);
        }

        [Test]
        public void TryGetValue_WhenItemDoesNotExists_ReturnsFalseAndDefaultValue()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();

            // Act
            var exists = sut.TryGetValue("key", out var result);

            // Assert
            Assert.False(exists);
            Assert.AreEqual(default(string), result);
        }

        [Test]
        public void ContainsKey_WhenKeyExists_ReturnsTrue()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string> { { "key", "value" } };

            // Act
            var exists = sut.ContainsKey("key");

            // Assert
            Assert.True(exists);
        }

        [Test]
        public void ContainsKey_WhenKeyDoesExists_ReturnsFalse()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();

            // Act
            var exists = sut.ContainsKey("key");

            // Assert
            Assert.False(exists);
        }

        [Test]
        public void Enumeration_AttemptToWriteWhileEnumerating_ThrowsLockRecursionException()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();
            for (var i = 0; i < 100; i++)
            {
                sut.TryAdd($"{i}", "value");
            }

            // Act
            Assert.Throws<LockRecursionException>(() =>
            {
                foreach (var unused in sut)
                {
                    sut.TryAdd("101", "value");
                }
            });
        }

        [Test]
        public void Enumeration_AttemptToReadWhileEnumerating_ThrowsLockRecursionException()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();
            for (var i = 0; i < 100; i++)
            {
                sut.TryAdd($"{i}", "value");
            }

            // Act
            Assert.Throws<LockRecursionException>(() =>
            {
                foreach (var unused in sut)
                {
                    var dummy = sut["1"];
                }
            });
        }

        [Test]
        [Repeat(1000)]
        public async Task ReadingAndWritingToCache_WhilstNoEnumerations_OnMultipleThreads_DoesNotThrowAnException()
        {
            // Arrange
            var sut = new SynchronizedCache<string, string>();
            var tasks = new List<Task>();

            for (var i = 0; i < 100; i++)
            {
                var i1 = i;
                tasks.Add(Task.Run(() => sut.TryAdd($"{i1}", "value")));
                tasks.Add(Task.Run(() => sut.TryGetValue($"{i1}", out _)));
                tasks.Add(Task.Run(() => sut.ContainsKey($"{i1}")));
                tasks.Add(Task.Run(() => sut[$"{i1}"] = "value"));
            }

            // Act
            await Task.WhenAll(tasks);
        }
    }
}
#endif