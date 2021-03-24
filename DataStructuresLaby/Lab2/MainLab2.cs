using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace DataStructuresLaby.Lab2
{
    class MainLab2
    {
        public static void Start()
        {
            //var array = new int[] { 1, 3, 4, 6, 7, 7, 9, 10, 10, 12, 12, 12, 12, 12 };

            //var hashTable = new RandomHashtable<int, int>(100);

            //for (int i = 0; i < array.Length; i++)
            //{
            //    hashTable.Add(i, array[i]);
            //}

            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(hashTable.Find(i));
            //}



            var array = CreateArray(1000000);
            var findItem = array[68873];
            Console.WriteLine($"Ищем: {findItem}");


            GetTime("Встроенный поиск", Array.FindIndex, array.ToArray(),(Predicate<int>)((item) => item == findItem));
            GetTime("Бинарный поиск",             BinarySearch<int>.Search,     array.ToArray(), findItem);
            GetTime("Фибоначчиев поиск",      new FibonacciSearch().Search,     array.ToArray(), findItem);
            GetTime("Интерполяционный поиск", new InterpolationSearch().Search, array.ToArray(), findItem);
            Console.WriteLine("\nКонец");
        }

        public static int[] CreateArray(int size)
        {
            int[] array = new int[size];
            var rnd = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(0,10000);

            return array;
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