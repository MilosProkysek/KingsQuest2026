using System;
using System.Collections.Generic;
using System.Globalization;

using KingsQuest2026.Shared;

namespace KingsQuest2026.View
{
    /// <summary>
    /// Parses user input into a command using localized names from resources.
    /// Each command needs a resource key "CMD_" + enum name. Aliases are separated by '|'.
    /// </summary>
    public static class CommandParser
    {
        private const string KeyPrefix = "CMD_";
        private const char AliasSeparator = '|';

        private static readonly Dictionary<string, Dictionary<string, Command>> _cache = new();

        /// <summary>
        /// Splits input on whitespace: the first word is the command, the rest are arguments.
        /// </summary>
        public static void Parse(string? input, out Command command, out string[] arguments)
        {
            command = Command.UNKNOWN;
            arguments = Array.Empty<string>();

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            string[] parts = input.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            string word = parts[0];
            arguments = parts[1..];

            if (GetLookup().TryGetValue(word, out Command found))
            {
                command = found;
            }
        }

        private static Dictionary<string, Command> GetLookup()
        {
            CultureInfo culture = CultureInfo.CurrentUICulture;
            lock (_cache)
            {
                if (_cache.TryGetValue(culture.Name, out var cached))
                {
                    return cached;
                }

                var lookup = new Dictionary<string, Command>(StringComparer.CurrentCultureIgnoreCase);
                foreach (Command cmd in Enum.GetValues<Command>())
                {
                    if (cmd == Command.UNKNOWN)
                    {
                        continue;
                    }

                    string? names = Language.ResourceManager.GetString(KeyPrefix + cmd, culture);
                    if (string.IsNullOrWhiteSpace(names))
                    {
                        continue;
                    }

                    foreach (string name in names.Split(AliasSeparator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                    {
                        lookup.TryAdd(name, cmd);
                    }
                }

                _cache[culture.Name] = lookup;
                return lookup;
            }
        }
    }
}
