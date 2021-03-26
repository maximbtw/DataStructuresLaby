using System;

namespace DataStructuresLaby.Lab2.Hashtable
{
    class SimpleHashtable<TKey, TValue> : Hashtable<TKey, TValue>
    {
        /* Простое рехеширование */

        protected KeyValue<TKey, TValue>[] items;

        public SimpleHashtable(int size) : base(size)
        {
            items = new KeyValue<TKey, TValue>[size];
        }

        protected virtual int GetArrayPosition(TKey key, bool add = false)
        {
            int position = key.GetHashCode() % Size;
            if (!items[position].Key.Equals(key) && !add)
            {
                bool isFind = false;
                for (int i = position; i < Size; i++)
                {
                    if (items[i].Key.Equals(key))
                    {
                        isFind = true;
                        position = i;
                        break;
                    }
                }
                if (!isFind)
                {
                    return -1;
                }
            }

            return Math.Abs(position);
        }

        public override TValue Find(TKey key)
        {
            var position = GetArrayPosition(key);
            if (position == -1) return default(TValue);
            return items[position].Value;
        }

        public override void Add(TKey key, TValue value)
        {
            var position = GetArrayPosition(key, true);
            if (position == -1) return;
            items[position] = new KeyValue<TKey, TValue>() { Key = key, Value = value };
        }


        public override void Remove(TKey key)
        { 
            var position = GetArrayPosition(key);
            if (position == -1) return;
            items[position] = default(KeyValue<TKey, TValue>);
        }
    }
}
