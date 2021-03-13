using System;

namespace DataStructuresLaby
{
    public class BinaryTree<TValue> where TValue : IComparable<TValue>
    {
        class Node
        {
            public TValue Value;
            public Node Left, Right;
        }

        Node head;

        public void Add(TValue value)
        {
            if (head == null)
            {
                head = new Node { Value = value };
                return;
            }
            Add(head, value);
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

        public TValue Find(TValue value)
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return currentNode.Value;
                }
                currentNode =
                    currentNode.Value.CompareTo(value) < 0
                        ? currentNode.Left
                        : currentNode.Right;
            }

            throw new Exception("Not Found");
        }

        public bool Contains(TValue value)
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                if (value.CompareTo(currentNode.Value) == 0)
                {
                    return true;
                }
                currentNode =
                    value.CompareTo(currentNode.Value) < 0
                        ? currentNode.Left
                        : currentNode.Right;
            }

            return false;
        }

        public void Delete(TValue value)
        {
            Delete(head, value);
        }

        private Node Delete(Node root, TValue value)
        {
            if (root == null)
            {
                return root;
            }
            if (root.Value.CompareTo(value) > 0)
                root.Left = Delete(root.Left, value);
            else if (root.Value.CompareTo(value) < 0)
                root.Right = Delete(root.Right, value);
            else if (root.Left != null && root.Right != null)
            {
                root.Right = Delete(root.Right, root.Value);
            }
            else
            {
                if (root.Left != null)
                    root = root.Left;
                else if (root.Right != null)
                    root = root.Right;
                else
                    root = null;
            }
            return root;
        }
    }
}