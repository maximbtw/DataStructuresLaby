using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLaby
{
    class MainLab1
    {
        public static void Start()
        {
            //Задание 1
            Console.WriteLine("Hello World!");
            //Задание 2
            var matrix = new Matrix();
            matrix.Create(7);
            //Задание 3
            var array = CreateArray(50000);

            var timer = new Timer();

            timer.SortingTime(array, Array.Sort, "Встроенная");
            timer.SortingTime(array, SortingArray.ChoiceSort, "Выбора");
            timer.SortingTime(array, SortingArray.InsertSort, "Вставка");
            timer.SortingTime(array, SortingArray.ExchangeSort, "Обмена");
            timer.SortingTime(array, SortingArray.ShellSort, "Шелла");
            timer.SortingTime(array, SortingArray.PyramidSort, "Пирамидальная");
            timer.SortingTime(array, SortingArray.QuickSort, "Быстрая сортировка");
        }

        /// <summary>
        /// Создает массив и заполняет его случайными числами
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static int[] CreateArray(int length)
        {
            var rnd = new Random();
            var array = new int[length];

            for (int i = 0; i < length; i++)
                array[i] = rnd.Next(0, 100);

            return array;
        }
    }
}
