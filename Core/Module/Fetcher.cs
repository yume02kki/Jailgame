namespace MazeGame.MazeGame.Core.Module;

public class Fetcher<G> : Component
{
    Func<Object, Object?> _func;

    public Fetcher()
    {
    }

    public Fetcher(Func<Object, Object> func)
    {
        _func = func;
    }

    public Fetcher(Func<Object> func)
    {
        _func = _ => func();
    }

    public virtual G? read(Object? arg = null) => (G)_func(arg);
    public virtual G? read() => (G)_func(null);
}