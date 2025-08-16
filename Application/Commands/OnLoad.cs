using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class OnLoad : executer
{
    public OnLoad(Action action) : base(_ => action())
    {
    }
}