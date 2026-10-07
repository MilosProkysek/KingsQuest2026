using System;
using System.Collections.Generic;
using System.Text;

namespace KingsQuest2026.Data
{
    public abstract class GameObject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public abstract void Print();
    }
}
