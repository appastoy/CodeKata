using System;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper.Library
{
	public interface IMineGrid : IEnumerable<IMineCell>
	{
		int Count { get; }
		int Width { get; }
		int Height { get; }

		bool IsMineCell(int x, int y);
		int GetNearbyMineCount(int x, int y);
	}

	class MineGrid : IMineGrid
	{
		readonly MineCell[,] cells;

		public int Width => cells.GetLength(1);
		public int Height => cells.GetLength(0);
		public int Count => Width * Height;
		
		public MineGrid(MineCell[,] cells) => this.cells = cells ?? throw new ArgumentNullException(nameof(cells));

		public bool IsMineCell(int x, int y) => cells[y, x].IsMine;
		public int GetNearbyMineCount(int x, int y) => cells[y, x].NearbyMineCount;
		public void IncreaseCellNearbyMineCount(int x, int y) => cells[y, x].IncreaseNearbyMineCount();

		public IEnumerator<IMineCell> GetEnumerator()
		{
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					yield return cells[y, x];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
