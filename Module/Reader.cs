using MazeGame.MazeGame.Module;

namespace MazeGame.MazeGame.statusInterfaces;

public abstract class Reader<G> : Part
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