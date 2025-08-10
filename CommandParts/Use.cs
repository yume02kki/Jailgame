using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Use : Iexecute
{
    private Obj _whoami;
    private Iused? _target;
    public Use(Obj whoami)
    {
        _whoami = whoami;
    }
    public Obj get() => _whoami;
    public void set(Iused? target)
    {
        _target = target;
        execute();
    }
    public void execute()
    {
        _target?.used(_whoami);
        _target = null;
    }
}