using GameOfLife.View;
using NUnit.Framework;

namespace GameOfLife.Tests
{
	[TestFixture()]
	public class GameOfLifeSimulaterTests
	{
		[Test()]
		public void SimulateTest1()
		{
			TestGameOfLife(8, 4, 
				new string[]
				{
					"........",
					"....*...",
					"...**...",
					"........"
				}, new string[]
				{
					"........",
					"...**...",
					"...**...",
					"........"
				});
		}

		void TestGameOfLife(int width, int height, string[] input, string[] output)
		{
			var cellGrid = CellGridStringConverter.ConvertFrom(width, height, input);
			var simulator = new GameOfLifeSimulater(cellGrid);
			var snapshot = simulator.Simulate();
			Assert.AreEqual(1, snapshot.Generation);

			var outputCellGridLines = CellGridStringConverter.ConvertTo(snapshot.CellGrid);
			CollectionAssert.AreEqual(output, outputCellGridLines);
		}
	}
}