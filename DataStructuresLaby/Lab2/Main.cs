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
        private static readonly int size = 10;

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

            var findElement = array[9];
            Console.WriteLine($"Ищем элемент: {findElement}");

            GetTimeFindMethod("Встроенный поиск", Array.FindIndex, array.ToArray(), (Predicate<int>)((item) => item == findElement));
            GetTimeFindMethod("Бинарный поиск",             BinarySearch<int>.Search,     array.ToArray(), findElement);
            GetTimeFindMethod("Фибоначчиев поиск",      new FibonacciSearch().Search,     array.ToArray(), findElement);
            GetTimeFindMethod("Интерполяционный поиск", new InterpolationSearch().Search, array.ToArray(), findElement);
            GetTimeBinaryTree(tree, findElement);

            Console.WriteLine("\nКонец");
        }

        private static void FillCollections(int[] array, BinaryTree<int> tree, Hashtable<int, int>[] hashtables)
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



        private static void GetTimeBinaryTree<T>(BinaryTree<T> tree, T element) where T : IComparable<T>
        {
            Stopwatch timer = new Stopwatch();

            timer.Start();
            var findItem = tree.Find(element);
            timer.Stop();

            Console.WriteLine();
            Console.WriteLine($"Элемент: {findItem}");
            Console.WriteLine($"Бинарное дерево - время поиска: {timer.Elapsed.TotalMilliseconds} мс.");
        }

        private static void GetTimeFindMethod<T>(string nameFunc, Func<int[], T, int> func, int[] array, T element)
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