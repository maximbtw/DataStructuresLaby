using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresLaby.Lab4
{
    class Stack<TValue> : IEnumerable<TValue> 
    {
        class Node
        {
            public TValue Value;
            public Node Next;
        }

        private Node head;
        private int capacity;
        public int Lenght { get; private set; } = 0;

        public Stack()
        {
            this.capacity = -1;
        }

        public Stack(int capacity)
        {
            this.capacity = capacity;
        }

        public void Push(TValue value)
        {
            if (capacity > 0 && Lenght == capacity)
            {
                throw new Exception("Stack filled up");
            }

            Node node = new Node { Value = value };

            if (head == null)
            {
                head = node;
            }
            else
            {
                node.Next = head;
                head = node;
            }

            Lenght++;
        }

        public TValue Peek()
        {
            if(head == null)
            {
                throw new NullReferenceException();
            }

            return head.Value;
        }

        public TValue Pop()
        {
            if (head == null)
            {
                throw new NullReferenceException();
            }

            TValue value = head.Value;
            head = head.Next;
            Lenght--;

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