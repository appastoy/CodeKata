namespace GameOfLife
{
	public struct GenerationSnapshot
	{
		public readonly bool[,] CellGrid;
		public readonly int Generation;

		public GenerationSnapshot(bool[,] cellGrid, int generation)
		{
			CellGrid = cellGrid;
			Generation = generation;
		}
	}
}
