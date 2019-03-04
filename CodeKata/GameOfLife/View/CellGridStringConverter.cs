using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.View
{
	public static class CellGridStringConverter
	{


		public static bool[,] ConvertFrom(int width, int height, IReadOnlyList<string> cellGridLines)
		{
			if (width <= 0) { throw new ArgumentException(nameof(width)); }
			if (height <= 0) { throw new ArgumentException(nameof(height)); }
			if (cellGridLines == null) { throw new ArgumentNullException(nameof(cellGridLines)); }
			if (cellGridLines.Count != height) { throw new ArgumentException(nameof(cellGridLines)); }
			if (cellGridLines.Any(line => line.Length != width)) { throw new ArgumentException(nameof(cellGridLines)); }

			var cellGrid = new bool[height, width];
			for (int y = 0; y < height; y++)
			{
				var line = cellGridLines[y];
				for (int x = 0; x < width; x++)
				{
					var cellCharacter = line[x];
					switch (cellCharacter)
					{
						case ViewConstants.LiveCell: cellGrid[y, x] = true; break;
						case ViewConstants.DieCell: cellGrid[y, x] = false; break;
						default: throw new ArgumentException(nameof(cellGridLines));
					}
				}
			}

			return cellGrid;
		}

		public static string[] ConvertTo(bool[,] cellGrid)
		{
			if (cellGrid == null) { throw new ArgumentNullException(nameof(cellGrid)); }
			if (cellGrid.LongLength <= 0) { throw new ArgumentException(nameof(cellGrid)); }

			var width = cellGrid.GetLength(1);
			var height = cellGrid.GetLength(0);
			var cellGridLines = new string[height];
			var builder = new StringBuilder(width);

			for (int y = 0; y < height; y++)
			{
				builder.Length = 0;
				for (int x = 0; x < width; x++)
				{
					builder.Append(cellGrid[y, x] ? ViewConstants.LiveCell : ViewConstants.DieCell);
				}
				cellGridLines[y] = builder.ToString();
			}

			return cellGridLines;
		}
	}
}
