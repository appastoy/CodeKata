
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife.View
{
	static class InputHandler
	{
		static Regex sizeFormat = new Regex(@"^(\d+) (\d+)$", RegexOptions.Multiline | RegexOptions.Compiled);

		public static bool TryProcessInput(out InputResult result)
		{
			result = new InputResult();

			if (!TryProcessInputForSize(out var width, out var height)) { return false; }
			if (!TryProcessInputForCellGridLines(width, height, out var cellGridLines)) { return false; }

			result = new InputResult(width, height, cellGridLines);

			return true;
		}

		static bool TryProcessInputForSize(out int width, out int height)
		{
			width = 0;
			height = 0;

			var input = Console.ReadLine();
			var match = sizeFormat.Match(input);
			if (!match.Success) { return false; }

			if (!int.TryParse(match.Groups[1].Value, out height)) { return false; }
			if (!int.TryParse(match.Groups[2].Value, out width)) { return false; }

			return true;
		}

		static bool TryProcessInputForCellGridLines(int width, int height, out string[] cellGridLines)
		{
			cellGridLines = new string[height];

			for (int i = 0; i < height; i++)
			{
				var input = Console.ReadLine();
				if (input.Length != width) { return false; }
				if (input.Any(ch => ch != ViewConstants.LiveCell && ch != ViewConstants.DieCell)) { return false; }

				cellGridLines[i] = input;
			}

			return true;
		}
	}
}
