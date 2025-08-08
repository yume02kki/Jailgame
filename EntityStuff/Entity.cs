using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Entitys;

public abstract class Entity : Obj,Irender
{
    private int _x,_y;
    private string _icon;
    public Entity(string name,int x, int y,PartsUsed parts,string icon="?") : base(name,parts)
    {
        _icon = icon;
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
    
    public virtual string icon() => _icon;

    public virtual bool collide() => false;
}