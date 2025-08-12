using MazeGame.MazeGame.statusInterfaces;

namespace MazeGame.MazeGame.CommandParts;

public class Collide : Reader<bool>
{
    private Func<bool> _hook;

    public Collide(Func<bool> hook)
    {
        _hook = hook;
    }

    public override bool read() => _hook();
}