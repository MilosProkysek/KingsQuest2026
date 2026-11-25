using System;
using System.Collections.Generic;
using System.Text;

namespace KingsQuest2026.Shared
{
    public enum Command
    {
        UNKNOWN,
        GO,
        EXIT
    }

    public class CommandObject
    {
        public Command Command { get; set;}
        public List<IGameObject> arguments;
    }
}
