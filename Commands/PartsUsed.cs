using MazeGame.MazeGame.CommandInterfaces;
using MazeGame.MazeGame.Module;
using MazeGame.MazeGame.statusInterfaces;

namespace MazeGame.MazeGame.CommandParts;

public class PartsUsed
{
    private List<Part> parts;
    public PartsUsed(params List<Part> parts) => this.parts = new List<Part>(parts);
    public PartsUsed() => this.parts = new List<Part>();
    public Writer? get<T>() where T : Writer => parts.Find(part => part is T) as T;
    public Reader<G>? get<G, T>() where T : Reader<G> => parts.Find(part => part is Reader<G>) as Reader<G>;
    public void execute<T>() where T : Writer => (get<T>())?.execute();

    public G? read<G, T>() where T : Reader<G>
    {
        Part? reader = get<G, T>();
        return reader is Reader<G> ? ((Reader<G>)reader).read() : default;
    }

    public void add(Writer writer) => parts.Add(writer);
}