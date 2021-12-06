#if NET35

namespace NHapi.Base.Util
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;

    internal class SynchronizedCache<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();
        private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();

        ~SynchronizedCache()
        {
            readerWriterLock?.Dispose();
        }

        public int Count
        {
            get => GetCount();
        }

        public TValue this[TKey index]
        {
            get => Read(index);
            set => AddOrUpdate(index, value);
        }

        public void Add(TKey key, TValue value)
        {
            readerWriterLock.EnterWriteLock();
            try
            {
                dictionary.Add(key, value);
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            readerWriterLock.EnterReadLock();
            try
            {
                return dictionary.TryGetValue(key, out value);
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
        }

        public bool ContainsKey(TKey key)
        {
            readerWriterLock.EnterReadLock();
            try
            {
                return dictionary.ContainsKey(key);
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            readerWriterLock.EnterReadLock();
            try
            {
                foreach (var entry in dictionary)
                {
                    yield return entry;
                }
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public bool TryAdd(TKey key, TValue value)
        {
            readerWriterLock.EnterUpgradeableReadLock();
            try
            {
                if (dictionary.TryGetValue(key, out _))
                {
                    return false;
                }
                else
                {
                    readerWriterLock.EnterWriteLock();
                    try
                    {
                        dictionary.Add(key, value);
                    }
                    finally
                    {
                        readerWriterLock.ExitWriteLock();
                    }

                    return true;
                }
            }
            finally
            {
                readerWriterLock.ExitUpgradeableReadLock();
            }
        }

        private TValue Read(TKey key)
        {
            readerWriterLock.EnterReadLock();
            try
            {
                return dictionary[key];
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
        }

        private void AddOrUpdate(TKey key, TValue value)
        {
            readerWriterLock.EnterWriteLock();
            try
            {
                dictionary[key] = value;
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }

        private int GetCount()
        {
            readerWriterLock.EnterReadLock();
            try
            {
                return dictionary.Count;
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
        }
    }
}
#endif