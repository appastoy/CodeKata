
namespace Reversi.Tests.Exceptions
{
	class TestGridParseFailedException : CustomException
	{
		public TestGridParseFailedException(int skipFrams = 3) : base(skipFrams)
		{
		}
	}
}
