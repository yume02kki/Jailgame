using MazeGame.Entitys;

namespace MazeGame;

public static class TerminalManager
{
    const String INFO_PHRASE = "You are in room \"{0}\". These are the things you see: [{1}]";

    public static void render(Player player)
    {
        string entityNames = player.currentRoom.getEntityList().Count > 0
            ? player.currentRoom.getEntityList().Select(e => e.ToString()).Aggregate((acc, next) => acc + ", " + next)
            : "";
        String phrase = String.Format(INFO_PHRASE, player.currentRoom, entityNames);
        Console.WriteLine(phrase);
        commandFetch();
    }

    public static void invPrint()
    {
        List<Obj> inventory =  LogicManager.Instance.player.getInvList();
        Console.WriteLine("[Inventory]: "+Util.commaList(inventory.Select(a => a.Name).ToList()));
    }

    public static void commandFetch()
    {
        bool validInput = false;
        while (!validInput)
        {
            Color.write("open | examine | use | inv | move | save | load",ConsoleColor.DarkMagenta,newLine:true);
            Console.Write("\n> ");
            validInput = CommandManager.get(Console.ReadLine() ?? "");
            if (!validInput)
            {
                Color.write("Invalid command, try again", ConsoleColor.Red,newLine:true);
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
                    Color.write(player.getRender());
                }
                else if (room.tryGet(x, y) != null)
                {
                    Color.write(room.tryGet(x, y)!.getRender());
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