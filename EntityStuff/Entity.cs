using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Entity : Obj
{
    private int _x, _y;
    private Render _render;

    
    public Entity(string name, int x, int y, Render render, params List<Part> parts) : base(name, parts)
    {
        this._render = render;
        _x = x;
        _y = y;
    }

    public Entity(string name, int x, int y,params List<Part> parts) : base(name, parts)
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