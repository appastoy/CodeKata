using NUnit.Framework;
using System;

namespace MineSweeper.Library.Tests
{
	[TestFixture()]
	public class MineGridGeneratorTests
	{
		[Test()]
		public void GenerateTest()
		{
			var input = new string[]
			{
				"*...",
				"....",
				".*..",
				"...."
			};

			var output = new int[,]
			{
				{ -1, 1, 0, 0 },
				{  2, 2, 1, 0 },
				{  1,-1, 1, 0 },
				{  1, 1, 1, 0 }
			};

			TestMineGridGenerating(4, 4, input, output);

			var input2 = new string[]
			{
				"**...",
				".....",
				".*..."
			};

			var output2 = new int[,]
			{
				{ -1,-1, 1, 0, 0 },
				{  3, 3, 2, 0, 0 },
				{  1,-1, 1, 0, 0 }
			};

			TestMineGridGenerating(5, 3, input2, output2);
		}

		void TestMineGridGenerating(int width, int height, string[] input, int[,] output)
		{
			var fields = MineGridGenerator.Generate(input);
			Assert.IsNotNull(fields);
			Assert.AreEqual(width, fields.Width);
			Assert.AreEqual(height, fields.Height);
			Assert.AreEqual(width * height, fields.Count);

			var fieldNearbyCountMap = new int[fields.Height, fields.Width];
			foreach (var field in fields)
			{
				fieldNearbyCountMap[field.Y, field.X] = field.IsMine ? -1 : field.NearbyMineCount;
			}

			for (int y = 0; y < fields.Height; y++)
			{
				for (int x = 0; x < fields.Width; x++)
				{
					Assert.AreEqual(output[y, x], fieldNearbyCountMap[y, x]);
				}
			}
		}
	}
}