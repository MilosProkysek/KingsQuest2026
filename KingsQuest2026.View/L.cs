using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace KingsQuest2026.View
{
    internal static class L
    {
        public static string Loc(string key)
        {
            string localizedString = Language.ResourceManager.GetString(key);
            if(localizedString == null)
            {
                localizedString = $"[{key}]";
            }

            return localizedString;
        }
    }
}
