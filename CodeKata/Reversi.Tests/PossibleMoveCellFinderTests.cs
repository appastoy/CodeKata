using NUnit.Framework;
using Reversi.Logic.Board;
using Reversi.Parser;
using Reversi.Tests.Exceptions;
using Reversi.View;
using System;
using System.Collections.Generic;

namespace Reversi.Logic.Tests
{
	[TestFixture()]
	public class PossibleMoveCellFinderTests
	{
		readonly GridParser<CellColor> gridParser = new GridParser<CellColor>(new Dictionary<char, CellColor>()
		{
			{ '.', CellColor.Blank },
			{ 'W', CellColor.White },
			{ 'B', CellColor.Black }
		});
		readonly GridTextDrawer<CellColor> gridWriter = new GridTextDrawer<CellColor>(null, new Dictionary<CellColor, char>()
		{
			{ CellColor.Blank, '.' },
			{ CellColor.White, 'W' },
			{ CellColor.Black, 'B' }
		}, '0');

		[Test()]
		public void FindPossibleMoveCell1d()
		{
			MarkPossibleMovePoints(CellColor.Black, ".").Should_Be_Equal_To(".");
			MarkPossibleMovePoints(CellColor.Black, "B").Should_Be_Equal_To("B");
			MarkPossibleMovePoints(CellColor.Black, "W").Should_Be_Equal_To("W");
			MarkPossibleMovePoints(CellColor.Black, ".BW").Should_Be_Equal_To(".BW");
			MarkPossibleMovePoints(CellColor.White, ".WB").Should_Be_Equal_To(".WB");
			MarkPossibleMovePoints(CellColor.Black, ".BW.").Should_Be_Equal_To(".BW0");
			MarkPossibleMovePoints(CellColor.Black, ".BWW.").Should_Be_Equal_To(".BWW0");
			MarkPossibleMovePoints(CellColor.White, ".WB.").Should_Be_Equal_To(".WB0");
			MarkPossibleMovePoints(CellColor.White, ".WBB.").Should_Be_Equal_To(".WBB0");
			MarkPossibleMovePoints(CellColor.Black, "..WBW.").Should_Be_Equal_To(".0WBW0");
			MarkPossibleMovePoints(CellColor.Black, "..WBBW.").Should_Be_Equal_To(".0WBBW0");
			MarkPossibleMovePoints(CellColor.Black, "..WWBBWW.").Should_Be_Equal_To(".0WWBBWW0");
			MarkPossibleMovePoints(CellColor.White, "..BWB.").Should_Be_Equal_To(".0BWB0");
			MarkPossibleMovePoints(CellColor.White, "..BWWB.").Should_Be_Equal_To(".0BWWB0");
			MarkPossibleMovePoints(CellColor.White, "..BBWWBB.").Should_Be_Equal_To(".0BBWWBB0");
		}

		[Test()]
		public void FindPossibleMoveCell2d()
		{
			MarkPossibleMovePoints(CellColor.Black,
									"....",
									".BW.",
									".WB.",
									"....")
									.Should_Be_Equal_To(
									"..0.",
									".BW0",
									"0WB.",
									".0..");

			MarkPossibleMovePoints(CellColor.Black,
									".....",
									"..W..",
									".WBW.",
									"..W..",
									".....")
									.Should_Be_Equal_To(
									"..0..",
									"..W..",
									"0WBW0",
									"..W..",
									"..0..");

			MarkPossibleMovePoints(CellColor.Black,
									".....",
									".W.W.",
									"..B..",
									".W.W.",
									".....")
									.Should_Be_Equal_To(
									"0...0",
									".W.W.",
									"..B..",
									".W.W.",
									"0...0");

			MarkPossibleMovePoints(CellColor.Black,
									".....",
									".WWW.",
									".WBW.",
									".WWW.",
									".....")
									.Should_Be_Equal_To(
									"0.0.0",
									".WWW.",
									"0WBW0",
									".WWW.",
									"0.0.0");

			MarkPossibleMovePoints(CellColor.Black,
									".....",
									".WWW.",
									".WWB.",
									".WWW.",
									".....")
									.Should_Be_Equal_To(
									".0.0.",
									".WWW.",
									"0WWB.",
									".WWW.",
									".0.0.");
		}

		string[] MarkPossibleMovePoints(CellColor owner, params string[] textLines)
		{
			var text = string.Join(Environment.NewLine, textLines);
			if (!gridParser.TryParse(text, out var grid))
			{
				throw new TestGridParseFailedException();
			}

			var finder = new PossibleMoveCellFinder(grid);
			var possibleMovePoints = finder.Find(owner);
			var output = gridWriter.WriteToString(grid, possibleMovePoints, owner);

			return output.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
		}
	}
}