using KingsQuest2026.Data;
using KingsQuest2026.Service;
using KingsQuest2026.View;
using System.Diagnostics;
using System.Globalization;

namespace KingsQuest2026
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = Game.Instance;
            GameService gameService = new GameService(game);
            gameService.InitGame();

            //[DEBUG] culture info
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("cs-CZ");

            gameService.Run();
        }

    }
}