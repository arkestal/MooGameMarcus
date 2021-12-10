using System;
using System.IO;
using System.Collections.Generic;

namespace MooGameMarcus
{
	class Program
	{
		public static void Main(string[] args)
		{
			IUserInterface ui = new ConsoleIO();
			IFileRepository repository = new FileRepository();
			IGameLogic gameLogic = new GameLogic();
			Controller controller = new(ui, repository, gameLogic);
			controller.Run();
		}
	}

	
}	
