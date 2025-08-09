using System;
using MazeGame;
using MazeGame.Entitys;

class GFG
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        LogicManager logicManager = LogicManager.Instance;
        while (!logicManager.gameOver)
        {
            TerminalManager.tui(logicManager.player);
            TerminalManager.render(logicManager.player);
        }
    }
}
