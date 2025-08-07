using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Entity : Renderable
{
    private string _name;
    private int _x,_y;
    private string _icon;
    private Commands.Commands _commands;
    
    public Entity(string name,int x, int y,Commands.Commands commands, string icon="?")
    {
        _icon = icon;
        _name = name;
        _x = x;
        _y = y;
        _commands = commands;
    }

    public Commands.Commands Commands
    {
        get { return _commands; }
        set { _commands = value; }
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

    public virtual bool collide() => _commands is Icollide ? ((Icollide)_commands).collide() : false;
    public override string ToString() => this._name;
    
    public virtual string icon() => _commands is Renderable ? ((Renderable)_commands).icon() : _icon;
}