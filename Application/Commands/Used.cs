using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Used : executor
{
    public Used(Entity expected, Action action) : base(sender =>
    {
        if (sender == expected) action();
    })
    {
    }
}