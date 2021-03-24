using System;

namespace DataStructuresLaby.Lab1
{
    public class Matrix
    {
        public int[][] Value { get; private set; }

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

            Value = new int[n][];
        }

        /// <summary>
        /// Заполняет матрицу случайными числами
        /// </summary>
        /// <param Номер варианта="variant"></param>
        public void Create(int variant)
        {
            rnd = new Random();
            maxLimit += variant;

            for (int i = 0; i < Value.Length; i++)
            {
                Value[i] = new int[m];
                for (int j = 0; j < Value[i].Length ; j++)
                    Value[i][j] = rnd.Next(minLimit, maxLimit);
            }
        }

        public override string ToString()
        {
            var message = string.Empty;

            foreach (var line in Value)
            {
                foreach (var cell in line)
                {
                    string item = cell.ToString();
                    while (item.Length < 5) item += " ";
                    message += item;
                }
                message += "\n";
            }
            return message;
        }

        /// <summary>
        /// Создает копию матрицы, на основе родителя
        /// (матрица является ссылочным типом)
        /// </summary>
        /// <returns></returns>
        public Matrix Clone()
        {
            Matrix matrixClone = new Matrix(m, n, minLimit, maxLimit);
            matrixClone.FillValue(this);

            return matrixClone;
        }

        private void FillValue(Matrix parent)
        {
            for (int i = 0; i < Value.Length; i++)
            {
                Value[i] = new int[m];
                for (int j = 0; j < Value[i].Length; j++)
                    Value[i][j] = parent.Value[i][j];
            }
        }
    }
}
