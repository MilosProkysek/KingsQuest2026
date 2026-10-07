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

        public override void Print()
        {
            Console.WriteLine(this.Description);
            Console.Write("Postavy v mistnosti: ");
            foreach (Character c in this.Characters)
            {
                Console.Write($"{c.Name}\t");
            }
            Console.WriteLine();
        }
    }
}
