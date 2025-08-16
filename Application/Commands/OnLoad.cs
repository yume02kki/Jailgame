using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class OnLoad : executor
{
    public OnLoad(Action action) : base(_ => action())
    {
    }
}