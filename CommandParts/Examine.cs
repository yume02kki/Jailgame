using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Examine:Iexamine
{
    private Obj _item;
    private Action<Obj> _action;

    public Examine(Obj item, Action<Obj> action)
    {
        _item = item;
        _action = action;
    }
    public void examine()
    {
        _action(_item);
    }
}