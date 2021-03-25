using System;

namespace DataStructuresLaby.Lab2.Hashtable
{
    class RandomHashtable<TKey, TValue> : SimpleHashtable<TKey, TValue>
    {
        /* Рехэширование с помощью псевдослучайных чисел */

        public RandomHashtable(int size) : base(size) { }

        protected override int GetArrayPosition(TKey key)
        {
            int x = key.GetHashCode();
            int position = (x + GetRandomHash(x)) % Size;
            return Math.Abs(position);
        }

        private int GetRandomHash(int x) 
            => (625 * x + 6571) % 31104;
    }
}