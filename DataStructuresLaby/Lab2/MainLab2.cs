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
            var array = new int[] { 1, 3, 4, 6, 7, 7, 9, 10,10, 12, 12, 12, 12, 12 };

            var fib = new FibonacciSearch();
            Console.WriteLine(fib.Search(array, 7));
        }
    }
}
