using System;

namespace DataStructuresLaby.Lab1
{
    class Main
    {
        public static void Start()
        {            
            //Задание 1
            Console.WriteLine("Hello World!");
            //Задание 2
            var matrix = new Matrix(100, 10000);
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
            timer.SortingTime(matrix.Clone(), SortingArray.Tournament, "Турнирная сортировка");
        }
    }
}
