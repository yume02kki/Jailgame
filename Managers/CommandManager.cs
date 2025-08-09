using MazeGame.CommandInterfaces;
using MazeGame.Entitys;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame;

public static class CommandManager
{
    private static Dictionary<string, Action<List<Obj>>> commands = new();

    private static void exec<T>(List<Obj> obj) where T : Part
    {
        if (obj.Count == 0)
        {
            return;
        }

        PartsUsed? parts = obj[0]?.parts;
        if (parts == null)
        {
            return;
        }

        obj.First().parts.execute<T>();
    }

    static CommandManager()
    {
        commands.Add("open", obj => exec<Open>(obj));
        commands.Add("examine", obj => exec<Examine>(obj));
        commands.Add("inv", obj => TerminalManager.invPrint(LogicManager.Instance.player.getInvList()));
        commands.Add("use", obj => obj.First().parts.get<Use>().target = ((Iused)obj.Last()));
        commands.Add("up", obj => LogicManager.Instance.move(Direction.up));
        commands.Add("right", obj => LogicManager.Instance.move(Direction.right));
        commands.Add("down", obj => LogicManager.Instance.move(Direction.down));
        commands.Add("left", obj => LogicManager.Instance.move(Direction.left));
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
                commands[operatorStr](getOperands(parsedString.Skip(1).ToArray()));
                return true;
            }
        }
        catch (InvalidCastException ex)
        {
        }
        catch (NullReferenceException ex)
        {
        }

        return false;
    }

    private static string autocomplete(string str, params List<string>[] lists)
    {
        List<string> list = lists.SelectMany((a) => a).ToList();
        List<string> filter = list.FindAll((a) => a.StartsWith(str));
        switch (filter.Count)
        {
            case 0:
                Console.WriteLine($"#| element \"{str}\" not found");
                return str;
            case 1:
                Console.WriteLine($"#| AutoCompleted \"{str}\" => {filter[0]}");
                return filter[0];
            default:
                Console.WriteLine($"#| Element \"{str}\" too ambiguous <{Misc.commaList(filter)}>");
                return str;
        }
    }

    private static List<Obj> getOperands(string[] names)
    {
        List<Obj> result = new List<Obj>();
        Player player = LogicManager.Instance.player;
        foreach (string name in names)
        {
            string nameFound = autocomplete(name, player.getInvList().Select(obj => obj.Name).ToList(),
                player.currentRoom.getEntityList().Select(ent => ent.Name).ToList());
            Obj? a = player.getInv(nameFound);
            Obj? b = player.currentRoom.getEntity(nameFound);
            if (a != null)
            {
                result.Add(a);
            }

            if (b != null)
            {
                result.Add(b);
            }
        }

        return result;
    }
}