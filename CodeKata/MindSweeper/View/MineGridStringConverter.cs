using MineSweeper.Common;
using MineSweeper.Library;
using System;
using System.Text;

namespace MineSweeper.View
{
	static class MineGridStringConverter
	{
		public static string Convert(IMineGrid grid)
		{
			if (grid == null) { throw new ArgumentNullException(nameof(grid)); }
			if (grid.Width <= 0 || grid.Height <= 0) { return string.Empty; }

			var outputLines = new string[grid.Height];
			var builder = new StringBuilder(grid.Width);
			for (int y = 0; y < grid.Height; y++)
			{
				builder.Length = 0;
				for (int x = 0; x < grid.Width; x++)
				{
					if (grid.IsMineCell(x, y))
					{
						builder.Append(Constants.MineCharacter);
					}
					else
					{
						builder.Append(grid.GetNearbyMineCount(x, y));
					}
				}
				outputLines[y] = builder.ToString();
			}

			return string.Join(Environment.NewLine, outputLines);
		}
	}
}
