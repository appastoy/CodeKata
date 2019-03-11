using Reversi.Parser;
using Reversi.Tests.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reversi.Logic.Tests
{
	public partial class PossibleMoveCellFinderTests
	{
		readonly GridParser<CellColor> gridParser = new GridParser<CellColor>(new Dictionary<char, CellColor>()
		{
			{ '.', CellColor.Blank },
			{ 'W', CellColor.White },
			{ 'B', CellColor.Black }
		});

		bool TestGrid(CellColor owner, params string[] textLines)
		{
			var text = string.Join(Environment.NewLine, textLines);
			var possiableMovePointIndices = CollectPossibleMovePointIndices(text);
			var replacedText = text.Replace('0', '.');
			if (!gridParser.TryParse(replacedText, out var grid))
			{
				throw new TestGridParseFailedException();
			}

			var possibleMovePointSet = possiableMovePointIndices.Select(index => new Point(index % grid.Width, index / grid.Width)).ToHashSet();
			var finder = new PossibleMoveCellFinder(grid);
			var foundPossibleMovePoints = finder.Find(owner);
			var foundPossibleMovePointSet = new HashSet<Point>(foundPossibleMovePoints);

			return foundPossibleMovePointSet.SetEquals(possibleMovePointSet);
		}

		IEnumerable<int> CollectPossibleMovePointIndices(string text)
		{
			var noNewLineText = text.Replace("\r\n", "\n").Replace("\n", "");
			var foundList = new List<int>();
			int startIndex = 0;
			while (true)
			{
				var found = noNewLineText.IndexOf('0', startIndex);
				if (found < 0) { break; }

				foundList.Add(found);
				startIndex = found + 1;
			}

			return foundList;
		}
	}
}
