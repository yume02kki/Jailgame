using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class OnLoad : Writer
{
    public OnLoad(Action action) : base(_ => action())
    {
    }
}