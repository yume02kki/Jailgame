namespace MazeGame.MazeGame.Core.Module;

public abstract class executor : Component
{
    Action<Object> _action;

    public executor()
    {
    }

    public executor(Action<Object> action)
    {
        _action = action;
    }

    public executor(Action action)
    {
        _action = _ => action();
    }

    public virtual void execute(Object? arg = null) => _action(arg);
    public virtual void execute() => _action(null);
}