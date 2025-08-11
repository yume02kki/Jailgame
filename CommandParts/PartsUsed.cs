using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.MazeGame.CommandParts;

public class PartsUsed
{
    private List<Part> parts;
    public PartsUsed(params List<Part> parts) => this.parts = new List<Part>(parts);
    public PartsUsed() => this.parts = new List<Part>();
    public T? get<T>() where T : Part => parts.Find(Iexecute => Iexecute is T) as T;
    public void execute<T>(Object arg) where T : Part => (get<T>())?.execute(arg);
    public void execute<T>() where T : Part => (get<T>())?.execute();
    public void add(Part part) => parts.Add(part);
}