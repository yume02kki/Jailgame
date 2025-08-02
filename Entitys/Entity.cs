namespace MazeGame.Entitys;

public class Entity
{
    private String name;

    public Entity(String name)
    {
        this.name = name;
    }

    public override string ToString()
    {
        return this.name;
    }
}