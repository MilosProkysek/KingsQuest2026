using System;
using System.Collections.Generic;
using System.Text;

namespace KingsQuest2026.Data
{
    public class Game
    {
        public static Game Instance { get; } = new Game();

        public Room CurrentRoom { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Character> Characters { get; set; } = new List<Character>();
    }
}
