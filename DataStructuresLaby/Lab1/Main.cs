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

        public static void StartTask()
        {
            //Задача 1
            var arrays1 = new int[][]
            {
                new int[] { 2, 1, 2 },
                new int[] { 1, 2, 1 },
                new int[] { 3, 2, 3 ,4 },
                new int[] { 3, 6, 2, 3 },
            };
            foreach (var array in arrays1)
            {
                //Console.WriteLine(Task.MaxPerimeter(array));
            }

            //Задача 2
            var arrays2 = new int[][]
{
                new int[] { 10, 2 },
                new int[] { 1 },
                new int[] { 3, 30, 34, 5, 9 },
                new int[] { 10 },
};
            foreach (var array in arrays2)
            {
                //Console.WriteLine(Task.MaxDigit(array));
            }

            //Задача 3

            var arrays3 = new int[][][]
            {
                new int[][]
                {
                    new int[] { 3, 3, 1, 1 },
                    new int[] { 2, 2, 1, 2 },
                    new int[] { 1, 1, 1, 2 },
                },
                new int[][]
                {
                    new int[] { 11, 25, 66, 1, 69, 7 },
                    new int[] { 23, 55, 17, 45, 15, 52 },
                    new int[] { 75, 31, 36, 44, 58, 8 },
                    new int[] { 22, 27, 33, 25, 68, 4 },
                    new int[] { 84, 28, 14, 11, 5, 50 },
                },
            };

            foreach( var matrix in arrays3)
            {
                Task.SortMatrixDiagonals(matrix);
            }

            foreach (var matrix in arrays3)
            {
                foreach(var line in matrix)
                {
                    foreach (var element in line)
                        Console.Write(element + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
