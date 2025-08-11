namespace MazeGame.MazeGame.CommandInterfaces;

public abstract class Part
{
    Action<Object> _action;

    public Part()
    {
    }

    public Part(Action<Object> action)
    {
        _action = action;
    }

    public Part(Action action)
    {
        _action = _ => action();
    }

    public virtual void execute(Object? arg = null) => _action(arg);
    public virtual void execute() => _action(null);
}