using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Use : Part
{
    private Iused? _target;

    public Iused target
    {
        get { return _target; }
        set { _target = value;execute(); }
    }

    public override void execute()
    {
        target?.used();
        _target = null;
    }
}