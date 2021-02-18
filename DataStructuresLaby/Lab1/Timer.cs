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
        /// <param name="method"></param>
        /// <param name="methodName"></param>
        public void SortingTime(int[] array, Action<int[]> method, string methodName)
        {
            var time = new Stopwatch();

            time.Start();
            method(array);
            time.Stop();

            var timeSortMethod = time.Elapsed.TotalMilliseconds;

            Console.WriteLine($"Сортировка методом: {methodName} : " +
                              $"{timeSortMethod} МС");
        }
    }
}
