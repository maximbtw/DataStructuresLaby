using System.Diagnostics;
using System;
using System.Text;

namespace DataStructuresLaby.Lab3
{
	class Main
	{
		public static void Start()
		{
            var game = new Game(new[,]
            {
                {1, 2, 3, 4},
                {5, 6, 7, 8},
                {9, 10, 12, 0},
                {13, 14, 11, 15},
            });

            GameController.Run(game);

            string pattern = "word";
            string text = CreateText(pattern, 100000);

            SendResult("КМP", () => GetTime(KMP.FindSubstring, pattern, text));
            SendResult("BoyerMoore", () => GetTime(BoyerMoore.FindSubstring, pattern, text));
        }

        private static string CreateText(string pattern, int lengthText)
        {
            if (lengthText < pattern.Length)
            {
                throw new ArgumentException();
            }

            var random = new Random();

            int position = random.Next(0, lengthText - pattern.Length);
            var builder = new StringBuilder(lengthText);

            Console.WriteLine("Ответ: " + position);

            while (builder.Length != lengthText)
            {
				if (builder.Length == position)
                {
                    builder.Append(pattern);
                }
                else
                {
					builder.Append((char)random.Next('a', 'z' + 1));
                }
            }

			return builder.ToString();
        }

        private static Tuple<int, double> GetTime(Func<string,string,bool,int> substingFunc,
			string paatern, string text, bool checkCase = true)
        {
			Stopwatch timer = new Stopwatch();

			timer.Start();
			int index = substingFunc(paatern, text, checkCase);
			timer.Stop();

			return Tuple.Create(index, timer.Elapsed.TotalMilliseconds);
		}

		private static void SendResult(string name, Func<Tuple<int, double>> timer)
		{
			Tuple<int, double> result = timer.Invoke();
			var index = result.Item1;
			var time  = result.Item2;

			Console.WriteLine($"{name} - результат: {index}; время поиска: {time} мс.");
		}
	}
}

