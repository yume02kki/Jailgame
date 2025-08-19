using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Managers;
using MazeGame.MazeGame.Core.Utility;

namespace MazeGame.MazeGame.Presentation;

public static class Terminal
{
    private const string INFO_PHRASE = "You are in room \"{0}\". These are the things you see: [{1}]";
    public static Queue<Action> printBuffer = new Queue<Action>();

    public static void renderFrame(Player player)
    {
        var entityNames = player.currentNode.room.getEntityList().Count > 0
            ? player.currentNode.room.getEntityList().Select(entity => entity.ToString())
                .Aggregate((acc, next) => acc + ", " + next)
            : "";
        var phrase = string.Format(INFO_PHRASE, player.currentNode.room, entityNames);
        Console.WriteLine(phrase);
        commandFetch();
    }

    public static void printInventory()
    {
        var inventory = GameCreator.Instance.player.getInventoryList();
        printBuffer.Enqueue(() => Console.WriteLine("[Inventory]: " + Misc.listToString(inventory.Select(entity => entity.name).ToList())));
    }

    public static void commandFetch()
    {
        var validInput = false;
        string commandsString = string.Join(" | ", Enum.GetNames(typeof(Commands)).ToList());
        Color.write(commandsString, ConsoleColor.DarkMagenta, true);
        while (!validInput)
        {
            Console.Write("\n> ");
            validInput = CommandManager.get(Console.ReadLine() ?? "");
            if (!validInput) Color.write("Invalid command, try again", ConsoleColor.Red);
        }
    }

    public static void autoCompleteLog(List<string> filter, string str)
    {
        Action log = filter.Count switch
        {
            0 => () => Color.write($"# element \"[{str}]\" not found", ConsoleColor.DarkBlue, true, true),
            1 => () => Color.write($"# AutoCompleted \"[{str}]\" => {highlight(str, filter.First())}", ConsoleColor.DarkBlue, true, true),
            _ => () => Color.write($"# Element \"{str}\" too ambiguous <{Misc.listToString(highlight(str, filter))}>", ConsoleColor.DarkBlue, true, true)
        };

        printBuffer.Enqueue(log);
    }

    private static string highlight(string term, string filter)
    {
        List<string> fakeList = new();
        fakeList.Add(filter);
        return highlight(term, fakeList).First();
    }

    private static List<string> highlight(string term, List<string> filtered)
    {
        filtered = filtered.Select(a => a.Insert(a.IndexOf(term), "[")).ToList();
        filtered = filtered.Select(a => a.Insert(a.IndexOf(term) + term.Length, "]")).ToList();
        return filtered;
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
        var width = player.currentNode.room.getPlayareaWidth();
        var height = player.currentNode.room.getPlayareaHeight();
        for (var y = 0; y <= height; y++)
        {
            for (var x = 0; x <= width; x++)
            {
                var cursorPos = new IntVector2(x, y);
                var cursorEntity = player.currentNode.room.tryGet(cursorPos);

                if (cursorPos == player.pos) Color.write(player.render);
                else if (cursorEntity != null) Color.write(cursorEntity.components.read<Render, Renders>());
                else Console.Write(backgroundIcon(x, y, width, height));
            }


            Console.WriteLine();
        }
    }

    public static void loadNewFrame()
    {
        Console.Clear();
        while (printBuffer.Count > 0) printBuffer.Dequeue()();
    }
}