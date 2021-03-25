using System;

namespace DataStructuresLaby.Lab2
{
    public class BinaryTree<TValue> where TValue : IComparable<TValue>
    {
        class Node
        {
            public TValue Value;
            public Node Left, Right;
        }

        private Node root;

        public void Add(TValue value)
        {
            if (root == null)
            {
                root = new Node { Value = value };
                return;
            }
            Add(root, value);
        }

        private void Add(Node currentNode, TValue value)
        {
            if (value.CompareTo(currentNode.Value) < 0)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = new Node() { Value = value };
                }
                else if (currentNode.Left != null) Add(currentNode.Left, value);
            }
            else
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = new Node { Value = value };
                }
                else if (currentNode.Right != null) Add(currentNode.Right, value);
            }
        }

        public TValue Find(TValue data)
        {
            Node current = root;

            while (current != null)
            {
                var result = current.Value.CompareTo(data);
                if (result == 0) return current.Value;
                current = (result > 0)
                        ? current.Left
                        : current.Right;
            }

            return default;
        }

        public bool Contains(TValue data)
        {
            Node current = root;

            while (current != null)
            {
                var result = current.Value.CompareTo(data);
                if (result == 0) return true;
                current = (result > 0) 
                    ? current.Left 
                    : current.Right;
            }

            return false;  
        }
        public void Write() => Write(root);

        private void Write(Node current)
        {
            if (current == null) return;
            Write(current.Left);
            Console.WriteLine(current.Value.ToString());
            Write(current.Right);
        }

        public bool Remove(TValue data)
        {
            if (root == null) return false;      

            Node current = root, parent = null;

            int result = current.Value.CompareTo(data);
            while (result != 0)
            {
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                if (current == null)
                    return false;
                else
                    result = current.Value.CompareTo(data);
            }
            if (current.Right == null)
            {
                if (parent == null)
                    root = current.Left;
                else
                {
                    result = parent.Value.CompareTo(current.Value);
                    if (result > 0)

                        parent.Left = current.Left;
                    else if (result < 0)
 
                        parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                    root = current.Right;
                else
                {
                    result = parent.Value.CompareTo(current.Value);
                    if (result > 0)
                        parent.Left = current.Right;
                    else if (result < 0)
                        
                        parent.Right = current.Right;
                }
            }
            else
            {
                Node leftmost = current.Right.Left, lmParent = current.Right;
                while (leftmost.Left != null)
                {
                    lmParent = leftmost;
                    leftmost = leftmost.Left;
                }
                lmParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                    root = leftmost;
                else
                {
                    result = parent.Value.CompareTo(current.Value);
                    if (result > 0)
                        parent.Left = leftmost;
                    else if (result < 0)
                        parent.Right = leftmost;
                }
            }

            return true;
        }
    }
}