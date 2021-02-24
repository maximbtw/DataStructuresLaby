using System.Diagnostics;
using System;

namespace DataStructuresLaby
{
    class Timer
    {
        /// <summary>
        /// Засекает время сортировки
        /// </summary>
        /// <param name="array"></param>
        /// <param name="sortingMethod"></param>
        /// <param name="methodName"></param>
        public void SortingTime(Matrix matrix, Action<int[]> sortingMethod, string methodName)
        {
            var time = new Stopwatch();

            time.Start();
            foreach (var line in matrix.Value)
                sortingMethod(line);
            time.Stop();

            var timeSortMethod = time.Elapsed.TotalMilliseconds;

            Console.WriteLine($"Сортировка методом: {methodName} : " +
                              $"{timeSortMethod} МС");
        }
    }
}
