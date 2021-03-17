using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataStructuresLaby.Lab2
{
    class MainLab2
    {
        public static void Start()
        {
            var hashTable = new HashTable<string, string>(20);

            hashTable.Add("Hello", "Max");
            hashTable.Add("GoodBye", "Max");
            hashTable.Add("Hello", "Artem");
            hashTable.Add("THX", "Slavy");

            Console.WriteLine(hashTable.Find("Hello"));
            hashTable.Remove("Hello");
            Console.WriteLine(hashTable.Find("Hello"));
        }
    }
}
