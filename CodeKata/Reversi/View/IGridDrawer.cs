using Reversi.Logic.Board;
using System.Collections.Generic;

namespace Reversi.View
{
	public interface IGridDrawer<TCell>
	{
		void Draw(IReadOnlyGrid<TCell> grid);
		void Draw(IReadOnlyGrid<TCell> grid, IEnumerable<Point> possibleMovePoints, TCell owner);
	}
}
