using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public abstract class Obj
{
    private string _name;
    
    public Obj(string name)
    {
        _name = name;
    }
    public String Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public override string ToString() => this._name;
}