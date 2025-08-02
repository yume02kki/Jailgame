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

    private static void tempFunc(String[] a)
    {
        Console.WriteLine($"ran <{String.Join(", ", a)}>");
    }

    static CommandManager()
    {
        commands.Add("open", (a) => tempFunc(a));
        commands.Add("examine", (a) => tempFunc(a));
        commands.Add("inventory", (a) => tempFunc(a));
        commands.Add("use", (a) => tempFunc(a));
        commands.Add("save", (a) => tempFunc(a));
        commands.Add("load", (a) => tempFunc(a));
        commands.Add("up", (a) => tempFunc(a));
        commands.Add("down", (a) => tempFunc(a));
        commands.Add("left", (a) => tempFunc(a));
        commands.Add("right", (a) => tempFunc(a));
    }
}