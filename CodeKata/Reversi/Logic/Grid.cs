using System;

namespace Reversi.Logic
{
	public class Grid<TCell> : IReadOnlyGrid<TCell>
	{
		readonly TCell[,] cells;

		public int Width => cells.GetLength(1);
		public int Height => cells.GetLength(0);

		public Grid(TCell[,] cells)
		{
			this.cells = cells ?? throw new ArgumentNullException(nameof(cells));
		}

		public TCell GetCell(int x, int y) => cells[y, x];
		public void SetCell(int x, int y, TCell cell) => cells[y, x] = cell;
	}
}
