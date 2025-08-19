namespace MazeGame.MazeGame.Core.Module;

public abstract class fetcher<G> : Component
{
    Func<Object, Object?> _func;

    public fetcher()
    {
    }

    public fetcher(Func<Object, Object> func)
    {
        _func = func;
    }

    public fetcher(Func<Object> func)
    {
        _func = _ => func();
    }

    public virtual G? read(Object? arg = null) => (G)_func(arg);
    public virtual G? read() => (G)_func(null);
}