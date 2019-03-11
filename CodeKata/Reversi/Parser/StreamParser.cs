using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Reversi.Parser
{
	class StreamParser
	{
		static readonly Regex sizeFormat = new Regex(@"^(\d+) (\d+)$", RegexOptions.Multiline | RegexOptions.Compiled);

		readonly IReadOnlyCollection<char> availableCharacterSet;

		public StreamParser(IReadOnlyCollection<char> availableCharacterSet)
		{
			this.availableCharacterSet = availableCharacterSet;
		}

		public bool TryParse(TextReader stream, out string result)
		{
			result = null;

			if (!TryProcessInputForSize(stream, out var width, out var height)) { return false; }
			if (!TryProcessInputForCellGridLines(stream, width, height, out var stringLines)) { return false; }

			result = string.Join(Environment.NewLine, stringLines);

			return true;
		}

		bool TryProcessInputForSize(TextReader stream, out int width, out int height)
		{
			width = 0;
			height = 0;

			var input = stream.ReadLine();
			var match = sizeFormat.Match(input);
			if (!match.Success) { return false; }

			if (!int.TryParse(match.Groups[1].Value, out height)) { return false; }
			if (!int.TryParse(match.Groups[2].Value, out width)) { return false; }

			return true;
		}

		bool TryProcessInputForCellGridLines(TextReader stream, int width, int height, out string[] stringLines)
		{
			stringLines = new string[height];

			for (int i = 0; i < height; i++)
			{
				var input = stream.ReadLine();
				if (input.Length != width) { return false; }
				if (input.Any(ch => !availableCharacterSet.Contains(ch))) { return false; }

				stringLines[i] = input;
			}

			return true;
		}
	}
}
