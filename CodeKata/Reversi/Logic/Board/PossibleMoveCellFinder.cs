using System;
using System.Collections.Generic;
using System.Linq;

namespace Reversi.Logic.Board
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
			var possibleMovePoint = new Point();
			if (TryGetPossibleMoveCell(x, y, enemyColor, -1, -1, out possibleMovePoint)) { possibleMoveCellPoints.Add(possibleMovePoint); }
			if (TryGetPossibleMoveCell(x, y, enemyColor, -1,  0, out possibleMovePoint)) { possibleMoveCellPoints.Add(possibleMovePoint); }
			if (TryGetPossibleMoveCell(x, y, enemyColor, -1,  1, out possibleMovePoint)) { possibleMoveCellPoints.Add(possibleMovePoint); }
			if (TryGetPossibleMoveCell(x, y, enemyColor,  0, -1, out possibleMovePoint)) { possibleMoveCellPoints.Add(possibleMovePoint); }
			if (TryGetPossibleMoveCell(x, y, enemyColor,  0,  1, out possibleMovePoint)) { possibleMoveCellPoints.Add(possibleMovePoint); }
			if (TryGetPossibleMoveCell(x, y, enemyColor,  1, -1, out possibleMovePoint)) { possibleMoveCellPoints.Add(possibleMovePoint); }
			if (TryGetPossibleMoveCell(x, y, enemyColor,  1,  0, out possibleMovePoint)) { possibleMoveCellPoints.Add(possibleMovePoint); }
			if (TryGetPossibleMoveCell(x, y, enemyColor,  1,  1, out possibleMovePoint)) { possibleMoveCellPoints.Add(possibleMovePoint); }
		}

		bool TryGetPossibleMoveCell(int x, int y, CellColor enemyColor, int directionX, int directionY, out Point possibleMovePoint)
		{
			bool existEnemyCell = false;
			int offsetX = directionX;
			int offsetY = directionY;

			while(IsEnemyColoredCell(x + offsetX, y + offsetY, enemyColor))
			{
				offsetX += directionX;
				offsetY += directionY;
				existEnemyCell = true;
			}

			if (existEnemyCell && IsEmptyCell(x + offsetX, y + offsetY))
			{
				possibleMovePoint = new Point(x + offsetX, y + offsetY);
				return true;
			}

			possibleMovePoint = new Point();

			return false;
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
