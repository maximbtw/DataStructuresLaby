using System;

namespace DataStructuresLaby.Lab2.Hashtable
{
    class SimpleHashtable<TKey, TValue> : Hashtable<TKey, TValue>
    {
        /* Простое рехеширование */

        private KeyValue<TKey, TValue>[] items;

        public SimpleHashtable(int size) : base(size)
        {
            items = new KeyValue<TKey, TValue>[size];
        }

        protected int GetArrayPosition(TKey key)
        {
            int position = key.GetHashCode() % Size;
            return Math.Abs(position);
        }

        public override TValue Find(TKey key)
        {
            var position = GetArrayPosition(key);
            return items[position].Value;
        }

        public override void Add(TKey key, TValue value)
        {
            var position = GetArrayPosition(key);
            if (items[position].Equals(default(KeyValue<TKey, TValue>)))
            {
                throw new Exception("Ключ должен быть уникальный");
            }
            items[position] = new KeyValue<TKey, TValue>() { Key = key, Value = value };
        }

        public override void Remove(TKey key)
        {
            var position = GetArrayPosition(key);
            items[position] = default(KeyValue<TKey, TValue>);
        }
    }
}
