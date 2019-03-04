
using GameOfLife.View;
using System;

namespace GameOfLife
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Clear();
				if (!InputHandler.TryProcessInput(out var result))
				{
					Console.WriteLine("잘못된 입력입니다.");
					continue;
				}

				var cellGrid = CellGridStringConverter.ConvertFrom(result.Width, result.Height, result.CellGridLines);
				var simulator = new GameOfLifeSimulater(cellGrid);
				var outputLeft = Console.CursorLeft;
				var outputTop = Console.CursorTop;

				while (true)
				{
					Console.SetCursorPosition(outputLeft, outputTop);
					Console.WriteLine();

					var snapshot = simulator.Simulate();
					var cellGridLines = CellGridStringConverter.ConvertTo(snapshot.CellGrid);
					Console.WriteLine($"# Generation {snapshot.Generation}                ");
					Array.ForEach(cellGridLines, Console.WriteLine);
					Console.ReadKey();
				}
			}
		}
	}
}
