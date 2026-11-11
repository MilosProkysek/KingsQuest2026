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

        public static void WelcomeMessage()
        {
            //Console.WriteLine(Language.ResourceManager.GetString("HELLO"));
            Console.WriteLine(L.Loc("MISSING_KEY"));
            Console.WriteLine(L.Loc("HELLO"));
        }
    }
}
