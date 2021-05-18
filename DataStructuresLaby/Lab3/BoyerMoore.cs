namespace DataStructuresLaby.Lab3
{
    /// <summary>
    /// Упрощенный алгоритм Бойера-Мура
    /// </summary>
    public class BoyerMoore
    {
        public static int FindSubstring(string pattern, string text, bool checkCase = true) 
        {
            if (!checkCase)
            {
                pattern = pattern.ToLower();
                text = text.ToLower();
            }

            var offsetTable = new int[256];

            if (pattern.Length > text.Length) 
            {
                return -1;
            }

            for (int t = 0; t < offsetTable.Length; t++)
            {
                offsetTable[t] = pattern.Length;
            }
            
            for (int t = 0; t < pattern.Length - 1; t++) 
            {
                offsetTable[pattern[t]] = pattern.Length - t - 1;
            }

            int i = pattern.Length - 1;
            int j = i;
            int k = i;

            while (j >= 0 && i <= text.Length - 1 ) 
            {
                j = pattern.Length - 1;
                k = i;

                while (j >= 0 && text[k] == pattern[j]) 
                {
                    k--;
                    j--;
                }

                i += (char)offsetTable[text[i]];
            }

            if (k >= text.Length - pattern.Length) 
            {
                return -1;
            } 

            return k + 1;
        }
    }
}