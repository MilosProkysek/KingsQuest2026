using KingsQuest2026.Data;
using KingsQuest2026.Service;
using KingsQuest2026.View;
using System.Diagnostics;
using System.Globalization;

namespace KingsQuest2026
{
    internal class Program
    {
        private enum Command
        {
            GO,
            EXIT,
            UNKNOWN
        }

        private static void Main(string[] args)
        {
            Game game = Game.Instance;
            GameService gameService = new GameService(game);
            gameService.InitGame();

            Game gameTest = Game.Instance;
            Debug.WriteLine($"Game rooms count:{gameTest.Rooms.Count}");
            //[DEBUG] culture info
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("cs-CZ");
            GeneralView.WelcomeMessage();

            while (true)
            {
                GeneralView.DisplayMessage($"Ted jsi v:{gameService.GetCurrentRoom()}");
                RoomView.DisplayRoom(gameService.GetCurrentRoom());

                GeneralView.DisplayMessage("MSG_COMMAND_PROMPT");
                string inputString = String.Empty;
                inputString = Console.ReadLine();
                Command command = Command.UNKNOWN;
                string commandArgument = string.Empty;

                //[DEBUG] hard coded command for testing
                ProcessInput(inputString, out command, out commandArgument);


                if (inputString != null)
                {
                    switch (command)
                    {
                        case Command.GO:
                            GeneralView.DisplayMessage($"jdu do mistnosti: {commandArgument}");
                            if (!gameService.MoveToRoom(commandArgument))
                            {
                                GeneralView.DisplayMessage($"Mistnost {commandArgument} neexistuje.");
                            }

                            break;
                        case Command.EXIT:
                            return;
                    }
                }
            }
        }

        private static void ProcessInput(string inputString, out Command command, out string commandArgument)
        {
            string[] inputStrings = inputString.Split(' ');
            string commandString = inputStrings[0].ToLower();

            command = Command.GO;
            commandArgument = inputStrings[1].ToString();
        }
    }
}