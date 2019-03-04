
namespace GameOfLife
{
	public class GameOfLifeSimulater
	{
		readonly GenerationContext[] generations;
		int generationCount;

		public GameOfLifeSimulater(bool[,] cellGrid)
		{
			generations = new GenerationContext[2];
			generations[0] = new GenerationContext(cellGrid);
			generations[1] = new GenerationContext(generations[0].Width, generations[0].Height);
		}

		public GenerationSnapshot Simulate()
		{
			var currGen = generations[generationCount % 2];
			var nextGen = generations[(generationCount + 1) % 2];

			for (int y = 1; y < currGen.Height - 1; y++)
			{
				for (int x = 1; x < currGen.Width - 1; x++)
				{
					int neighborLiveCellCount = currGen.GetNeighborLiveCellCount(x, y);
					if (currGen.IsCellLive(x, y))
					{
						nextGen.SetCellState(x, y, neighborLiveCellCount == 2 || neighborLiveCellCount == 3);
					}
					else
					{
						nextGen.SetCellState(x, y, neighborLiveCellCount == 3);
					}
				}
			}

			generationCount++;

			return new GenerationSnapshot(nextGen.Dump(), generationCount);
		}
	}
}
