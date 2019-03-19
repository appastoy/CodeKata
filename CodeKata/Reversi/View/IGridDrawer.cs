using Reversi.Logic.Board;
using System;
using System.Collections.Generic;

namespace Reversi.View
{
	public interface IGridDrawer<TCell> : IDisposable
	{
		void Draw(IReadOnlyGrid<TCell> grid);
		void Draw(IReadOnlyGrid<TCell> grid, IEnumerable<Point> possibleMovePoints, TCell owner);
	}
}
