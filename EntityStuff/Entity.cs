namespace MazeGame.Entitys;

public abstract class Entity : Renderable
{
    private string _name;
    private int _x,_y;
    public Entity(string name, int x, int y)
    {
        _name = name;
        _x = x;
        _y = y;
    }

    public String Name
    {
        get { return _name; }
        set { _name = value; }
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

    public bool collide()
    {
        return true;
    }
    public override string ToString()
    {
        return this._name;
    }

    public virtual string icon()
    {
        return "?";
    }
}