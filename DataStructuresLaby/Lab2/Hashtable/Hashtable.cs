namespace DataStructuresLaby.Lab2.Hashtable
{
    abstract public class Hashtable<TKey, TValue>
    {
        public struct KeyValue<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        public readonly int Size;

        public Hashtable(int size)
        {
            Size = size;
        }

        abstract public TValue Find(TKey key);

        abstract public void Add(TKey key, TValue value);

        abstract public void Remove(TKey key);
    }
}
