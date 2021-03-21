using System;

namespace DataStructuresLaby.Lab2
{
    /*
     * Расставить на стандартной 64-клеточной шахматной доске 8 ферзей так, чтобы ни
     *один из них не находился под боем другого». Подразумевается, что ферзь бьёт все клетки,
     *расположенные по вертикалям, горизонталям и обеим диагоналям
     *Написать программу, которая находит хотя бы один способ решения задач.
     */
    class Task8F
    {
        public static void Start() => Start(new byte[9]);

        //Перебор 8^8 вариантов
        private static void Start(byte[] p, int pos = 1)
        {
            for (byte i = 1; i <= 8; i++)
            {
                p[pos] = i;
                if (pos != 8) Start(p, pos + 1);
                else
                {
                    p[0] = 0; // обнуление счетчика
                    GetScore(p);
                    if (p[0] == 28) WriteResult(p);
                }
            }
        }

        /// <summary>
        /// Проверка на пересечения ферзей
        /// </summary>
        /// <param name="p"></param>
        private static void GetScore(byte[] p)
        {
            bool hPoints, dPoints45, dPoints135;
            for (byte i = 1; i < 8; i++)
            {
                for (byte j = (byte)(i + 1); j <= 8; j++)
                {
                    hPoints    = (p[i] != p[j]); // не на одной горизонтали (строке)
                    dPoints45  = (p[j] - p[i]) != (j - i);   // не на одной диагонали (45 град)
                    dPoints135 = (p[i] + i) != (p[j] + j);   // не на одной диагонали (135 град)
                    if (hPoints && dPoints45 && dPoints135) p[0]++; // если не бьют друг друга
                }
            }
        }

        /// <summary>
        /// Вывод комбинации на консоль
        /// </summary>
        /// <param name="p"></param>
        private static void WriteResult(byte[] p)
        {
            for (int j = 1; j <= 8; j++)
                Console.Write($" {p[j]} ");
            Console.WriteLine();
        }
    }
}