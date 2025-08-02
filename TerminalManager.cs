using MazeGame.Entitys;

namespace MazeGame;

public static class TerminalManager
{
    const String INFO_PHRASE = "You are in room {0}, These are the things you see: {1}";

    public static void render(Player player)
    {
        
        string entityNames = player.currentRoom.getEntityList().Count>0?player.currentRoom.getEntityList().Select(e => e.ToString())
            .Aggregate((acc, next) => acc + ", " + next):"";
        String phrase = String.Format(INFO_PHRASE, player.currentRoom, entityNames);
        Console.WriteLine(phrase);
        commandFetch();
    }

    public static void commandFetch()
    {
        Boolean validInput = false;
        while (!validInput)
        {
            Console.WriteLine("Available commands: open, examine, use, <direction>, save, load.");
            Console.Write("\n> ");
            Action? action = CommandManager.Get(Console.ReadLine() ?? "");
            if (action != null)
            {
                action();
                validInput = true;
            }
            else
            {
                Console.WriteLine("Invalid command, try again.");
            }
        }
    }
}