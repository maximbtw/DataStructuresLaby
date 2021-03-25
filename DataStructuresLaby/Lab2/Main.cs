using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;
using DataStructuresLaby.Lab2.Hashtable;
using DataStructuresLaby.Lab2.Search;

namespace DataStructuresLaby.Lab2
{
    class Main
    {
        private static readonly int size = 50000;

        public static void Start()
        {
            var array = new int[size];
            var tree = new BinaryTree<int>();
            var hashtables = new Hashtable<int,int>[]
            {
                new SimpleHashtable<int,int>(size),
                new RandomHashtable<int,int>(size),
                new ChainHashtable<int,int>(size),
            };

            FillCollections(array, tree, hashtables);

            var findItem = array[38256];
            Console.WriteLine($"Ищем элемент: {findItem}");



            GetTime("Встроенный поиск", Array.FindIndex, array.ToArray(), (Predicate<int>)((item) => item == findItem));
            GetTime("Бинарный поиск",             BinarySearch<int>.Search,     array.ToArray(), findItem);
            GetTime("Фибоначчиев поиск",      new FibonacciSearch().Search,     array.ToArray(), findItem);
            GetTime("Интерполяционный поиск", new InterpolationSearch().Search, array.ToArray(), findItem);
            Console.WriteLine("\nКонец");
        }

        public static void FillCollections(int[] array, BinaryTree<int> tree, Hashtable<int, int>[] hashtables)
        {
            var rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                int element = rnd.Next(0, 10000);
                array[i] = element;
                tree.Add(element);
                foreach (var hashtable in hashtables)
                    hashtable.Add(element, element);
            }
        }

        public static void GetTime<T>(string nameFunc, Func<int[], T, int> func, int[] array, T element)
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            Array.Sort(array);
            var index = func(array, element);
            timer.Stop();

            Console.WriteLine();
            Console.WriteLine($"Индекс: {index} число: {array[index]}");
            Console.WriteLine($"{nameFunc} - время поиска: {timer.Elapsed.TotalMilliseconds} мс.");
        }
    }
}