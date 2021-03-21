namespace DataStructuresLaby.Lab2
{
    class FibonacciSearch
    {
        private int index;
        private int item1;
        private int item2;
        private bool stop = false;

        private void Init(int[] array)
        {
            stop = false;
            var k = 0;
            var n = array.Length;
            while (GetNumber(k + 1) < n + 1) k++;
            var m = (int) GetNumber((k + 1) - (n + 1));
            index = (int)(GetNumber(k) - m);
            item1 = (int) GetNumber(k - 1);
            item2 = (int) GetNumber(k - 2);
        }

        private long GetNumber(int v)
        {
            long firstNumber = 0;
            long secondNumber = 1;

            for (int i = 0; i < v; i++)
            {
                long temp = secondNumber;
                secondNumber += firstNumber;
                firstNumber = temp;
            }
            return firstNumber;
        }

        private void UpIndex()
        {
            if (item1 == 1) stop = true;
            index += item2;
            item1 -= item2;
            item2 -= item1;
        }

        private void DownIndex()
        {
            if (item2 == 0) stop = true;
            index -= item2;
            int temp = item2;
            item2 = item1 - item2;
            item1 = temp;
        }

        public int Search(int[] array, int value)
        {
            Init(array);
            var n = array.Length;
            var resultIndex = -1;
            while (!stop)
            {
                if (index < 0) UpIndex();
                else if (index >= n) DownIndex();
                else if (array[index] == value)
                {
                    resultIndex = index;
                    break;
                }
                else if (value < array[index]) DownIndex();
                else if (value > array[index]) UpIndex();
            }
            return resultIndex;
        }
    }
}
