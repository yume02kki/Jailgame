using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Entitys;

public class Obj
{
    private string _name;
    private PartsUsed _parts;
    
    public Obj(string name,PartsUsed parts)
    {
        _parts =  parts;
        _name = name;
    }
    public Obj(string name)
    {
        _parts =  new PartsUsed();
        _name = name;
    }
    public PartsUsed parts
    {
        get { return _parts; }
        set { _parts = value; }
    }
    public String Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public override string ToString() => this._name;
}