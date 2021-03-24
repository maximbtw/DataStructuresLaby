using System;

namespace DataStructuresLaby.Lab2.Lab2.Hashtable
{
    class RandomHashtable<TKey, TValue> : Hashtable<TKey, TValue>
    {
        /* Рехэширование с помощью псевдослучайных чисел */

        private readonly int a = 625;
        private readonly int c = 6571;
        private readonly int m = 31104;

        private KeyValue<TKey, TValue>[] items;

        public RandomHashtable(int size) : base(size)
        {
            items = new KeyValue<TKey, TValue>[size];
        }

        protected int GetArrayPosition(TKey key, bool take = true)
        {
            int x = key.GetHashCode();
            int position = GetHash(x) % Size;
            while (!items[position].Equals(default(KeyValue<TKey, TValue>)) && !take)
            {
                x = GetHash(x);
                position = GetHash(x);
            }

            return Math.Abs(position);
        }

        public override TValue Find(TKey key)
        {
            var position = GetArrayPosition(key);
            return items[position].Value;
        }

        public override void Add(TKey key, TValue value)
        {
            var position = GetArrayPosition(key, false);
            items[position] = new KeyValue<TKey, TValue>() { Key = key, Value = value };
        }

        public override void Remove(TKey key)
        {
            var position = GetArrayPosition(key);
            items[position] = default(KeyValue<TKey, TValue>);
        }

        private int GetHash(int x) => (a * x + c) % Size;
    }
}