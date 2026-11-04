using KingsQuest2026.Data;
using KingsQuest2026.View;

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

            Room z = new Room()
            {
                Name = "Zbrojnice",
                Description = "To je zbrojnice. Je tu spousta zbrani."
            };

            r.ConnectedRooms.Add(z);
            z.ConnectedRooms.Add(r);


            Character king = new Character() { Name = "Kral", Description = "Mocny kral" };
            r.Characters.Add(king);

            while (true)
            {
                GeneralView.DisplayMessage($"Ted jsi v:{r}");
                RoomView.DisplayRoom(r);

                GeneralView.DisplayMessage("Co chces delat?");
                string? inputString = Console.ReadLine();
                if (inputString != null)
                {
                    string[] inputStrings = inputString.Split(' ');
                    switch (inputStrings[0])
                    {
                        case "jdi":
                            GeneralView.DisplayMessage($"jdu do mistnosti: {inputStrings[1]}");
                            Room nextRoom = r.ConnectedRooms.Find(x => x.Name.ToLower() == inputStrings[1].ToLower());
                            if (nextRoom != null)
                            {
                                r = nextRoom;
                            }
                            else
                            {
                                GeneralView.DisplayMessage($"Mistnost {inputStrings[1]} neexistuje.");
                            }

                            break;
                        case "exit":
                            return;
                    }
                }

            }
        }
    }
}