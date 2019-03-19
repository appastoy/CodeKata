using Reversi.Logic.Board;
using Reversi.Parser;
using Reversi.View;
using System;
using System.Collections.Generic;

namespace Reversi.Logic.Scene
{
	public class ConsoleTestScene : IScene
	{
		StreamParser streamParser;
		GridParser<CellColor> gridParser;
		IGridDrawer<CellColor> gridDrawer;

		public void Initialize()
		{
			streamParser = new StreamParser(new char[] { '.', 'B', 'W' });
			gridParser = new GridParser<CellColor>(new Dictionary<char, CellColor>()
			{
				{ '.', CellColor.Blank },
				{ 'W', CellColor.White },
				{ 'B', CellColor.Black }
			});
			gridDrawer = new GridTextDrawer<CellColor>(Console.Out, new Dictionary<CellColor, char>()
			{
				{ CellColor.Blank, '.' },
				{ CellColor.White, 'W' },
				{ CellColor.Black, 'B' }
			}, '0');
		}

		public void Update()
		{
			while (true)
			{
				Console.Clear();

				if (!streamParser.TryParse(Console.In, out string streamResult)) { continue; }
				if (!gridParser.TryParse(streamResult, out var grid)) { continue; }

				Console.WriteLine();

				var owner = CellColor.Black;
				var finder = new PossibleMoveCellFinder(grid);
				var possibleMovePoints = finder.Find(owner);
				gridDrawer.Draw(grid, possibleMovePoints, owner);

				Console.ReadKey();

				break;
			}
		}

		public void Release()
		{
			streamParser = null;
			gridParser = null;
			if (gridDrawer != null)
			{
				gridDrawer.Dispose();
				gridDrawer = null;
			}
		}
	}
}
