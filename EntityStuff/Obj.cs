using MazeGame.MazeGame.CommandParts;
using MazeGame.MazeGame.Module;

namespace MazeGame.Entitys;

public class Obj
{
    private string _name;
    private PartsUsed _parts;

    public Obj(string name, params List<Part> parts)
    {
        _parts = new PartsUsed(parts);
        _name = name;
    }

    public Obj(string name)
    {
        _parts = new PartsUsed();
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