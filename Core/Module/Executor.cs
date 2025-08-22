namespace MazeGame.MazeGame.Core.Module;

public class Executor : Component
{
    private Action<Object> _action;

    public Executor()
    {
    }

    public Executor(Action<Object> action)
    {
        _action = action;
    }

    public Executor(Action action)
    {
        _action = _ => action();
    }

    public virtual void execute(Object? arg = null) => _action(arg);
    public virtual void execute() => _action(null);
}