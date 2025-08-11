using System.Text;
using MazeGame;

class GFG
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        LogicManager logicManager = LogicManager.Instance;
        while (!logicManager.gameOver)
        {
            TerminalManager.tui(logicManager.player);
            TerminalManager.render(logicManager.player);
        }
    }
}
