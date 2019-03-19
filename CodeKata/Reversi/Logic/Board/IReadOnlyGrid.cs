
namespace Reversi.Logic.Board
{
	public interface IReadOnlyGrid<TCell>
	{
		int Width { get; }
		int Height { get; }

		TCell GetCell(int x, int y);
	}
}
