using System.Text;
using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame;

class Program
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        GameCreator gameCreator = GameCreator.Instance;
        while (gameCreator.gameStatus == GameStatus.ONGOING)
        {
            Terminal.terminalUi(gameCreator.player);
            Terminal.renderFrame(gameCreator.player);
        }

        switch (gameCreator.gameStatus)
        {
            case GameStatus.WIN:
                Console.WriteLine("\n=== YOU WIN: ESCAPED THE JAIL ===\n");
                break;
            case GameStatus.LOSE:
                Console.WriteLine("\n=== YOU LOSE: CAUGHT BY GUARD ===\n");
                break;
        }

        Terminal.terminalUi(gameCreator.player);
    }
}