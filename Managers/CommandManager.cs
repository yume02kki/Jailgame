using MazeGame.CommandInterfaces;
using MazeGame.Entitys;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame;

public static class CommandManager
{
    private static Dictionary<string, Action<List<Obj>>> commands = new();

    private static void exec<T>(List<Obj> obj) where T : Part
    {
        obj.First().parts.execute<T>();
    }

    static CommandManager()
    {
        commands.Add("open", obj => exec<Open>(obj));
        commands.Add("examine", obj => exec<Examine>(obj));
        commands.Add("inv", obj => Console.WriteLine("you have: " + LogicManager.Instance.player.invString()));
        commands.Add("use", obj => obj.First().parts.get<Use>().target = ((Iused)obj.Last()));
        commands.Add("up", obj => LogicManager.Instance.move(Direction.up));
        commands.Add("right", obj => LogicManager.Instance.move(Direction.right));
        commands.Add("down", obj => LogicManager.Instance.move(Direction.down));
        commands.Add("left", obj => LogicManager.Instance.move(Direction.left));
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

    private static List<Obj> getOperands(string[] names)
    {
        List<Obj> result = new List<Obj>();
        foreach (string name in names)
        {
            Obj? a = (LogicManager.Instance.player.getInv(name));
            Obj? b = (LogicManager.Instance.player.currentRoom.getEntity(name));
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