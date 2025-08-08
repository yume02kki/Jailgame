using System.Text;
using MazeGame.Entitys;

namespace MazeGame;

public static class TerminalManager
{
    const String INFO_PHRASE = "You are in room {0}, These are the things you see: {1}";

    public static void render(Player player)
    {
        string entityNames = player.currentRoom.getEntityList().Count > 0
            ? player.currentRoom.getEntityList().Select(e => e.ToString()).Aggregate((acc, next) => acc + ", " + next)
            : "";
        String phrase = String.Format(INFO_PHRASE, player.currentRoom, entityNames);
        Console.WriteLine(phrase);
        commandFetch();
    }

    public static void commandFetch()
    {
        bool validInput = false;
        while (!validInput)
        {
            Console.WriteLine("Available commands: open, examine, use, inv, save, load");
            Console.Write("\n> ");
            validInput = CommandManager.get(Console.ReadLine() ?? "");
            if (!validInput)
            {
                Console.WriteLine("Invalid command, try again");
            }
        }
    }

    public static void tui(Player player)
    {
        Room room = player.currentRoom;
        int width = room.playAreaWidth();
        int height = room.playAreaHeight();
        for (int y = 0; y <= height; y++)
        {
            for (int x = 0; x <= width; x++)
            {
                if (player.x == x && player.y == y)
                {
                    Console.Write(player.icon());
                }
                else if (room.tryGet(x, y) != null)
                {
                    Console.Write(room.tryGet(x, y)!.icon());
                }
                else if (y == 0 || y == height || x == 0 || x == width)
                {
                    //nightmare
                    if (y == 0 && x == 0)
                        Console.Write("┌");
                    else if (y == 0 && x == width)
                        Console.Write("┐");
                    else if (y == height && x == 0)
                        Console.Write("└");
                    else if (y == height && x == width)
                        Console.Write("┘");
                    else if (y == 0 || y == height)
                        Console.Write("─");
                    else if (x == 0 || x == width) Console.Write("│");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }
    }
}