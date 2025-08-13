using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class CompsUsed
{
    private List<Component> comps;
    public CompsUsed(params List<Component> components) => this.comps = new List<Component>(components);
    public CompsUsed() => this.comps = new List<Component>();
    public Writer? get<TComponent>() where TComponent : Writer => comps.Find(comp => comp is TComponent) as TComponent;

    public Reader<GRead>? get<GRead, TComponent>() where TComponent : Reader<GRead> =>
        comps.Find(comp => comp is Reader<GRead>) as Reader<GRead>;

    public void execute<TComponent>() where TComponent : Writer => (get<TComponent>())?.execute();

    public GRead? read<GRead, TComponent>() where TComponent : Reader<GRead>
    {
        Component? reader = get<GRead, TComponent>();
        return reader is Reader<GRead> ? ((Reader<GRead>)reader).read() : default;
    }

    public void add(Writer writer) => comps.Add(writer);
}