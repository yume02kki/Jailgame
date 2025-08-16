namespace MazeGame.MazeGame.Core.Module;

public abstract class executer : Component
{
    Action<Object> _action;

    public executer()
    {
    }

    public executer(Action<Object> action)
    {
        _action = action;
    }

    public executer(Action action)
    {
        _action = _ => action();
    }

    public virtual void execute(Object? arg = null) => _action(arg);
    public virtual void execute() => _action(null);
}