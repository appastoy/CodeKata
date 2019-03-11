using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi.Tests.Exceptions
{
	class TestGridResultIncorrectException : CustomException
	{
		public TestGridResultIncorrectException(int skipFrams = 3) : base(skipFrams)
		{
		}
	}
}
