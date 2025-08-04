using MazeGame.Entitys;

namespace MazeGame;

public static class CommandManager
{
    private static Dictionary<string, Action<String[]>> commands = new Dictionary<string, Action<String[]>>();

    private static String[] parser(string str)
    {
        return str.Split(' ');
    }

    public static Action? Get(string str)
    {
        String[] parsedString = parser(str);
        if (commands.ContainsKey(parsedString[0]))
        {
            return () => commands[parsedString[0]](parsedString.Skip(1).ToArray());
        }
        else
        {
            return null;
        }
    }

    private static Entity strToFunc(String[] a)
    {
        return God.Instance.player.currentRoom.getEntity(a[0])!;
    }

    static CommandManager()
    {
        commands.Add("open", (a) => God.Instance.open(strToFunc(a)));
        commands.Add("examine", (a) => God.Instance.examine(strToFunc(a)));
        commands.Add("inv", (a) => God.Instance.inventory());
        commands.Add("use", (a) => strToFunc(a));
        commands.Add("save", (a) => strToFunc(a));
        commands.Add("load", (a) => strToFunc(a));
        commands.Add("up", (a) => God.Instance.move(Direction.up));
        commands.Add("right", (a) => God.Instance.move(Direction.right));
        commands.Add("down", (a) => God.Instance.move(Direction.down));
        commands.Add("left", (a) => God.Instance.move(Direction.left));
    }
}