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

        protected int GetArrayPosition(TKey key)
        {
            int position = (key.GetHashCode() + GetRandomHash(1)) % Size;
            return Math.Abs(position);
        }

        private int GetRandomHash(int x)
        {
            return (625 * x + 6571) % 31104;
        }


        public override TValue Find(TKey key)
        {
            var position = GetArrayPosition(key);
            return items[position].Value;
        }

        public override void Add(TKey key, TValue value)
        {
            var position = GetArrayPosition(key);
            items[position] = new KeyValue<TKey, TValue>() { Key = key, Value = value };
        }

        public override void Remove(TKey key)
        {
            var position = GetArrayPosition(key);
            items[position] = default(KeyValue<TKey, TValue>);
        }
    }
}