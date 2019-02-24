using System;

namespace MineSweeper.Library
{
	public interface IMineCell
	{
		int X { get; }
		int Y { get; }
		bool IsMine { get; }
		int NearbyMineCount { get; }
	}

	class MineCell : IMineCell
	{
		public static int Mine = -1;

		public static MineCell CreateMineCell(int x, int y) => new MineCell(x, y, Mine);
		public static MineCell CreateSafeCell(int x, int y) => new MineCell(x, y, 0);

		int value;

		public int X { get; }
		public int Y { get; }
		public bool IsMine => value == Mine;
		public int NearbyMineCount
		{
			get
			{
				if (IsMine) { throw new InvalidOperationException(); }

				return value;
			}
		}

		MineCell(int x, int y, int value)
		{
			X = x;
			Y = y;
			this.value = value;
		}

		public void IncreaseNearbyMineCount()
		{
			if (IsMine) { throw new InvalidOperationException(); }

			value++;
		}
	}
}
