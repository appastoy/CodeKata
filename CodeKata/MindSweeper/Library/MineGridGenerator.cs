using MineSweeper.Common;
using System;
using System.Linq;

namespace MineSweeper.Library
{
	public static class MineGridGenerator
	{
		public static IMineGrid Generate(string[] mineMapLines)
		{
			var mineGrid = CreateMineGrid(mineMapLines);
			NearbyMineCountDetector.Detect(mineGrid);

			return mineGrid;
		}

		static MineGrid CreateMineGrid(string[] mineMapLines)
		{
			if (mineMapLines == null) { throw new ArgumentNullException(nameof(mineMapLines)); }
			if (mineMapLines.Select(line => line.Length).Distinct().Count() != 1) { throw new ArgumentException(nameof(mineMapLines)); }

			int width = mineMapLines.Select(line => line.Length).Distinct().First();
			int height = mineMapLines.Length;
			var cellList = new MineCell[height, width];
			for (int y = 0; y < height; y++)
			{
				var mineMapLine = mineMapLines[y];
				for (int x = 0; x < width; x++)
				{
					var mineMapCharacter = mineMapLine[x];
					if (mineMapCharacter == Constants.MineCharacter)
					{
						cellList[y, x] = MineCell.CreateMineCell(x, y);
					}
					else
					{
						cellList[y, x] = MineCell.CreateSafeCell(x, y);
					}
				}
			}

			return new MineGrid(cellList);
		}
	}
}
