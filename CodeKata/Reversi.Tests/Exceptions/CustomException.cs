using System;
using System.Diagnostics;

namespace Reversi.Tests
{
	public abstract class CustomException : Exception
	{
		public override string StackTrace { get; }

		public CustomException(int skipFrams)
		{
			StackTrace = new StackTrace(skipFrams, true).ToString();
		}
	}
}
