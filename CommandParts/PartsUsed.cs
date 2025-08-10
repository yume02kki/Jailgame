using MazeGame.Entitys;
using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.MazeGame.CommandParts;

public class PartsUsed
{
    private List<Iexecute> parts;
    public PartsUsed(params List<Iexecute> parts) => this.parts = new List<Iexecute>(parts);
    public PartsUsed() => this.parts = new List<Iexecute>();
    public T? get<T>() where T : class,Iexecute => parts.Find(Iexecute => Iexecute is T) as T;
    public void execute<T>() where T : class,Iexecute => (get<T>())?.execute();
    public void add(Iexecute part) => parts.Add(part);
}