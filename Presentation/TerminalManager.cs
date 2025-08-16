using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Core;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Managers;
using MazeGame.MazeGame.Core.Misc;

namespace MazeGame.MazeGame.Presentation;

public static class TerminalManager
{
    const String INFO_PHRASE = "You are in room \"{0}\". These are the things you see: [{1}]";

    public static void renderFrame(Player player)
    {
        string entityNames = player.currentRoom.getEntityList().Count > 0
            ? player.currentRoom.getEntityList().Select(entity => entity.ToString())
                .Aggregate((acc, next) => acc + ", " + next)
            : "";
        String phrase = String.Format(INFO_PHRASE, player.currentRoom, entityNames);
        Console.WriteLine(phrase);
        commandFetch();
    }

    public static void printInventory()
    {
        List<GameObject> inventory = GameCreator.Instance.player.getInventoryList();
        Console.WriteLine("[Inventory]: " +
                          Util.listToString(inventory.Select(gameObject => gameObject.name).ToList()));
    }

    public static void commandFetch()
    {
        bool validInput = false;
        while (!validInput)
        {
            Color.write("open | examine | use | inv | move | save | load", ConsoleColor.DarkMagenta, newLine: true);
            Console.Write("\n> ");
            validInput = CommandManager.get(Console.ReadLine() ?? "");
            if (!validInput)
            {
                Color.write("Invalid command, try again", ConsoleColor.Red, newLine: true);
            }
        }
    }

    public static void terminalUi(Player player)
    {
        Room room = player.currentRoom;
        int width = room.playAreaWidth();
        int height = room.playAreaHeight();
        IntVector2 scanIterator = new IntVector2(0, 0);
        for (scanIterator.Y = 0; scanIterator.Y <= height; scanIterator.Y++)
        {
            for (scanIterator.X = 0; scanIterator.X <= width; scanIterator.X++)
            {
                int x = scanIterator.X;
                int y = scanIterator.Y;
                if (scanIterator == player.pos)
                {
                    Color.write(player.render);
                }
                else if (room.tryGet(scanIterator) != null)
                {
                    Color.write(room.tryGet(scanIterator)!.components.read<Render, Renders>());
                }
                else if (y == 0 || y == height || x == 0 || x == width)
                {
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