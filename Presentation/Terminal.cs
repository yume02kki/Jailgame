using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Managers;

namespace MazeGame.MazeGame.Presentation;

public static class Terminal
{
    private const string INFO_PHRASE = "You are in room \"{0}\". These are the things you see: [{1}]";

    public static void renderFrame(Player player)
    {
        var entityNames = player.currentRoom.getEntityList().Count > 0
            ? player.currentRoom.getEntityList().Select(entity => entity.ToString())
                .Aggregate((acc, next) => acc + ", " + next)
            : "";
        var phrase = string.Format(INFO_PHRASE, player.currentRoom, entityNames);
        Console.WriteLine(phrase);
        commandFetch();
    }

    public static void printInventory()
    {
        var inventory = GameCreator.Instance.player.getInventoryList();
        Console.WriteLine("[Inventory]: " + Util.listToString(inventory.Select(entity => entity.name).ToList()));
    }

    public static void commandFetch()
    {
        var validInput = false;
        while (!validInput)
        {
            string commandsString = string.Join(" | ", Enum.GetNames(typeof(Commands)).ToList());
            Color.write(commandsString, ConsoleColor.DarkMagenta, true);
            Console.Write("\n> ");
            validInput = CommandManager.get(Console.ReadLine() ?? "");
            if (!validInput) Color.write("Invalid command, try again", ConsoleColor.Red, true);
        }
    }

    private static char backgroundIcon(int x, int y, int width, int height)
    {
        if (x == 0 && y == 0) return '╔';
        if (x == width && y == 0) return '╗';
        if (x == 0 && y == height) return '╚';
        if (x == width && y == height) return '╝';
        if (y == 0 || y == height) return '═';
        if (x == 0 || x == width) return '║';
        return ' ';
    }

    public static bool isBorder(int x, int y, int width, int height) => y == 0 || y == height || x == 0 || x == width;

    public static void terminalUI(Player player)
    {
        var width = player.currentRoom.playAreaWidth();
        var height = player.currentRoom.playAreaHeight();
        for (var y = 0; y <= height; y++)
        {
            for (var x = 0; x <= width; x++)
            {
                var cursorPos = new IntVector2(x, y);
                var cursorEntity = player.currentRoom.tryGet(cursorPos);

                if (cursorPos == player.pos) Color.write(player.render);
                else if (cursorEntity != null) Color.write(cursorEntity.components.read<Render, Renders>());
                else Console.Write(backgroundIcon(x, y, width, height));
            }

            Console.WriteLine();
        }
    }
}