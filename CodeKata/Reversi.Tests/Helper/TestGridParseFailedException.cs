using System;
using System.Diagnostics;

namespace Reversi.Tests.Exceptions
{
	class TestGridParseFailedException : Exception
	{
		public override string StackTrace { get; }

		public TestGridParseFailedException(int skipFrams = 3)
		{
			StackTrace = new StackTrace(skipFrams, true).ToString();
		}
	}
}
