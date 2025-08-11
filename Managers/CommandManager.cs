using System.Diagnostics;
using MazeGame.Entitys;
using MazeGame.MazeGame.CommandInterfaces;
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
        commands.Add("inv", obj => TerminalManager.invPrint());
        commands.Add("use", obj =>
        {
            Debugger.Break();
            obj.Last().parts.execute<Used>(obj.First());
        });
        commands.Add("up", obj => Creator.Instance.player.move(Direction.up));
        commands.Add("right", obj => Creator.Instance.player.move(Direction.right));
        commands.Add("down", obj => Creator.Instance.player.move(Direction.down));
        commands.Add("left", obj => Creator.Instance.player.move(Direction.left));
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
        if (str == "")
        {
            return "";
        }
        List<string> list = lists.SelectMany((a) => a).ToList();
        List<string> filter = list.FindAll((a) => a.StartsWith(str));
        switch (filter.Count)
        {
            case 0:
                Color.write($"# element \"[{str}]\" not found", ConsoleColor.DarkBlue,selective:true,newLine:true);
                return str;
            case 1:
                if (str != filter[0])
                {
                    Color.write($"# AutoCompleted \"[{str}]\" => {highlight(str,filter[0])}", ConsoleColor.DarkBlue,selective:true,newLine:true);
                }

                return filter[0];
            default:
                Color.write($"# Element \"{str}\" too ambiguous <{Util.commaList(highlight(str,filter))}>",ConsoleColor.DarkBlue,selective:true,newLine:true);
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
        filtered = filtered.Select(a => a.Insert(a.IndexOf(term),"[")).ToList();
        filtered = filtered.Select(a => a.Insert(a.IndexOf(term)+term.Length,"]")).ToList();

        return filtered;
    }
    
    private static List<Obj> getOperands(string[] names)
    {
        List<Obj> result = new List<Obj>();
        Player player = Creator.Instance.player;
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