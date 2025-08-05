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

    private static Entity strToEntity(String a)
    {
        return God.Instance.player.currentRoom.getEntity(a)!;
    }

    static CommandManager()
    {
        commands.Add("open", (a) => God.Instance.open(strToEntity(a[0])));
        commands.Add("examine", (a) => God.Instance.examine(strToEntity(a[0])));
        commands.Add("inv", (a) => God.Instance.inventory());
        commands.Add("use", (a) =>
        {
            if (a.Length == 3)
            {
                a[1] = a[2];
            }
            God.Instance.use(strToEntity(a[1]), a[0]);
        });

        commands.Add("save", (a) => strToEntity(a[0]));
        commands.Add("load", (a) => strToEntity(a[0]));
        commands.Add("up", (a) => God.Instance.move(Direction.up));
        commands.Add("right", (a) => God.Instance.move(Direction.right));
        commands.Add("down", (a) => God.Instance.move(Direction.down));
        commands.Add("left", (a) => God.Instance.move(Direction.left));
    }
}