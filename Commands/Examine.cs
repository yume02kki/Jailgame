using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Examine : Writer
{
    private Obj _item;
    private Action<Obj> _action;

    public Examine(Obj item, Action<Obj> action)
    {
        _item = item;
        _action = action;
    }

    public override void execute()
    {
        _action(_item);
        TerminalManager.invPrint();
    }
}