﻿using System;

namespace DataStructuresLaby.Lab2.Hashtable
{
    class RandomHashtable<TKey, TValue> : SimpleHashtable<TKey, TValue>
    {
        /* Рехэширование с помощью псевдослучайных чисел */

        public RandomHashtable(int size) : base(size) { }

        protected override int GetArrayPosition(TKey key, bool add = false)
        {
            int x = key.GetHashCode();
            int position = GetRandomHash(x);
            int startHash = position;

            while (!items[position].Key.Equals(default(TKey)))
            {
                if (startHash == position) return position; //таблица заполнена
                position = GetRandomHash(position);
            }

            return Math.Abs(position);
        }

        private int GetRandomHash(int x) 
            => (x + ((625 * x + 6571) % 31104)) % Size;    
    }
}