using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLaby.Tasks
{
    public static class Task4
    {
        /*
         * Задача 1. «Шарики и стрелы»
         *   Некоторые сферические шарики распределены по двухмерному пространству. Для каждого
         *   шарика даны x­координаты начала и конца его горизонтального диаметра. Так как пространство
         *   двумерно, то y­координаты не имеют значения в данной задаче. Координата xstart всегда меньше
         *   xend.
         *   Стрелу можно выстрелить строго вертикально (вдоль y­оси) из разных точек x­оси. Шарик
         *   с координатами xstart и xend уничтожается стрелой, если она была выпущена из такой позиции
         *   x, что xstart ⩽ x ⩽ xend. Когда стрела выпущена, она летит в пространстве бесконечное время
         *   (уничтожая все шарики на пути).
         */

        public static void Run()
        {
            var instances = new int[][][]
            {
                new int[][] { new int[] { 10, 16 }, new int[] { 2, 8 }, new int[] { 1, 6 }, new int[] { 7, 12 } },
                new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 }, new int[] { 7, 8 } },
                new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5 } },
                new int[][] { new int[] { 1, 2 } },
                new int[][] { new int[] { 2, 3 }, new int[] { 2, 3 } },
            };

            foreach (var instance in instances)
            {
               Console.WriteLine(FindMinArrowShots(instance));
            }
        }

        public static int FindMinArrowShots(int[][] points)
        {
            if (points == null || points.Length == 0)
            {
                return 0;
            }

            Array.Sort(points, (x, y) => x[1].CompareTo(y[1]));

            int end = points[0][1], count = 1;
            for (int i = 1; i < points.Length; i++)
            {
                if (!(points[i][0] <= end))
                {
                    end = points[i][1];
                    count++;
                }
            }

            return count;
        }
    }
}
