using System.Text;
using MazeGame;

class GFG
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Creator creator = Creator.Instance;
        while (!creator.gameOver)
        {
            TerminalManager.tui(creator.player);
            TerminalManager.render(creator.player);
        }

        Console.WriteLine("\n=== YOU LOSE ===\n");
        TerminalManager.tui(creator.player);
    }
}