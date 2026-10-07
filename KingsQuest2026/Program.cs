using KingsQuest2026.Data;

namespace KingsQuest2026
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Room r = new Room()
            {
                Name = "Sal",
                Description = "To je krasny trunni sal. Je tu i krasny trun."
            };

            Character king = new Character() { Name = "Kral", Description = "Mocny kral" };
            r.Characters.Add(king);

            Console.WriteLine($"Ted jsi v:{r}");
            r.Print();
            
            while (true)
            {
                Console.WriteLine("Co chces delat?");
                string? inputString = Console.ReadLine();
                if (inputString != null)
                {
                    string[] inputStrings = inputString.Split(' ');
                    switch (inputStrings[0])
                    {
                        case "jdi":
                            Console.WriteLine($"jdu do mistnosti: {inputStrings[1]}");
                            break;
                        case "exit":
                            return;
                    }
                }

            }
        }
    }
}