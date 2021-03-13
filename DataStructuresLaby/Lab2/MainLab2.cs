using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLaby
{
    class MainLab2
    {
        public static void Start()
        {
            int[] array = new int[] { 5,6,7,8,234 };

            var tree = new BinaryTree<int>();
            foreach (var e in array)
                tree.Add(e);

            foreach (var e in array)
                Console.WriteLine(tree.Contains(e));



            foreach (var e in array)
            {
                tree.Remove(e);
                Console.WriteLine(tree.Contains(e));
            }
        }
    }
}
