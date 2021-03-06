﻿using Reversi.Logic.Board;
using Reversi.Parser;
using Reversi.View;
using System;
using System.Collections.Generic;

namespace Reversi
{
	class Program
	{
		static void Main(string[] args)
		{
			var streamParser = new StreamParser(new char[] { '.', 'B', 'W' });
			var gridParser = new GridParser<CellColor>(new Dictionary<char, CellColor>()
			{
				{ '.', CellColor.Blank },
				{ 'W', CellColor.White },
				{ 'B', CellColor.Black }
			});
			var gridWriter = new GridTextDrawer<CellColor>(Console.Out, new Dictionary<CellColor, char>()
			{
				{ CellColor.Blank, '.' },
				{ CellColor.White, 'W' },
				{ CellColor.Black, 'B' }
			}, '0');

			while (true)
			{
				Console.Clear();

				if (!streamParser.TryParse(Console.In, out string streamResult)) { continue; }
				if (!gridParser.TryParse(streamResult, out var grid)) { continue; }

				Console.WriteLine();

				var owner = CellColor.Black;
				var finder = new PossibleMoveCellFinder(grid);
				var possibleMovePoints = finder.Find(owner);
				gridWriter.Draw(grid, possibleMovePoints, owner);

				Console.ReadKey();

				break;
			}
		}
	}
}
