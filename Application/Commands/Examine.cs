using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Examine : Writer
{
    private GameObject _item;
    private Action<GameObject> _action;

    public Examine(GameObject item, Action<GameObject> action)
    {
        _item = item;
        _action = action;
    }

    public override void execute()
    {
        _action(_item);
    }
}