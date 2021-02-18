using System;

namespace DataStructuresLaby
{
    public class Matrix
    {
        public int[,] Value { get; private set; }

        private int m;
        private int n;
        private int minLimit;
        private int maxLimit;

        private Random rnd;

        public Matrix(int m = 50, int n = 50, int minLimit = -250, int maxLimit = 1000)
        {
            this.m = m;
            this.n = n;
            this.minLimit = minLimit;
            this.maxLimit = maxLimit;

            Value = new int[n, m];
        }

        /// <summary>
        /// Заполняет матрицу случайными числами
        /// </summary>
        /// <param Номер варианта="variant"></param>
        public void Create(int variant)
        {
            rnd = new Random();
            maxLimit += variant;

            for (int i = 0; i < Value.GetLength(0); i++)
                for (int j = 0; j < Value.GetLength(1); j++)
                    Value[i, j] = rnd.Next(minLimit, maxLimit);
        }

        public override string ToString()
        {
            var message = string.Empty;

            for (int i = 0; i < Value.GetLength(0); i++) 
            {
                for (int j = 0; j < Value.GetLength(1); j++)
                {
                    string item = Value[i, j].ToString();
                    while (item.Length < 5) item += " ";
                    message += item;
                }
                message += "\n";
            }
            return message;
        }
    }
}
