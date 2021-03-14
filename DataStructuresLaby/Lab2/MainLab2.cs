using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLaby
{
    class MainLab2
    {
        public static void Start()
        {
            var rnd  = new Random();
            var tree = new BinaryTree<int>();
            var list = new List<int>();

            for (int i = 0; i < 15; i++)
            {
                int item = rnd.Next(-100, 100);
                list.Add(item);
                tree.Add(item);
            }
            tree.Write();
            Console.WriteLine("-----------");
            for (int i = 0; i < list.Count; i += 3)
            {
                Console.Write(list[i] + " ");
                tree.Remove(list[i]);
            }
            Console.WriteLine();
            Console.WriteLine("-----------");
            tree.Write();
        }
    }
}
