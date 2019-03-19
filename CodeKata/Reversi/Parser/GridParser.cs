using Reversi.Logic.Board;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reversi.Parser
{
	public class GridParser<TCell>
	{
		readonly IReadOnlyDictionary<char, TCell> characterCellMap;

		public GridParser(IReadOnlyDictionary<char, TCell> characterCellMap)
		{
			this.characterCellMap = characterCellMap;
		}

		public bool TryParse(string input, out Grid<TCell> grid)
		{
			grid = null;
			if (input == null || input.Length == 0) { return false; }

			var stringLines = input.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(line => line.Trim()).ToArray();
			if (!TryParseSize(stringLines, out var width, out var height)) { return false; }

			grid = CreateGrid(width, height, stringLines);

			return true;
		}

		bool TryParseSize(string[] stringLines, out int width, out int height)
		{
			width = 0;
			height = stringLines.Length;
			if (height == 0) { return false; }

			var uniqueWidth = stringLines[0].Length;
			if (stringLines.Skip(1).Any(line => line.Length != uniqueWidth)) { return false; }
			width = uniqueWidth;

			return true;
		}

		private Grid<TCell> CreateGrid(int width, int height, string[] stringLines)
		{
			var cells = new TCell[height, width];
			for (int y = 0; y < height; y++)
			{
				var stringLine = stringLines[y];
				for (int x = 0; x < width; x++)
				{
					cells[y, x] = characterCellMap[stringLine[x]];
				}
			}

			return new Grid<TCell>(cells);
		}
	}
}
