using KingsQuest2026.Data;

namespace KingsQuest2026.View
{
    public static class RoomView
    {
        public static void DisplayRoom(Room room)
        {
            Console.WriteLine(room.Description);
            Console.Write("Postavy v mistnosti: ");
            foreach (Character c in room.Characters)
            {
                Console.Write($"{c.Name}\t");
            }
            Console.WriteLine();
            Console.Write("Mistnosti, do kterych se muzes dostat: ");
            foreach (Room r in room.ConnectedRooms)
            {
                Console.Write($"{r.Name}\t");
            }
        }

    }
}
