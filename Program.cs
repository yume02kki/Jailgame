using System.Text;
using MazeGame.MazeGame.Core.Misc;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Application;

class Program
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        GameCreator gameCreator = GameCreator.Instance;
        while (gameCreator.gameStatus == GameStatus.ongoing)
        {
            TerminalManager.terminalUi(gameCreator.player);
            TerminalManager.renderFrame(gameCreator.player);
        }

        switch (gameCreator.gameStatus)
        {
            case GameStatus.win:
                Console.WriteLine("\n=== YOU WIN: ESCAPED THE JAIL ===\n");
                break;
            case GameStatus.lose:
                Console.WriteLine("\n=== YOU LOSE: CAUGHT BY GUARD ===\n");
                break;
        }

        TerminalManager.terminalUi(gameCreator.player);
    }
}