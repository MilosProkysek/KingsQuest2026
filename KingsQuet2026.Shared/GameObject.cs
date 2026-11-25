using System;
using System.Collections.Generic;
using System.Text;

namespace KingsQuest2026.Shared
{
    public abstract class GameObject : IGameObject
    {
        public static List<IGameObject> AllGameObjects = new List<IGameObject>();

        public GameObject()
        {
            AllGameObjects.Add(this);
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
