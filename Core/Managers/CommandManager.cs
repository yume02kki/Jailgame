using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Misc;
using MazeGame.MazeGame.Core.Module;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Managers;

public static class CommandManager
{
    private static Dictionary<string, Action<List<GameObject>>> commands = new();

    private static void exec<T>(List<GameObject> obj) where T : Writer
    {
        if (obj.Count == 0)
        {
            return;
        }

        CompsUsed? parts = obj[0]?.components;
        if (parts == null)
        {
            return;
        }

        obj.First().components.execute<T>();
    }

    static CommandManager()
    {
        commands.Add("open", obj => exec<Open>(obj));
        commands.Add("examine", obj => exec<Examine>(obj));
        commands.Add("inv", obj => TerminalManager.printInventory());
        commands.Add("use", obj => obj.Last().components.get<Used>().execute(obj.First()));
        commands.Add("up", obj => GameCreator.Instance.player.move(Direction.up));
        commands.Add("right", obj => GameCreator.Instance.player.move(Direction.right));
        commands.Add("down", obj => GameCreator.Instance.player.move(Direction.down));
        commands.Add("left", obj => GameCreator.Instance.player.move(Direction.left));
        //shortcuts
        commands.Add("u", obj => commands["up"](obj));
        commands.Add("d", obj => commands["down"](obj));
        commands.Add("r", obj => commands["right"](obj));
        commands.Add("l", obj => commands["left"](obj));
    }

    public static bool get(string str)
    {
        string[] parsedString = str.Split(' ');
        string operatorStr = parsedString.First();
        try
        {
            if (commands.ContainsKey(operatorStr))
            {
                string[] cleanedStr = parsedString.Skip(1).ToArray();
                if (cleanedStr.Length > 1)
                {
                    cleanedStr = [cleanedStr.First(), cleanedStr.Last()];
                }

                commands[operatorStr](getOperands(cleanedStr));
                return true;
            }
        }
        catch (Exception exception) when (exception is InvalidCastException || exception is NullReferenceException)
        {
        }

        return false;
    }

    private static string autocomplete(string str, params List<string>[] lists)
    {
        if (str == "")
        {
            return "";
        }

        List<string> list = lists.SelectMany(listTemp => listTemp).ToList();
        List<string> filter = list.FindAll(word => word.StartsWith(str));
        switch (filter.Count)
        {
            case 0:
                Color.write($"# element \"[{str}]\" not found", ConsoleColor.DarkBlue, selective: true, newLine: true);
                return str;
            case 1:
                if (str != filter[0])
                {
                    Color.write($"# AutoCompleted \"[{str}]\" => {highlight(str, filter[0])}", ConsoleColor.DarkBlue,
                        selective: true, newLine: true);
                }

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

    private static List<GameObject> getOperands(string[] names)
    {
        List<GameObject> result = new List<GameObject>();
        Player player = GameCreator.Instance.player;
        foreach (string name in names)
        {
            string nameFound = autocomplete(name, player.getInventoryList().Select(obj => obj.name).ToList(),
                player.currentRoom.getEntityList().Select(entity => entity.name).ToList());
            GameObject? inventoryOperand = player.getFromInventory(nameFound);
            GameObject? roomOperand = player.currentRoom.getEntity(nameFound);
            if (inventoryOperand != null)
            {
                result.Add(inventoryOperand);
            }

            if (roomOperand != null)
            {
                result.Add(roomOperand);
            }
        }

        return result;
    }
}