using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class OnLoad : Part
{
    public OnLoad(Action action) : base(_ => action())
    {
    }
}