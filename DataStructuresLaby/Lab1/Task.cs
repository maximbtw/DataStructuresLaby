using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresLaby.Lab1
{
    class Task
    {
        public static int MaxPerimeter(int[] digits)
        {
            List<int> result = new List<int>(3);

            foreach (var digit in digits.OrderBy(x => x))
            {
                bool tryAdd = true;

                if (result.Count < 2) result.Add(digit);

                if()
            }

            return result.Sum(x => x);
        }
    }
}
