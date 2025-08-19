using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Collide : fetcher<bool>
{
    private Func<bool> _hook;

    public Collide(Func<bool> hook)
    {
        _hook = hook;
    }

    public override bool read() => _hook();
}