namespace NHapi.NUnit.Util
{
    using System;

    using global::NUnit.Framework;

    using NHapi.Base.Model;
    using NHapi.Base.Util;
    using NHapi.Model.V24.Message;

    [TestFixture]
    public class MessageIteratorTests
    {
        /**
         * Test cases include:
         * - false if doesn't contain
         * - true if contains as first child
         * - true if contains as first grandchild
         * - false if contains as child after 1st required child if this flag is set
         */
        [TestCase("BOO", false, false, false)]
        [TestCase("MSH", true, true, true)]
        [TestCase("IN1", false, false, true)]
        [TestCase("IN2", false, true, false)]
        [TestCase("IN2", false, false, true)]
        public void Contains_ValidInput_ReturnsExpectedResult(
            string name, bool firstDescendentOnly, bool upToFirstRequired, bool expectedResult)
        {
            // Arrange
            var message = new ADT_A01();

            // Act
            var actual =
                MessageIterator.Contains(message, name, firstDescendentOnly, upToFirstRequired);

            // Assert
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Contains_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var message = new ADT_A01();

            // Act
            var actual =
                MessageIterator.contains(message.GetINSURANCE(), "IN1", true, true);

            // Assert
            Assert.That(actual, Is.EqualTo(true));
        }

        [Test]
        public void GetIndex_ValidInputAndChildExists_ReturnsExpectedResults()
        {
            // Arrange
            var message = new ADT_A01();
            var expected = new MessageIterator.Index("DB1", 0);

            // Act
            var actual =
                MessageIterator.GetIndex(message, message.GetDB1(0));

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetIndex_ValidInputAndChildDoesNotExists_ReturnsExpectedResults()
        {
            // Arrange
            var message = new ADT_A01();

            // Act
            var actual =
                MessageIterator.GetIndex(message, message.GetPROCEDURE().GetROL());

            // Assert
            Assert.That(actual, Is.EqualTo(null));
        }

        [Test]
        public void IsLast_WhenPositionIsLast_ReturnsTrue()
        {
            // Arrange
            var message = new ADT_A01();
            var position = new MessageIterator.Position(message, "PDA", 0);

            // Act / Assert
            Assert.That(MessageIterator.isLast(position), Is.True);
        }

        [Test]
        public void IsLast_WhenPositionIsNotLast_ReturnsFalse()
        {
            // Arrange
            var message = new ADT_A01();
            var position = new MessageIterator.Position(message, "ACC", 0);

            // Act / Assert
            Assert.That(MessageIterator.isLast(position), Is.False);
        }

        /**
         * Test cases include:
         * - false if not there at all
         * - false if earlier in message
         * - true if in current repeating group
         * - true if in later sibling of parent
         * Wish list:
         * - true if in repeating grandparent
         * - false if earlier in current non-repeating group
         */
        [TestCase("FOO", false, true, false)]
        [TestCase("MSH", false, false, false)]
        [TestCase("IN1", true, true, true)]
        [TestCase("IN2", false, false, true)]
        [TestCase("IN2", true, true, false)]
        [TestCase("ACC", true, true, true)]
        public void MatchExistsAfterPosition_ValidInput_ReturnsExpectedResult(
            string name, bool firstDescendentOnly, bool upToFirstRequired, bool expectedResult)
        {
            // Arrange
            var message = new ADT_A01();
            var position = new MessageIterator.Position(message.GetINSURANCE(), "IN2", 0);

            // Act
            var actual =
                MessageIterator.MatchExistsAfterPosition(position, name, firstDescendentOnly, upToFirstRequired);

            // Assert
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [Test]
        public void MoveNext_AtEndOfMessage_ReturnsFalse()
        {
            // Arrange
            var message = new ADT_A01();
            var sut = new MessageIterator(message.PDA, "PDA", false);

            // Act / Assert
            Assert.That(sut.MoveNext(), Is.False);
        }

        [Test]
        public void MoveNext_NotAtEndOfMessage_ReturnsTrue()
        {
            // Arrange
            var message = new ADT_A01();
            var sut = new MessageIterator(message.UB2, "PDA", false);

            // Act / Assert
            Assert.That(sut.MoveNext(), Is.True);
        }

        /**
         * Test cases include:
         * - to next rep if direction matches current repeating segment
         * - from one sibling to the next if direction doesn't match current repeating segment
         * - from group to 1st child
         * - from end of group to next rep of group if group contains direction as first child
         * - from end of group to next sibling if group doesn't contain direction
         * - from end of group to next sibling if group contains direction after another required child
         * - fail if at end of message
         * - new segment if there are no matching structures
         */
        [Test]
        public void TestCurrent()
        {
            var message = new ADT_A01();
            var sut = new MessageIterator(message.GetROL(), "ROL", false);
            Assert.That(sut.Current, Is.EqualTo(message.GetROL(1)), "next rep if dir matches repeating segment");
            sut.Direction = "PDA";

            Assert.That(sut.Current, Is.EqualTo(message.GetNK1()), "next sibling if dir doesn't match repeating segment");
            Console.WriteLine(sut.Current);

            sut.Direction = "PV1";
            Assert.That(sut.Current, Is.EqualTo(message.PV2), "next sibling if dir matches non-repeating segment");

            sut = new MessageIterator(message.GetPROCEDURE(), "PDA", false);
            Assert.That(sut.Current, Is.EqualTo(message.GetPROCEDURE().PR1), "group to child");
            sut.Direction = "PR1";

            Console.WriteLine(sut.Current);

            Assert.That(sut.Current, Is.EqualTo(message.GetPROCEDURE(1)), "next rep of group if 1st child matches dir");

            sut = new MessageIterator(message.GetPROCEDURE().GetROL(), "PDA", false);
            Assert.That(sut.Current, Is.EqualTo(message.GetGT1()), "next sibling of parent if group doesn't contain direction");

            sut = new MessageIterator(message.GetINSURANCE().GetROL(), "IN3", false);
            Assert.That(sut.Current, Is.EqualTo(message.ACC), "next sib of parent if contains dir after required child");

            sut = new MessageIterator(message.PDA, "FOO", false);
            try
            {
                var unused = sut.Current;
                Assert.Fail("should have thrown no such element exception on attempt to iterate past end of message");
            }
            catch (ArgumentOutOfRangeException)
            {
                /* OK */
            }

            sut = new MessageIterator(message.PDA, "FOO", true);
            var segment = (ISegment)sut.Current;
            Assert.That(segment.GetStructureName(), Is.EqualTo("FOO"));

            sut = new MessageIterator(message.GetINSURANCE().GetROL(), "BAR", true);
            segment = (ISegment)sut.Current;
            Assert.Multiple(() =>
            {
                Assert.That(segment.GetStructureName(), Is.EqualTo("BAR"));
                Assert.That(message.GetINSURANCE().Names.Length, Is.EqualTo(5), "BAR added as a child of IN1 group");
            });
        }
    }
}
