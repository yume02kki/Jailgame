using System;
using MazeGame;
using MazeGame.Entitys;

class GFG
{
    public static void Main(String[] args)
    {
        God god = God.Instance;
        while (!god.gameOver)
        {
            TerminalManager.render(god.player);
        }
    }
}
