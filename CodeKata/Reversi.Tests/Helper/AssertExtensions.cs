using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Reversi.Logic.Tests
{
	static class AssertExtension
	{
		public static void Should_Be_Equal_To<T>(this IEnumerable<T> actual, params T[] expected)
		{
			CollectionAssert.AreEqual(expected, actual);
		}
	}
}
