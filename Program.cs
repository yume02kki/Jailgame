using System;
using MazeGame;
using MazeGame.Entitys;

class GFG
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        God god = God.Instance;
        while (!god.gameOver)
        {
            TerminalManager.render(god.player);
        }
    }
}
