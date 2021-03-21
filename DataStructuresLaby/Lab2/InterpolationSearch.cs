namespace DataStructuresLaby.Lab2
{
    class InterpolationSearch
    {
        public int Search(int[] array, int value) 
                => Search(array, value, 0, array.Length - 1);

        private int Search(int[] array, int value, int left, int right)
        {
            int index = -1;

            if (left <= right)
            {
                index = left + ((right - left) / (array[right] - array[left]) * (value - array[left]));
                if (array[index] == value) return index;
                else
                {
                    if (array[index] < value)
                        left = index + 1;
                    else
                        right = index - 1;
                }

                return Search(array, value, left, right);
            }

            return index;
        }
    }
}
