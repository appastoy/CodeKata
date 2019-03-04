using System.Collections.Generic;

namespace GameOfLife.View
{
	struct InputResult
	{
		public readonly int Width;
		public readonly int Height;
		public readonly IReadOnlyList<string> CellGridLines;

		public InputResult(int width, int height, IReadOnlyList<string> cellGridLines)
		{
			Width = width;
			Height = height;
			CellGridLines = cellGridLines;
		}
	}
}
