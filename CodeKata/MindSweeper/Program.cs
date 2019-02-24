using MineSweeper.Library;
using MineSweeper.View;
using System;

namespace MineSweeper
{
	class Program
	{
		static InputHandler inputHandler;

		static void Main(string[] args)
		{
			inputHandler = new InputHandler();
			while (true)
			{
				var inputLine = Console.ReadLine();
				if (!inputHandler.Handle(inputLine))
				{
					WriteAndReset("잘못된 입력입니다.");
				}
				else if (inputHandler.IsCompleted)
				{
					var result = inputHandler.GetResult();
					if (result.IsGameEnd) { break; }

					ProcessInputResult(result.MineMapLines);
				}
			}
		}

		static void ProcessInputResult(string[] mineMapLines)
		{
			var mineGrid = MineGridGenerator.Generate(mineMapLines);
			var mineGridString = MineGridStringConverter.Convert(mineGrid);
			Console.WriteLine();
			WriteAndReset(mineGridString);
		}

		static void WriteAndReset(string text)
		{
			Console.WriteLine(text);
			Console.ReadKey();
			Console.Clear();
			inputHandler.Reset();
		}
	}
}
