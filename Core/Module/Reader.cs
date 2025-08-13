namespace MazeGame.MazeGame.Core.Module;

public abstract class Reader<G> : Component
{
    Func<Object, Object?> _func;

    public Reader()
    {
    }

    public Reader(Func<Object, Object> func)
    {
        _func = func;
    }

    public Reader(Func<Object> func)
    {
        _func = _ => func();
    }

    public virtual G? read(Object? arg = null) => (G)_func(arg);
    public virtual G? read() => (G)_func(null);
}