
namespace MineSweeper.View
{
	struct InputResult
	{
		public readonly string[] MineMapLines;
		public readonly bool IsGameEnd;

		public InputResult(string[] inputLines, bool isGameEnd)
		{
			MineMapLines = inputLines;
			IsGameEnd = isGameEnd;
		}
	}
}
