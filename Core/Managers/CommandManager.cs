using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Managers;

public static class CommandManager
{
    private static readonly Dictionary<string, Action<List<Entity>>> commands = new();

    static CommandManager()
    {
        commands.Add("open", obj => exec<Open>(obj));
        commands.Add("examine", obj => exec<Examine>(obj));
        commands.Add("inv", obj => Terminal.printInventory());
        commands.Add("use", obj => obj.Last().components.get<Used>().execute(obj.First()));
        commands.Add("up", obj => GameCreator.Instance.player.move(Direction.UP));
        commands.Add("right", obj => GameCreator.Instance.player.move(Direction.RIGHT));
        commands.Add("down", obj => GameCreator.Instance.player.move(Direction.DOWN));
        commands.Add("left", obj => GameCreator.Instance.player.move(Direction.LEFT));
        //shortcuts
        commands.Add("u", obj => commands["up"](obj));
        commands.Add("d", obj => commands["down"](obj));
        commands.Add("r", obj => commands["right"](obj));
        commands.Add("l", obj => commands["left"](obj));
    }

    private static void exec<T>(List<Entity> obj) where T : executor
    {
        if (obj.Count == 0) return;

        var parts = obj[0]?.components;
        if (parts == null) return;

        obj.First().components.execute<T>();
    }

    public static bool get(string str)
    {
        var parsedString = str.Split(' ');
        var operatorStr = parsedString.First();
        try
        {
            if (commands.ContainsKey(operatorStr))
            {
                var cleanedStr = parsedString.Skip(1).ToArray();
                if (cleanedStr.Length > 1) cleanedStr = [cleanedStr.First(), cleanedStr.Last()];

                commands[operatorStr](getOperands(cleanedStr));
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
        var player = GameCreator.Instance.player;
        foreach (var name in names)
        {
            var nameFound = autoComplete(name, player.getInventoryList().Select(obj => obj.name).ToList(),
                player.currentRoom.getEntityList().Select(entity => entity.name).ToList());
            var inventoryOperand = player.getFromInventory(nameFound);
            var roomOperand = player.currentRoom.getEntity(nameFound);
            if (inventoryOperand != null) result.Add(inventoryOperand);

            if (roomOperand != null) result.Add(roomOperand);
        }

        return result;
    }
}