using System;
using System.Linq;

namespace DataStructuresLaby.Tasks
{
    public static class Task1
    {
        public static void Run()
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
                Console.WriteLine(MaxPerimeter(array));
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
                Console.WriteLine(MaxDigit(array));
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

            foreach (var matrix in arrays3)
            {
                SortMatrixDiagonals(matrix);
            }

            foreach (var matrix in arrays3)
            {
                foreach (var line in matrix)
                {
                    foreach (var element in line)
                        Console.Write(element + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        /*
         * Задача 1. «Треугольник с максимальным периметром»
         * Массив A состоит из целых положительных чисел ­ длин отрезков. 
         * Составьте из трех отрезков такой треугольник, чтобы его периметр был максимально возможным. 
         * Если невозможно составить треугольник с положительной площадью ­ функция возвращает 0.
         */
        public static int MaxPerimeter(int[] digits)
        {
            int max = 0;
            Array.Sort(digits);
            Array.Reverse(digits);

            for (int i = 0; i < digits.Length - 2; i++)
            {
                if (digits[i] < digits[i + 1] + digits[i + 2])
                {
                    max = Math.Max(max, digits[i] + digits[i + 1] + digits[i + 2]);
                    break;
                }
            }

            return max;
        }

        /*
         * Задача 2. «Максимальное число»
         * Дан массив неотрицательных целых чисел nums. Расположите их в таком порядке, чтобы
         * вместе они образовали максимально возможное число.
         * Замечание: Результат может быть очень большим числом, поэтому представьте его как
         * string, а не integer
         */
        public static string MaxDigit(int[] digits)
        {
            var arr = digits.Select(x => x.ToString()).ToArray();
            for (var i = 1; i < arr.Length; i++)
                for (var j = 0; j < arr.Length - i; j++)
                    if (Compare(arr[j], arr[j + 1]) < 0)
                        Swap(ref arr[j], ref arr[j + 1]);

            var result = string.Empty;
            foreach (var str in arr) result += str;

            return result;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        private static int Compare(string s1, string s2)
        {
            while (s1.Length != s2.Length)
            {
                if (s1.Length > s2.Length) s2 += "0";
                else s1 += "0";
            }
            return s1.CompareTo(s2);
        }

        /*
         * Задача 3
         * Дана матрица mat размером m * n, значения  целочисленные.
         * Напишите функцию, сортирующую каждую диагональ матрицы по возрастанию
         * и возвращающую получившуюся матрицу. 
         */

        public static void SortMatrixDiagonals(int[][] matrix)
        {
            var m = matrix.Length;
            var n = matrix[0].Length;
            var c = 1;

            while (c != m)
            {
                Sorting(m, n, matrix);
                c++;
            }
        }

        private static void Sorting(int m, int n, int[][] matrix)
        {
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    if (i + 1 < m && j + 1 < n && matrix[i + 1][j + 1] < matrix[i][j])
                    {
                        var temp = matrix[i + 1][j + 1];
                        matrix[i + 1][j + 1] = matrix[i][j];
                        matrix[i][j] = temp;
                    }
                }
            }
        }
    }
}
