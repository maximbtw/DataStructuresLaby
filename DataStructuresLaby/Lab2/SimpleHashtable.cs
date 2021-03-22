using System;

namespace DataStructuresLaby.Lab2
{
    class SimpleHashtable<TKey, TValue>
    {
        /* Простое рехеширование */

        public struct KeyValue<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        public readonly int Size;
        private KeyValue<TKey, TValue>[] items;

        public SimpleHashtable(int size)
        {
            this.Size = size;
            items = new KeyValue<TKey, TValue>[size];
        }

        protected int GetArrayPosition(TKey key)
        {
            int position = key.GetHashCode() % Size;
            return Math.Abs(position);
        }

        public TValue Find(TKey key)
        {
            var position = GetArrayPosition(key);

            return items[position].Value;
        }

        public void Add(TKey key, TValue value)
        {
            var position = GetArrayPosition(key);
            items[position] = new KeyValue<TKey, TValue>() { Key = key, Value = value };
        }

        public void Remove(TKey key)
        {
            var position = GetArrayPosition(key);

            items[position] = default(KeyValue<TKey, TValue>);
        }
    }
}
