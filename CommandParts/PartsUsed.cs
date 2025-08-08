using MazeGame.Entitys;

namespace MazeGame.MazeGame.CommandParts;

public class PartsUsed
{
    private List<Part> parts;

    public PartsUsed(params List<Part> parts)
    {
        this.parts = new List<Part>(parts);
        
    }
    
    public PartsUsed()
    {
        this.parts = new List<Part>();
    }

    public T? get<T>() where T : Part
    {
        return parts.Find(part => part is T) as T;
    }

    public void execute<T>() where T : Part
    {
        (get<T>())?.execute();
    }
}