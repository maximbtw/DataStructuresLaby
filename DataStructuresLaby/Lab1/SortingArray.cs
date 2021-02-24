namespace DataStructuresLaby
{
    class SortingArray
    {
        /// <summary>
        /// Обмен 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }

        /// <summary>
        /// Метод сортировки выбором
        /// </summary>
        /// <param name="array"></param>
        public static void ChoiceSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j] < array[min])
                        min = j;
                Swap(ref array[min], ref array[i]);
            }
        }

        /// <summary>
        /// Метод сортировки вставкой
        /// </summary>
        /// <param name="array"></param>
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int cur = array[i];
                int j = i;
                while (j > 0 && cur < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = cur;
            }
        }

        /// <summary>
        /// Метод сортировки обменом
        /// </summary>
        /// <param name="array"></param>
        public static void ExchangeSort(int[] array)
        {
            var lenght = array.Length;
            for (var i = 1; i < lenght; i++)
                for (var j = 0; j < lenght - i; j++)
                    if (array[j] > array[j + 1])
                        Swap(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Метод сортировки Шелла
        /// </summary>
        /// <param name="array"></param>
        public static void ShellSort(int[] array)
        {
            var d = array.Length / 2;
            while (d >= 1)
            {
                for (var i = d; i < array.Length; i++)
                {
                    var j = i;
                    while (j >= d && array[j - d] > array[j])
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
        }

        /// <summary>
        /// Метод пирамидальная сортировки
        /// </summary>
        /// <param name="array"></param>
        public static void PyramidSort(int[] array)
        {
            var lenght = array.Length;
            for (int i = lenght / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = AddToPyramid(array, i, lenght);
                if (prev_i != i) ++i;
            }
            for (int k = lenght - 1; k > 0; --k)
            {
                Swap(ref array[0], ref array[k]);
                int i = 0, prev = -1;
                while (i != prev)
                {
                    prev = i;
                    i = AddToPyramid(array, i, k);
                }
            }
        }

        private static int AddToPyramid(int[] arr, int i, int N)
        {
            int iMax;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) iMax = 2 * i + 2;
                else iMax = 2 * i + 1;
            }
            else iMax = 2 * i + 1;
            if (iMax >= N) return i;
            if (arr[i] < arr[iMax])
            {
                Swap(ref arr[i], ref arr[iMax]);
                if (iMax < N / 2) i = iMax;
            }
            return i;
        }

        /// <summary>
        /// Метод быстрой сортировки
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex) return;
            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);
        }

        private static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }
            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);

            return pivot;
        }
    }
}
