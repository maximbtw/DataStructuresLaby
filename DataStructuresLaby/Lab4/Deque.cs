using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLaby.Lab4
{
    class Deque<TValue> : IEnumerable<TValue>
    {
        class Node
        {
            public TValue Value;
            public Node Next, Prev;
        }

        private Node head;
        private Node tail;

        public int Length { get; private set; } = 0;

        public TValue First
        {
            get
            {
                if (Length == 0)
                {
                    throw new NullReferenceException();
                }

                return head.Value;
            }
        }

        public TValue Last
        {
            get
            {
                if (Length == 0)
                {
                    throw new NullReferenceException();
                }

                return tail.Value;
            }
        }

        public void AddFirst(TValue value)
        {
            Node node = new Node() { Value = value };

            if (Length == 0)
            {
                head = tail = node;
            }
            else if (Length == 1)
            {
                head = node;
                head.Next = tail;
                tail.Prev = head;
            }
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }

            Length++;
        }

        public void AddLast(TValue value)
        {
            Node node = new Node() { Value = value };

            if (Length == 0)
            {
                head = tail = node;
            }
            else if (Length == 1)
            {
                tail = node;
                tail.Prev = head;
                head.Next = tail;
            }
            else
            {
                node.Prev = tail;
                tail.Next = node;
                tail = node;
            }

            Length++;
        }

        public TValue RemoveFirst()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }

            TValue value = head.Value;

            head = head.Next;
            if(Length == 1)
            {
                tail = head;
            }
            Length--;

            return value;
        }

        public TValue RemoveLast()
        {
            if (Length == 0)
            {
                throw new NullReferenceException();
            }

            TValue value = tail.Value;

            tail = tail.Prev;
            if (Length == 1)
            {
                head = tail;
            }
            Length--;

            return value;
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            Node node = head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}