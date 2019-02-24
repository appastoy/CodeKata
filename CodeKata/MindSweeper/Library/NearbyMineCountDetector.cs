using System.Linq;

namespace MineSweeper.Library
{
	static class NearbyMineCountDetector
	{
		public static void Detect(MineGrid grid)
		{
			foreach (var mine in grid.Where(cell => cell.IsMine))
			{
				TryIncreaseCellNeighborNearbyMineCount(grid, mine.X, mine.Y);
			}
		}

		static void TryIncreaseCellNeighborNearbyMineCount(MineGrid grid, int x, int y)
		{
			TryIncreaseCellNearbyMineCount(grid, x - 1, y - 1);
			TryIncreaseCellNearbyMineCount(grid, x - 1, y);
			TryIncreaseCellNearbyMineCount(grid, x - 1, y + 1);
			TryIncreaseCellNearbyMineCount(grid, x, y - 1);
			TryIncreaseCellNearbyMineCount(grid, x, y);
			TryIncreaseCellNearbyMineCount(grid, x, y + 1);
			TryIncreaseCellNearbyMineCount(grid, x + 1, y - 1);
			TryIncreaseCellNearbyMineCount(grid, x + 1, y);
			TryIncreaseCellNearbyMineCount(grid, x + 1, y + 1);
		}

		static void TryIncreaseCellNearbyMineCount(MineGrid grid, int x, int y)
		{
			if (x < 0 || x >= grid.Width) { return; }
			if (y < 0 || y >= grid.Height) { return; }
			if (grid.IsMineCell(x, y)) { return; }

			grid.IncreaseCellNearbyMineCount(x, y);
		}
	}
}
