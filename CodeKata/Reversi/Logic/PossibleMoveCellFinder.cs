using System;
using System.Collections.Generic;
using System.Linq;

namespace Reversi.Logic
{
	public class PossibleMoveCellFinder
	{
		readonly Grid<CellColor> grid;

		public PossibleMoveCellFinder(Grid<CellColor> grid)
		{
			this.grid = grid;
		}

		/// <summary>
		/// Find effective cells.
		/// </summary>
		/// <param name="ownerColor">owner should be 'Black' or 'White'.</param>
		public IReadOnlyList<Point> Find(CellColor ownerColor)
		{
			if (ownerColor != CellColor.Black && ownerColor != CellColor.White)
			{
				throw new ArgumentException(nameof(ownerColor));
			}

			var possibleMovePoints = new HashSet<Point>();
			var enemyColor = GetOppsiteColor(ownerColor);
			for (int y = 0; y < grid.Height; y++)
			{
				for (int x = 0; x < grid.Width; x++)
				{
					if (grid.GetCell(x, y) == ownerColor)
					{
						CollectPossibleMoveCellArround(x, y, enemyColor, possibleMovePoints);
					}
				}
			}

			return possibleMovePoints.ToArray();
		}

		CellColor GetOppsiteColor(CellColor cell)
		{
			return (CellColor)((int)cell ^ 1);
		}

		void CollectPossibleMoveCellArround(int x, int y, CellColor enemyColor, HashSet<Point> possibleMoveCellPoints)
		{
			if (IsPossibleMoveCell(x, y, enemyColor, -2, -2)) { possibleMoveCellPoints.Add(new Point(x - 2, y - 2)); }
			if (IsPossibleMoveCell(x, y, enemyColor, -2,  0)) { possibleMoveCellPoints.Add(new Point(x - 2, y + 0)); }
			if (IsPossibleMoveCell(x, y, enemyColor, -2,  2)) { possibleMoveCellPoints.Add(new Point(x - 2, y + 2)); }
			if (IsPossibleMoveCell(x, y, enemyColor,  0, -2)) { possibleMoveCellPoints.Add(new Point(x + 0, y - 2)); }
			if (IsPossibleMoveCell(x, y, enemyColor,  0,  2)) { possibleMoveCellPoints.Add(new Point(x + 0, y + 2)); }
			if (IsPossibleMoveCell(x, y, enemyColor,  2, -2)) { possibleMoveCellPoints.Add(new Point(x + 2, y - 2)); }
			if (IsPossibleMoveCell(x, y, enemyColor,  2,  0)) { possibleMoveCellPoints.Add(new Point(x + 2, y + 0)); }
			if (IsPossibleMoveCell(x, y, enemyColor,  2,  2)) { possibleMoveCellPoints.Add(new Point(x + 2, y + 2)); }
		}

		bool IsPossibleMoveCell(int x, int y, CellColor enemyColor, int offsetX, int offsetY)
		{
			return IsEnemyColoredCell(x + (offsetX / 2), y + (offsetY / 2), enemyColor) && IsEmptyCell(x + offsetX, y + offsetY);
		}

		bool IsEnemyColoredCell(int x, int y, CellColor enemyColor)
		{
			if (!IsValidPoint(x, y)) { return false; }

			return grid.GetCell(x, y) == enemyColor;
		}

		bool IsEmptyCell(int x, int y)
		{
			if (!IsValidPoint(x, y)) { return false; }

			return grid.GetCell(x, y) == CellColor.Blank;
		}

		bool IsValidPoint(int x, int y)
		{
			if (x < 0 || x >= grid.Width) { return false; }
			if (y < 0 || y >= grid.Height) { return false; }

			return true;
		}

		
	}
}
