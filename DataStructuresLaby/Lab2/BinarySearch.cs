using System;

namespace DataStructuresLaby.Lab2
{
    class BinarySearch<TValue> where TValue : IComparable
    {
        public static int FindLeftIndex(TValue[] arr, TValue value)
        {
            return BinSearchLeftBorder(arr, value, 0, arr.Length -1);
        }

        private static int BinSearchLeftBorder(TValue[] array, TValue value, int left, int right)
        {
            if (left >= right)
                return (array[right].CompareTo(value) == 0) ? right : -1;
            var middle = (right + left) / 2;
            if (array[middle].CompareTo(value) < 0)
                return BinSearchLeftBorder(array, value, middle + 1, right);
            return BinSearchLeftBorder(array, value, left, middle);
        }
    }
}
