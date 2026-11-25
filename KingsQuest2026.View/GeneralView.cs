using KingsQuest2026.Data;
using KingsQuest2026.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsQuest2026.View
{
    public static class GeneralView
    {
        public static void DisplayMessage(string messageKey)
        {
            Console.WriteLine(L.Loc(messageKey));
        }

        public static CommandObject GetCommand()
        {
            Console.Write(L.Loc("PROMPT_COMMAND"));
            string inputString = Console.ReadLine();
            Command command = Command.UNKNOWN;
            string[] commandArguments = new string[0];
            CommandParser.Parse(inputString, out command, out commandArguments);
            List<IGameObject> argumentsObjects = new List<IGameObject>();
            foreach(string objectName in commandArguments)
            {
                IGameObject obj = GameObject.AllGameObjects.Find(x => x.Name.ToLower() == objectName.ToLower());
                if (obj != null)
                {
                    argumentsObjects.Add(obj);
                }
            }

            return new CommandObject() {Command = command, arguments = argumentsObjects};
        }

        public static void WelcomeMessage()
        {
            //Console.WriteLine(Language.ResourceManager.GetString("HELLO"));
            Console.WriteLine(L.Loc("MISSING_KEY"));
            Console.WriteLine(L.Loc("HELLO"));
        }
    }
}
