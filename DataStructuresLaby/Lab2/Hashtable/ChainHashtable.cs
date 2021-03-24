using System;
using System.Linq;
using System.Collections.Generic;

namespace DataStructuresLaby.Lab2.Hashtable
{
    public class ChainHashtable<TKey, TValue> : Hashtable<TKey, TValue>
    {
        /* Метод цепочек */

        private readonly LinkedList<KeyValue<TKey, TValue>>[] items;

        public ChainHashtable(int size) : base(size)
        {
            items = new LinkedList<KeyValue<TKey, TValue>>[size];
        }

        protected int GetArrayPosition(TKey key)
        {
            int position = key.GetHashCode() % Size;
            return Math.Abs(position);
        }

        public override TValue Find(TKey key)
        {
            var position = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);

            return linkedList.FirstOrDefault(x => x.Key.Equals(key)).Value;
        }

        public override void Add(TKey key, TValue value)
        {
            var position = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);
            var item = new KeyValue<TKey, TValue>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        public override void Remove(TKey key)
        {
            var position   = GetArrayPosition(key);
            var linkedList = GetLinkedList(position);

            var foundItem  = default(KeyValue<TKey, TValue>);
            var itemFound  = false;


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

        /*Возвращает сущесвующую цепочку или создаёт новую*/
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
