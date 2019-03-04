
namespace GameOfLife
{
	class GenerationContext
	{
		readonly bool[,] cellGrid;

		public int Width => cellGrid.GetLength(1);
		public int Height => cellGrid.GetLength(0);

		public GenerationContext(bool[,] cellGrid)
		{
			this.cellGrid = cellGrid;
			for (int x = 0; x < Width; x++)
			{
				cellGrid[0, x] = false;
				cellGrid[Height - 1, x] = false;
			}

			for (int y = 0; y < Height; y++)
			{
				cellGrid[y, 0] = false;
				cellGrid[y, Width - 1] = false;
			}
		}

		public GenerationContext(int width, int height)
		{
			cellGrid = new bool[height, width];
		}

		public bool IsCellLive(int x, int y)
		{
			if (x <= 0 || x >= Width - 1) { return false; }
			if (y <= 0 || y >= Height - 1) { return false; }

			return cellGrid[y, x];
		}

		public void SetCellState(int x, int y, bool live)
		{
			cellGrid[y, x] = live;
		}

		public int GetNeighborLiveCellCount(int x, int y)
		{
			int liveCellCount = 0;
			if (IsCellLive(x - 1, y - 1)) { liveCellCount++; }
			if (IsCellLive(x - 1, y)) { liveCellCount++; }
			if (IsCellLive(x - 1, y + 1)) { liveCellCount++; }
			if (IsCellLive(x, y - 1)) { liveCellCount++; }
			if (IsCellLive(x, y + 1)) { liveCellCount++; }
			if (IsCellLive(x + 1, y - 1)) { liveCellCount++; }
			if (IsCellLive(x + 1, y)) { liveCellCount++; }
			if (IsCellLive(x + 1, y + 1)) { liveCellCount++; }

			return liveCellCount;
		}

		public bool[,] Dump()
		{
			var dumpCellGrid = new bool[Height, Width];
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					dumpCellGrid[y, x] = cellGrid[y, x];
				}
			}

			return dumpCellGrid;
		}
	}
}
