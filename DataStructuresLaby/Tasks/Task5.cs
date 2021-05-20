using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLaby.Tasks
{
    /*
     *      Дан массив отрезков intervals, в котором intervals[i] = [starti, endi], некоторые
     *   отрезки могут пересекаться. Напишите функцию, которая объединяет 
     *   все пересекающиеся отрезки в один и возвращает новый массив непересекающихся отрезков.
     */
    public static class Task5
    {
        public static void Run()
        {
            var instances = new int[][][]
            {
                new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } },
                new int[][] { new int[] { 1, 4 }, new int[] { 4, 5 } },
            };

            foreach (var instance in instances)
            {
                var result = Merge(instance);

                for (int i = 0; i < result.Length; i++)
                {
                    Console.Write("[");
                    for (int j = 0; j < result[i].Length; j++)
                    {
                        Console.Write(" ," + result[i][j]);
                    }
                    Console.Write(" ], ");
                }
                Console.WriteLine();
            }
        }

        public static int[][] Merge(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
                return new int[][] { };

            List<int[]> result = new List<int[]>();

            Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

            int s = intervals[0][0],
                e = intervals[0][1];

            for (int i = 1; i < intervals.Length; i++)
                if (e < intervals[i][0])
                {
                    result.Add(new int[] { s, e });

                    s = intervals[i][0];
                    e = intervals[i][1];
                }
                else
                    e = Math.Max(e, intervals[i][1]);

            result.Add(new int[] { s, e });

            return result.ToArray();
        }
    }
}
