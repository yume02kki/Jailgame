using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Used : executer
{
    public Used(GameObject expected, Action action) : base((sender) =>
    {
        if (sender == expected)
        {
            action();
        }
    })
    {
    }
}