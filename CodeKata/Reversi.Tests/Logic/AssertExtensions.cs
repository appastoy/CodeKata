using Reversi.Tests.Exceptions;

namespace Reversi.Logic.Tests
{
	static class AssertExtension
	{
		public static void Should_Be_Correct(this bool result)
		{
			if (!result) { throw new TestGridResultIncorrectException(); }
		}
	}
}
