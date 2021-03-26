using System;
using System.Collections.Generic;   
using System.Linq;
using System.Diagnostics;
using DataStructuresLaby.Lab2.Hashtable;
using DataStructuresLaby.Lab2.Search;

namespace DataStructuresLaby.Lab2
{
    class Main
    {
        private static readonly int size = 5000;

        public static void Start()
        {
            //Task8F.Start();
            var array = new int[size];
            var tree = new BinaryTree<int>();
            var hashtables = new Dictionary<string, Hashtable<int, int>>
            {
                ["Рехэширование с помощью псевдослучайных чисел"] = new RandomHashtable<int, int>(size),
                ["Простое рехещирование"] = new SimpleHashtable<int, int>(size),
                ["Метод цепочек"] = new ChainHashtable<int, int>(size),
            };

            FillCollections(array, tree, hashtables);
            Array.Sort(array);

            var findElement = array[1];
            Console.WriteLine($"Ищем элемент: {findElement}");

            GetTimeFindMethod("Встроенный поиск", Array.FindIndex, array.ToArray(), (Predicate<int>)((item) => item == findElement));
            GetTimeFindMethod("Бинарный поиск", BinarySearch<int>.Search, array.ToArray(), findElement);
            GetTimeFindMethod("Фибоначчиев поиск", new FibonacciSearch().Search, array.ToArray(), findElement);
            GetTimeFindMethod("Интерполяционный поиск", new InterpolationSearch().Search, array.ToArray(), findElement);
            GetTimeBinaryTree(tree, findElement);

            foreach (var hashtable in hashtables)
                GetTimeHashTable(hashtable.Key, hashtable.Value, findElement);

            Console.WriteLine("\nКонец");
        }

        private static void FillCollections(int[] array, BinaryTree<int> tree,
            Dictionary<string, Hashtable<int, int>> hashtables)
        {
            var rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                int element = rnd.Next(0, 10000);
                array[i] = element;
                tree.Add(element);
                foreach (var hashtable in hashtables)
                    hashtable.Value.Add(element, element);
            }
        }

        private static void GetTimeHashTable<TKey, TValue>(string name, Hashtable<TKey, TValue> hashtable, TKey findKey)
        {
            Stopwatch timer = new Stopwatch();

            //hashtable.Find(findKey);
            timer.Start();
            var findItem = hashtable.Find(findKey);
            timer.Stop();

            SendResult(name, timer.Elapsed.TotalMilliseconds, findItem);
        }

        private static void GetTimeBinaryTree<T>(BinaryTree<T> tree, T element) where T : IComparable<T>
        {
            Stopwatch timer = new Stopwatch();

            //tree.Find(element);
            timer.Start();
            var findItem = tree.Find(element);
            timer.Stop();

            SendResult("Бинарное дерево", timer.Elapsed.TotalMilliseconds, findItem);
        }

        private static void GetTimeFindMethod<T>(string nameFunc, Func<int[], T, int> func, int[] array, T element)
        {
            Stopwatch timer = new Stopwatch();

            //func(array, element);
            timer.Start();
            var index = func(array, element);
            timer.Stop();

            SendResult(nameFunc, timer.Elapsed.TotalMilliseconds, array[index], index);
        }

        private static void SendResult<T>(string name, double time, T element, int index = -1)
        {
            Console.WriteLine();
            Console.WriteLine($"Найден элемент: {element}");
            if (index != -1) Console.WriteLine($"Под индексом: {index}");
            Console.WriteLine($"{name} - время поиска: {time} мс.");
        }
    }
}