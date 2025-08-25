using System.Text;
using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame;

class Program
{
    public static GameStates gameState { get; set; }

    public static void Main(string[] args)
    {
        gameState = GameStates.ONGOING;
        Console.OutputEncoding = Encoding.UTF8;

        while (gameState == GameStates.ONGOING)
        {
            Terminal.terminalUI();
            Terminal.renderFrame();
            Terminal.loadNewFrame();
        }

        switch (gameState)
        {
            case GameStates.WIN:
                Console.WriteLine("\n=== YOU WIN: ESCAPED THE JAIL ===\n");
                break;
            case GameStates.LOSE:
                Console.WriteLine("\n=== YOU LOSE: CAUGHT BY GUARD ===\n");
                break;
        }

        Terminal.terminalUI();
    }
}