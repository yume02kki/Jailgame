using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public abstract class Entity : Renderable
{
    private string _name;
    private int _x,_y;
    private string _icon;
    
    public Entity(string name,int x, int y, string icon="?")
    {
        _icon = icon;
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

    public override string ToString() => this._name;
    
    public virtual string icon() => _icon;

    public virtual bool collide() => false;
}