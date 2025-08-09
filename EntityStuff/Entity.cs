using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Entitys;

public abstract class Entity : Obj, Irender
{
    private int _x, _y;
    private Render _render;

    public Entity(string name, int x, int y, PartsUsed parts, Render render) : base(name, parts)
    {
        this._render = render;
        _x = x;
        _y = y;
    }

    public Entity(string name, int x, int y, PartsUsed parts) : base(name, parts)
    {
        _render = new Render("?");
        _x = x;
        _y = y;
    }

    public int x
    {
        get { return _x; }
        set { _x = value; }
    }

    public int y
    {
        get { return _y; }
        set { _y = value; }
    }

    public virtual Render getRender() => _render;
    public virtual bool collide() => false;
}