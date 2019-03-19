using Reversi.Logic.Scene;

namespace Reversi.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var scene = new ConsoleTestScene();
			scene.Initialize();
			scene.Update();
			scene.Release();
		}
	}
}
