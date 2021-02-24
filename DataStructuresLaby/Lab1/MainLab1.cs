using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DataStructuresLaby
{
    class MainLab1
    {
        public static void Start()
        {
            //Задание 1
            Console.WriteLine("Hello World!");
            //Задание 2
            var matrix = new Matrix(50, 50);
            matrix.Create(7);
            //Console.WriteLine(matrix.ToString());
            //Задание 3

            var timer = new Timer();

            timer.SortingTime(matrix.Clone(), Array.Sort, "Встроенная");
            timer.SortingTime(matrix.Clone(), SortingArray.ChoiceSort, "Выбора");
            timer.SortingTime(matrix.Clone(), SortingArray.InsertionSort, "Вставка");
            timer.SortingTime(matrix.Clone(), SortingArray.ExchangeSort, "Обмена");
            timer.SortingTime(matrix.Clone(), SortingArray.ShellSort, "Шелла");
            timer.SortingTime(matrix.Clone(), SortingArray.PyramidSort, "Пирамидальная");
            timer.SortingTime(matrix.Clone(), SortingArray.QuickSort, "Быстрая сортировка");
        }
    }
}
