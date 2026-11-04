using System.Diagnostics;
using KingsQuest2026.Data;

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

        public Room GetCurrentRoom()
        {
            return _game.CurrentRoom;
        }

        public bool MoveToRoom(string roomName)
        {
            Room currentRoom = _game.CurrentRoom;
            Room nextRoom = currentRoom.ConnectedRooms.Find(x => x.Name.ToLower() == roomName.ToLower());
            if (nextRoom != null)
            {
                _game.CurrentRoom = nextRoom;
                Debug.WriteLine($"Moved to room: {nextRoom.Name}");
                return true;
            }
            else
            {
                Debug.WriteLine($"Room {roomName} does not exist.");
                return false;
            }
        }
    }
}