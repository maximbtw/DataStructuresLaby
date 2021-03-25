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
            int position = GetRandomHash(x);
            int startHash = position;
            int counter = 0;

            while (!items[position].Key.Equals(default(TKey)))
            {
                if (startHash == position) break;//Таблица заполнена
                position = GetRandomHash(position);
                counter++;
            }

            return Math.Abs(position);
        }

        private int GetRandomHash(int x) 
            => x + ((625 * x + 6571) % 31104) % Size;
    }
}