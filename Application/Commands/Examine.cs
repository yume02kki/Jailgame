using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Examine : executor
{
    private Entity _item;
    private Action<Entity> _action;

    public Examine(Entity item, Action<Entity> action)
    {
        _item = item;
        _action = action;
    }

    public override void execute()
    {
        _action(_item);
    }
}