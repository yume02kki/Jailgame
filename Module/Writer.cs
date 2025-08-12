using MazeGame.MazeGame.Module;

namespace MazeGame.MazeGame.CommandInterfaces;

public abstract class Writer : Part
{
    Action<Object> _action;

    public Writer()
    {
    }

    public Writer(Action<Object> action)
    {
        _action = action;
    }

    public Writer(Action action)
    {
        _action = _ => action();
    }

    public virtual void execute(Object? arg = null) => _action(arg);
    public virtual void execute() => _action(null);
}