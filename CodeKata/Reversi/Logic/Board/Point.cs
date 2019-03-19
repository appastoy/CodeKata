using System;

namespace Reversi.Logic.Board
{
	public struct Point : IEquatable<Point>
	{
		public readonly int X;
		public readonly int Y;

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public bool Equals(Point other)
		{
			return X == other.X && Y == other.Y;
		}

		public override int GetHashCode()
		{
			var ulongX = (ulong)X << 32;
			var ulongValue = ulongX | (uint)Y;
			return ulongValue.GetHashCode();
		}
	}
}
