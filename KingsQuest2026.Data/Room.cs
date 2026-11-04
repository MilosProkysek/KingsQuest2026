using System;
using System.Collections.Generic;
using System.Text;

namespace KingsQuest2026.Data
{
    public class Room: GameObject
    {

        private List<Character> _characters;
        public List<Character> Characters
        {
            get
            {
                if (_characters == null) { _characters = new List<Character>(); }
                return _characters;
            }
        }

        private List<Room> _connectedRooms;
        public List<Room> ConnectedRooms
        {
            get
            {
                if (_connectedRooms == null) { _connectedRooms = new List<Room>(); }
                return _connectedRooms;
            }
        }        
    }
}
