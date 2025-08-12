using System.Text;
using MazeGame;

class GFG
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Creator creator = Creator.Instance;
        while (creator.gameStatus == GameStatus.ongoing)
        {
            TerminalManager.tui(creator.player);
            TerminalManager.render(creator.player);
        }

        switch (creator.gameStatus)
        {
            case GameStatus.win:
                Console.WriteLine("\n=== YOU WIN: ESCAPED THE JAIL ===\n");
                break;
            case GameStatus.lose:
                Console.WriteLine("\n=== YOU LOSE: CAUGHT BY GUARD ===\n");
                break;
        }

        TerminalManager.tui(creator.player);
    }
}