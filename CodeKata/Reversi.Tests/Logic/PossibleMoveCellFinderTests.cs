using NUnit.Framework;

namespace Reversi.Logic.Tests
{
	[TestFixture()]
	public partial class PossibleMoveCellFinderTests
	{
		[Test()]
		public void FindTest()
		{
			TestGrid(CellColor.Black, ".").Should_Be_Correct();
			TestGrid(CellColor.Black, "B").Should_Be_Correct();
			TestGrid(CellColor.Black, "W").Should_Be_Correct();

			TestGrid(CellColor.Black, ".BW").Should_Be_Correct();
			TestGrid(CellColor.White, ".WB").Should_Be_Correct();
			TestGrid(CellColor.Black, ".BW0").Should_Be_Correct();
			TestGrid(CellColor.White, ".WB0").Should_Be_Correct();
			TestGrid(CellColor.Black, ".0WBW0").Should_Be_Correct();
			TestGrid(CellColor.White, ".0BWB0").Should_Be_Correct();

			TestGrid(CellColor.White, ".....",
									  "..W..",
									  ".WBW.",
									  "..W..",
									  ".....").Should_Be_Correct();

			TestGrid(CellColor.Black, "..0..",
									  "..W..",
									  "0WBW0",
									  "..W..",
									  "..0..").Should_Be_Correct();

			TestGrid(CellColor.White, ".....",
									  ".W.W.",
									  "..B..",
									  ".W.W.",
									  ".....").Should_Be_Correct();

			TestGrid(CellColor.Black, "0...0",
									  ".W.W.",
									  "..B..",
									  ".W.W.",
									  "0...0").Should_Be_Correct();

			TestGrid(CellColor.White, ".....",
									  ".WWW.",
									  ".WBW.",
									  ".WWW.",
									  ".....").Should_Be_Correct();

			TestGrid(CellColor.Black, "0.0.0",
									  ".WWW.",
									  "0WBW0",
									  ".WWW.",
									  "0.0.0").Should_Be_Correct();

			TestGrid(CellColor.Black, "..0.",
									  ".BW0",
									  "0WB.",
									  ".0..").Should_Be_Correct();
		}
	}
}