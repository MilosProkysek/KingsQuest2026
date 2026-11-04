using KingsQuest2026.Data;
using KingsQuest2026.Service;
using KingsQuest2026.View;
using System.Diagnostics;

namespace KingsQuest2026
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = Game.Instance;
            GameService gameService = new GameService(game);
            gameService.InitGame();

            Game gameTest = Game.Instance;
            Debug.WriteLine($"Game rooms count:{gameTest.Rooms.Count}");

            while (true)
            {
                GeneralView.DisplayMessage($"Ted jsi v:{gameService.GetCurrentRoom()}");
                RoomView.DisplayRoom(gameService.GetCurrentRoom());

                GeneralView.DisplayMessage("Co chces delat?");
                string? inputString = Console.ReadLine();
                if (inputString != null)
                {
                    string[] inputStrings = inputString.Split(' ');
                    switch (inputStrings[0])
                    {
                        case "jdi":
                            GeneralView.DisplayMessage($"jdu do mistnosti: {inputStrings[1]}");                            
                            if (!gameService.MoveToRoom(inputStrings[1]))
                            { 
                                GeneralView.DisplayMessage($"Mistnost {inputStrings[1]} neexistuje.");
                            }

                            break;
                        case "exit":
                            return;
                    }
                }
            }
        }
    }
}