using Reversi.Logic.Board;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reversi.View
{
	public class GridTextDrawer<TCell> : IGridDrawer<TCell>
	{
		readonly TextWriter stream;
		readonly IReadOnlyDictionary<TCell, char> cellCharacterMap;
		readonly char possibleMovePointCharacter;

		public GridTextDrawer(TextWriter stream, IReadOnlyDictionary<TCell, char> cellCharacterMap, char possibleMovePointCharacter)
		{
			this.stream = stream;
			this.cellCharacterMap = cellCharacterMap;
			this.possibleMovePointCharacter = possibleMovePointCharacter;
		}

		public void Draw(IReadOnlyGrid<TCell> grid)
		{
			DrawInternal(stream, grid, Array.Empty<Point>(), default(TCell));
		}

		public void Draw(IReadOnlyGrid<TCell> grid, IEnumerable<Point> possibleMovePoints, TCell owner)
		{
			DrawInternal(stream, grid, possibleMovePoints, owner);
		}

		void DrawInternal(TextWriter stream, IReadOnlyGrid<TCell> grid, IEnumerable<Point> possibleMovePoints, TCell owner)
		{
			var possibleMovePointSet = new HashSet<Point>(possibleMovePoints);
			for (int y = 0; y < grid.Height; y++)
			{
				for (int x = 0; x < grid.Width; x++)
				{
					if (possibleMovePointSet.Contains(new Point(x, y)))
					{
						stream.Write(possibleMovePointCharacter);
					}
					else
					{
						var cell = grid.GetCell(x, y);
						stream.Write(cellCharacterMap[cell]);
					}
				}
				stream.WriteLine();
			}
		}

		public string WriteToString(IReadOnlyGrid<TCell> grid)
		{
			return WriteToString(grid, Array.Empty<Point>(), default(TCell));
		}

		public string WriteToString(IReadOnlyGrid<TCell> grid, IEnumerable<Point> possibleMovePoints, TCell owner)
		{
			var builder = new StringBuilder((grid.Width + 2) * (grid.Height + 1));
			using (var stream = new StringWriter(builder))
			{
				DrawInternal(stream, grid, possibleMovePoints, owner);
				stream.Flush();
				return builder.ToString();
			}
		}
	}
}
