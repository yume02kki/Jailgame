using MazeGame.CommandInterfaces;
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
        return LogicManager.Instance.player.currentRoom.getEntity(a)!;
    }

    static CommandManager()
    {
        commands.Add("open", (a) => ((Iopen)strToEntity(a[0])).open());
        commands.Add("examine", (a) => ((Iexamine)strToEntity(a[0])).examine());
        commands.Add("inv", (a) => LogicManager.Instance.inventory());
        commands.Add("use", (a) =>
        {
            if (a.Length == 3)
            {
                a[1] = a[2];
            }

            ((Iuse)strToEntity(a[1])).use(a[0]);
        });

        commands.Add("save", (a) => strToEntity(a[0]));
        commands.Add("load", (a) => strToEntity(a[0]));
        commands.Add("up", (a) => LogicManager.Instance.move(Direction.up));
        commands.Add("right", (a) => LogicManager.Instance.move(Direction.right));
        commands.Add("down", (a) => LogicManager.Instance.move(Direction.down));
        commands.Add("left", (a) => LogicManager.Instance.move(Direction.left));
    }
}