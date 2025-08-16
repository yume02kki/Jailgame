using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Managers;

public static class CommandManager
{
    private static Dictionary<string, Action<List<Entity>?>> commander = new();
    private static Player player = GameCreator.Instance.player;

    static CommandManager()
    {
        void add(dynamic command, Action<List<Entity>> action) => commander.Add(command.ToString(), action);

        add(Commands.open, operands => execute<Open>(operands));
        add(Commands.use, operands => execute<Used>(operands.Last(), operands.First()));
        add(Commands.examine, operands => execute<Examine>(operands));
        add(Commands.inventory, _ => Terminal.printInventory());
        add(Commands.up, _ => player.move(Directions.UP));
        add(Commands.right, _ => player.move(Directions.RIGHT));
        add(Commands.down, _ => player.move(Directions.DOWN));
        add(Commands.left, _ => player.move(Directions.LEFT));

        //shortcuts
        add("u", commander[nameof(Commands.up)]);
        add("d", commander[nameof(Commands.down)]);
        add("r", commander[nameof(Commands.right)]);
        add("l", commander[nameof(Commands.left)]);
    }

    private static void execute<T>(params List<Entity> operands) where T : executor
    {
        if (operands.Count == 1)
        {
            operands.First().components.execute<T>();
        }
        else
        {
            operands.First().components.execute<T>(operands.Last());
        }
    }

    public static bool get(string str)
    {
        var parsedString = str.Split(' ');
        var operatorStr = parsedString.First();
        try
        {
            if (commander.ContainsKey(operatorStr))
            {
                var cleanedStr = parsedString.Skip(1).ToArray();
                if (cleanedStr.Length > 1) cleanedStr = [cleanedStr.First(), cleanedStr.Last()];

                commander[operatorStr](getOperands(cleanedStr));
                return true;
            }
        }
        catch (Exception exception) when (exception is InvalidCastException || exception is NullReferenceException)
        {
        }

        return false;
    }

    private static string autoComplete(string str, params List<string>[] lists)
    {
        if (str == "") return "";

        var list = lists.SelectMany(listTemp => listTemp).ToList();
        var filter = list.FindAll(word => word.StartsWith(str));
        switch (filter.Count)
        {
            case 0:
                Color.write($"# element \"[{str}]\" not found", ConsoleColor.DarkBlue, selective: true, newLine: true);
                return str;
            case 1:
                if (str != filter[0])
                    Color.write($"# AutoCompleted \"[{str}]\" => {highlight(str, filter[0])}", ConsoleColor.DarkBlue,
                        selective: true, newLine: true);

                return filter[0];
            default:
                Color.write($"# Element \"{str}\" too ambiguous <{Util.listToString(highlight(str, filter))}>",
                    ConsoleColor.DarkBlue, selective: true, newLine: true);
                return str;
        }
    }

    private static string highlight(string term, string filter)
    {
        List<string> fakeList = new();
        fakeList.Add(filter);
        return highlight(term, fakeList)[0];
    }

    private static List<string> highlight(string term, List<string> filtered)
    {
        filtered = filtered.Select(a => a.Insert(a.IndexOf(term), "[")).ToList();
        filtered = filtered.Select(a => a.Insert(a.IndexOf(term) + term.Length, "]")).ToList();
        return filtered;
    }

    private static List<Entity> getOperands(string[] names)
    {
        var result = new List<Entity>();
        foreach (var name in names)
        {
            var nameFound = autoComplete(name, player.getInventoryList().Select(entity => entity.name).ToList(),
                player.currentRoom.getEntityList().Select(entity => entity.name).ToList());
            var inventoryOperand = player.getFromInventory(nameFound);
            var roomOperand = player.currentRoom.getEntity(nameFound);
            if (inventoryOperand != null) result.Add(inventoryOperand);

            if (roomOperand != null) result.Add(roomOperand);
        }

        return result;
    }
}