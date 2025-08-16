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
        while (gameCreator.GameStates == GameStates.ONGOING)
        {
            Terminal.terminalUI(gameCreator.player);
            Terminal.renderFrame(gameCreator.player);
        }

        switch (gameCreator.GameStates)
        {
            case GameStates.WIN:
                Console.WriteLine("\n=== YOU WIN: ESCAPED THE JAIL ===\n");
                break;
            case GameStates.LOSE:
                Console.WriteLine("\n=== YOU LOSE: CAUGHT BY GUARD ===\n");
                break;
        }

        Terminal.terminalUI(gameCreator.player);
    }
}