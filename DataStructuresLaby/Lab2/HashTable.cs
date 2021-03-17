using System;
using System.Linq;
using System.Collections.Generic;

namespace DataStructuresLaby.Lab2
{
    public class HashTable<TKey, TValue>
    {
        public struct KeyValue<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        public readonly int Size;
        private readonly LinkedList<KeyValue<TKey, TValue>>[] items;

        public HashTable(int size)
        {
            this.Size = size;
            items = new LinkedList<KeyValue<TKey, TValue>>[size];
        }

        protected int GetArrayPosition(TKey key)
        {
            int position = key.GetHashCode() % Size;
            return Math.Abs(position);
        }

        public TValue Find(TKey key)
        {
            var position = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);

            return linkedList.FirstOrDefault(x => x.Key.Equals(key)).Value;
        }

        public void Add(TKey key, TValue value)
        {
            var position = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);
            var item = new KeyValue<TKey, TValue>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        public void Remove(TKey key)
        {
            var position   = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);
            var itemFound  = false;
            var foundItem  = default(KeyValue<TKey, TValue>);

            foreach (var item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }

            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        protected LinkedList<KeyValue<TKey, TValue>> GetLinkedList(int position)
        {
            var linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<TKey, TValue>>();
                items[position] = linkedList;
            }

            return linkedList;
        }
    }
}
