using System;

namespace DataStructuresLaby.Lab2
{
    class BinarySearch<TValue> where TValue : IComparable
    {
        public static int Search(TValue[] arr, TValue value)
                       => Search(arr, value, 0, arr.Length - 1);

        private static int Search(TValue[] array, TValue value, int left, int right)
        {
            if (left >= right)
                return (array[right].CompareTo(value) == 0) ? right : -1;
            var middle = (right + left) / 2;
            if (array[middle].CompareTo(value) < 0)
                return Search(array, value, middle + 1, right);
            return Search(array, value, left, middle);
        }
    }
}
