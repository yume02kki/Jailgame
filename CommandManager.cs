namespace MazeGame;

public static class CommandManager
{
    private static Dictionary<string,Action> commands = new Dictionary<string,Action>();

    private static String[] parser(string str)
    {
        return str.Split(' ');
    }
    public static Action? Get(string str)
    {
        return commands.GetValueOrDefault(parser(str)[0], null);
    }

    static CommandManager()
    {
        commands.Add("open", () => Console.WriteLine("<todo>"));
        commands.Add("examine", () => Console.WriteLine("<todo>"));
        commands.Add("use", () => Console.WriteLine("<todo>"));
        commands.Add("move", () => Console.WriteLine("<todo>"));
        commands.Add("save", () => Console.WriteLine("<todo>"));
        commands.Add("load", () => Console.WriteLine("<todo>"));
        commands.Add("up", () => Console.WriteLine("<todo>"));
        commands.Add("down", () => Console.WriteLine("<todo>"));
        commands.Add("left", () => Console.WriteLine("<todo>"));
        commands.Add("right", () => Console.WriteLine("<todo>"));
        
        
    }    
}