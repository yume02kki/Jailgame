using MazeGame.MazeGame.Module;

namespace MazeGame.Entitys;

public class Entity : Obj
{
    private int _x, _y;

    public Entity(string name, int x, int y, params List<Part> parts) : base(name, parts)
    {
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
}