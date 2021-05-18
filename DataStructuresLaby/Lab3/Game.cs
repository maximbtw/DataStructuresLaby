using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresLaby.Lab3
{
    /* Игра в пятнашки */

	public class GameController
    {
		public static void Run(Game start)
        {
            if (!ValidateGame(start))
            {
				Console.WriteLine("Нет решений");
				return;
            }

			var target = new Game(new[,]
			{
			   {1, 2, 3, 4},
			   {5, 6, 7, 8},
			   {9, 10, 11, 12},
			   {13, 14, 15, 0},
			});

			Dictionary<Game, Game> path = new Dictionary<Game, Game>();
			path[start] = null;
			var queue = new Queue<Game>();
			queue.Enqueue(start);
			while (queue.Count != 0)
			{
				var game = queue.Dequeue();

				var nextGames = game
					.AllAdjacentGames()
					.Where(g => !path.ContainsKey(g));
				foreach (var nextGame in nextGames)
				{
					path[nextGame] = game;
					queue.Enqueue(nextGame);
				}
				if (path.ContainsKey(target)) break;
			}
			while (target != null)
			{
				target.Print();
				target = path[target];
			}
		}

		private static bool ValidateGame(Game game)
        {
			int sum = 0;
			int position = 0;
			var array = new List<int>(16);

            foreach (int item in game.Data)
            {
				array.Add(item);
            }

            while (position != 16)
            {
                for (int i = position + 1; i < array.Count; i++)
                {
					if (array[i] < array[position] && array[i] != 0)
                    {
						sum++;
                    }
                }

				position++;
            }

			sum += Array.FindIndex(array.ToArray(), (x) => (x == 0)) % 4;

			return sum % 2 == 0;
        }
    }

    public class Game
	{
		class Point
        {
			public int X { get; set; }
			public int Y { get; set; }
		}

		const int Size = 4;
		public int[,] Data { get; set; }
		public Game(int[,] data)
		{
			Data = data;
		}
		public Game(Game original)
			: this((int[,])original.Data.Clone())
		{

		}

		IEnumerable<Point> Rectangle(int xmin, int xmax, int ymin, int ymax)
		{
			for (int x = xmin; x <= xmax; x++)
				for (int y = ymin; y <= ymax; y++)
					yield return new Point { X = x, Y = y };
		}

		IEnumerable<Point> GamePoints
		{
			get
			{
				return Rectangle(0, Size - 1, 0, Size - 1);
			}
		}

		public Game Move(int dx, int dy)
		{
			var point = GamePoints
				.Where(p => Data[p.X, p.Y] == 0)
				.Where(p => p.X + dx >= 0 && p.X + dx < Size && p.Y + dy >= 0 && p.Y + dy < Size)
				.FirstOrDefault();
			if (point == null) return null;

			var newGame = new Game(this);
			newGame.Data[point.X, point.Y] = Data[point.X + dx, point.Y + dy];
			newGame.Data[point.X + dx, point.Y + dy] = Data[point.X, point.Y];
			return newGame;
		}

		public IEnumerable<Game> AllAdjacentGames()
		{
			return Rectangle(-1, 1, -1, 1)
				.Where(point => point.X == 0 || point.Y == 0)
				.Select(point => Move(point.X, point.Y))
				.Where(game => game != null);
		}

		public override bool Equals(object obj)
		{
			var game = obj as Game;
			return GamePoints
				.All(point => Data[point.X, point.Y] == game.Data[point.X, point.Y]);
		}

		public override int GetHashCode()
		{
			return GamePoints
				.Select(point => Data[point.X, point.Y])
				.Aggregate((sum, val) => sum * 97 + val);
		}

		public void Print()
		{
			var str = GamePoints
				.GroupBy(z => z.X)
				.Select(row => row
				.Select(point => Data[point.X, point.Y].ToString())
				.Aggregate((a, b) => a + " " + b))
				.Aggregate((a, b) => a + "\n" + b);
			Console.WriteLine(str);
			Console.WriteLine();
		}
	}
}