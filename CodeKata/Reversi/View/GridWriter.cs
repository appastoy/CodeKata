using Reversi.Logic;
using System.Collections.Generic;
using System.IO;

namespace Reversi.View
{
	public class GridWriter<TCell>
	{
		readonly IReadOnlyDictionary<TCell, char> cellCharacterMap;
		readonly char possibleMovePointCharacter;

		public GridWriter(IReadOnlyDictionary<TCell, char> cellCharacterMap, char possibleMovePointCharacter)
		{
			this.cellCharacterMap = cellCharacterMap;
			this.possibleMovePointCharacter = possibleMovePointCharacter;
		}

		public void Write(TextWriter stream, IReadOnlyGrid<TCell> grid, IReadOnlyList<Point> possibleMovePoints, TCell owner)
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
			stream.WriteLine(owner.ToString()[0]);
		}
	}
}
