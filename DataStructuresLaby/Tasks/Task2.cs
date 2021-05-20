using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresLaby.Tasks
{
    public static class Task2
    {
        public static void Run()
        {
            Console.WriteLine(StringBattle("abc", "xya"));
            Console.WriteLine(StringBattle("abe", "acd"));

            Console.WriteLine(MaxPalindrome("babad"));
            Console.WriteLine(MaxPalindrome("cbbd"));

            Console.WriteLine(DistinctEchoSubstrings("abcabcabc"));
        }

        /*
         *    Даны две строки: s1 и s2 с одинаковым размером, проверьте, может ли
         * некоторая перестановка строки s1 “победить” некоторую перестановку
         * строки s2 или наоборот.
         * Строка x может “победить” строку y (обе имеют размер n), если x[i]> = y
         * [i] (в алфавитном порядке) для всех i от 0 до n-1.
         */

        public static bool StringBattle(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                throw new ArgumentException();
            }

            bool result = false;

            ShowAllCombinations(s2.ToCharArray(), s1, ref result);

            return result;
        }

        private static bool CheckBattle(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s2[i] < s1[i])
                {
                    return false;
                }
            }

            return true;
        }


        private static void ShowAllCombinations
            (IList<char> arr, string s1, ref bool result, string current = "")
        {
            if (result) return;

            if (arr.Count == 0)
            {
                result = CheckBattle(s1, current);

                return;
            }
            for (int i = 0; i < arr.Count; i++) 
            {
                List<char> lst = new List<char>(arr);
                lst.RemoveAt(i);
                ShowAllCombinations(lst, s1, ref result, current + arr[i].ToString());
            }
        }

        /*
          *  Дана строка s, вернуть самую длинную полиндромную подстроку в s.
          */

        public static string MaxPalindrome(string word)
        {
            int count = word.Length;

            while (count != 0) 
            {
                for (int i = 0; i < word.Length - count; i++)
                {
                    int secondIndex = i + count;

                    if (PalindromeCheck(word, i, secondIndex))
                    {
                        StringBuilder builder = new StringBuilder();

                        for (int k = i; k <= secondIndex; k++)
                        {
                            builder.Append(word[k]);
                        }

                        return builder.ToString();
                    }
                }

                count--;
            }

            return string.Empty;
        }

        private static bool PalindromeCheck(string word, int minIndex, int maxIndex)
        {

            for (int i = 0; i < maxIndex-minIndex; i++)
            {                    
                if (word[minIndex+i] != (word[maxIndex-i]))  
                {
                    return false;
                }
            }

            return true;
        }

        /*
          *   Вернуть количество отдельных непустых подстрок текста, которые могут
          * быть записаны как конкатенация некоторой строки с самой собой (т.е. она
          * может быть записана, как a + a, где a - некоторая строка).
          */

        public static int DistinctEchoSubstrings(string text)
        {
            int mod = (int)Math.Pow(10, 9) + 7;
            int[,] dp = new int[text.Length + 1, text.Length + 1];
            HashSet<int> res = new HashSet<int>();

            for (int i = 1; i <= text.Length; i++)
            {
                for (int j = i; j <= text.Length; j++)
                {
                    dp[i, j] = dp[i, j - 1] * 26 % mod + text[j - 1] - 'a' + 1;

                    if (i * 2 - j - 1 >= 0 && dp[i * 2 - j - 1, i - 1] == dp[i, j])
                    {
                        res.Add(dp[i, j]);
                    }
                }
            }

            return res.Count;
        }
    }
}
