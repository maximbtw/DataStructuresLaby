namespace DataStructuresLaby.Lab3
{
    /// <summary>
    /// Алгоритм Кнута-Морриса-Пратта
    /// </summary>
    public class KMP
    {
        public static int FindSubstring(string pattern, string text, bool checkCase = true)
        {
            if (!checkCase)
            {
                pattern = pattern.ToLower();
                text = text.ToLower();
            }

            int[] prefix = GetPrefix(pattern);
            int index = 0;

            for (int i = 0; i < text.Length; i++)
            {
                while (index > 0 && pattern[index] != text[i])
                {
                    index = prefix[index - 1];
                }

                if (pattern[index] == text[i]) index++;
                if (index == pattern.Length)
                {
                    return i - index + 1;
                }
            }

            return -1;
        }

        private static int[] GetPrefix(string text)
        {
            var result = new int[text.Length];
            result[0] = 0;
            int index = 0;

            for (int i = 1; i < text.Length; i++)
            {
                while (index >= 0 && text[index] != text[i])
                { 
                    index--;
                }
                index++;
                result[i] = index;
            }

            return result;
        }
    }
}
