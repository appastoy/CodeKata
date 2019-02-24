using MineSweeper.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MineSweeper.View
{
	class InputHandler
	{
		enum State
		{
			InputMapSize,
			InputMineMap,
			Completed
		}

		readonly Regex sizeFormat = new Regex(@"^(\d+)\s+(\d+)$", RegexOptions.Multiline | RegexOptions.Compiled);

		int width;
		int height;
		List<string> inputLines;
		State state;

		public bool IsCompleted => state == State.Completed;
		
		public bool Handle(string inputLine)
		{
			var inputLineTrimmed = inputLine.Trim();

			switch (state)
			{
				case State.InputMapSize:
					return ParseSize(inputLineTrimmed);

				case State.InputMineMap:
					return ParseMineMap(inputLineTrimmed);

				case State.Completed:
					return true;
			}

			throw new InvalidOperationException();
		}

		bool ParseSize(string inputLine)
		{
			if (inputLine == "0")
			{
				width = height = 0;
				inputLines = new List<string>();
				state = State.Completed;
				return true;
			}

			var match = sizeFormat.Match(inputLine);
			if (!match.Success)
			{
				return false;
			}

			try
			{
				height = int.Parse(match.Groups[1].Value);
				width = int.Parse(match.Groups[2].Value);

				if (width == 0 && height == 0)
				{
					inputLines = new List<string>();
					state = State.Completed;
				}
				else if (width * height > 0)
				{
					inputLines = new List<string>(height);
					state = State.InputMineMap;
				}
			}
			catch (Exception)
			{
				return false;
			}

			return IsCompleted || inputLines != null;
		}

		bool ParseMineMap(string inputLine)
		{
			if (inputLine.Length != width)
			{
				return false;
			}

			if (inputLine.Any(character => character != Constants.MineCharacter && character != Constants.SafeAreaCharacter))
			{
				return false;
			}

			inputLines.Add(inputLine);

			if (inputLines.Count >= height)
			{
				state = State.Completed;
			}
			return true;
		}

		public void Reset()
		{
			state = State.InputMapSize;
			width = height = 0;
			inputLines = null;
		}

		public InputResult GetResult()
		{
			if (!IsCompleted) { throw new InvalidOperationException(); }

			return new InputResult(inputLines.ToArray(), width == 0 && height == 0);
		}
	}
}
