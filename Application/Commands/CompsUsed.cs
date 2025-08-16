using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class CompsUsed
{
    private List<Component> components;
    public CompsUsed(params List<Component> components) => this.components = new List<Component>(components);
    public CompsUsed() => this.components = new List<Component>();
    public Writer? get<TComponent>() where TComponent : Writer => components.Find(component => component is TComponent) as TComponent;

    public Reader<GRead>? get<GRead, TComponent>() where TComponent : Reader<GRead> =>
        components.Find(component => component is Reader<GRead>) as Reader<GRead>;

    public void execute<TComponent>() where TComponent : Writer => (get<TComponent>())?.execute();

    public GRead? read<GRead, TComponent>() where TComponent : Reader<GRead>
    {
        Component? reader = get<GRead, TComponent>();
        return reader is Reader<GRead> ? ((Reader<GRead>)reader).read() : default;
    }

    public void add(Writer writer) => components.Add(writer);
}