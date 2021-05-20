using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLaby.Tasks
{
    /*
     * 
     * Задача 1. «Стопки монет»
     *   На столе стоят 3n стопок монет. Вы и ваши друзья Алиса и Боб забираете стопки монет по
     *  следующему алгоритму:
     *   1. Вы выбираете 3 стопки монет из оставшихся на столе.
     *   2. Алиса забирает себе стопку с максимальным количеством монет.
     *   3. Вы забираете одну из двух оставшихся стопок.
     *   4. Боб забирает последнюю стопку.
     *   5. Если еще остались стопки, то действия повторяются с первого шага
     */
    public static class Task3
    {
        public static void Run()
        {
            var instances = new int[][]
            {
                new int[] { 2, 4, 1, 2, 7, 8 },
                new int[] { 2, 4, 5 },
                new int[] { 9, 8, 7, 6, 5, 1, 2, 3, 4 },
            };

            foreach (var instance in instances)
            {
                Console.WriteLine(GetMax(instance));
            }
        }

        public static int GetMax(int[] piles)
        {
            int maxSum = 0;

            Array.Sort(piles);

            for (int i = piles.Length / 3; i < piles.Length; i += 2)
            {
                maxSum += piles[i];
            }

            return maxSum;
        }
    }
}
