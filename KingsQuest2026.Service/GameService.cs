using KingsQuest2026.Data;
using KingsQuest2026.Shared;
using KingsQuest2026.View;
using System.Diagnostics;

namespace KingsQuest2026.Service
{
    public class GameService
    {
        Game _game;

        public GameService(Game game)
        {
            Debug.WriteLine("<== GameService constructor ==>");
            _game = game;
        }

        public void InitGame()
        {
            Debug.WriteLine("<== Game initialization ==>");
            Room r = new Room()
            {
                Name = "Sal",
                Description = "To je krasny trunni sal. Je tu i krasny trun."
            };
            _game.Rooms.Add(r);

            Room z = new Room()
            {
                Name = "Zbrojnice",
                Description = "To je zbrojnice. Je tu spousta zbrani."
            };
            _game.Rooms.Add(z);

            // Connect rooms
            r.ConnectedRooms.Add(z);
            z.ConnectedRooms.Add(r);

            //characters
            Character king = new Character() { Name = "Kral", Description = "Mocny kral" };
            r.Characters.Add(king);

            //set first room
            _game.CurrentRoom = r;

            Debug.WriteLine("*** Game initialization done ***");
        }
        
        public void Run()
        {
            GeneralView.WelcomeMessage();

            while (true)
            {
                //GeneralView.DisplayMessage($"Ted jsi v:{GetCurrentRoom()}");
                RoomView.DisplayRoom(GetCurrentRoom());

                GeneralView.DisplayMessage("MSG_COMMAND_PROMPT");
                CommandObject commandObject = GeneralView.GetCommand();
                //string inputString = String.Empty;
                //inputString = Console.ReadLine();
                Command command = Command.UNKNOWN;
                //string[] commandArguments;

                //string commandArgument = string.Join(" ", commandArguments);

                    switch (commandObject.Command)
                    {
                        case Command.GO:
                            //GeneralView.DisplayMessage($"jdu do mistnosti: {commandArgument}");

                            //empty arguments check
                            if (commandObject.arguments.Count == 0)
                            {
                                GeneralView.DisplayMessage("MSG_ROOM_NO_ARGUMENTS");
                                break;
                            }

                            if (!MoveToRoom(commandObject.arguments[0]))
                            {
                                GeneralView.DisplayMessage("MSG_ROOM_NOT_FOUND");
                                break;
                            }

                            break;
                        case Command.EXIT:
                            return;
                    }
            }
        }

        public Room GetCurrentRoom()
        {
            return _game.CurrentRoom;
        }

        public bool MoveToRoom(IGameObject? newRoom)
        {
            if(newRoom ==null ) return false;

            Room currentRoom = _game.CurrentRoom;
            Room nextRoom = currentRoom.ConnectedRooms.Contains(newRoom) ? newRoom as Room : null;
            if (nextRoom != null)
            {
                _game.CurrentRoom = nextRoom;
                Debug.WriteLine($"Moved to room: {nextRoom.Name}");
                return true;
            }
            else
            {
                Debug.WriteLine($"Room does not exist.");
                return false;
            }
        }
    }
}