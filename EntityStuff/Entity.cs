namespace MazeGame.Entitys;

public class Entity
{
    private string _name;

    public Entity(string name)
    {
        this._name = name;
    }

    public String Name 
    {
        get { return _name; }
        set { _name = value; }
    }
    public override string ToString()
    {
        return this._name;
    }
}