using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class CompsUsed
{
    private List<Component> components;
    public CompsUsed(params List<Component> components) => this.components = new List<Component>(components);
    public CompsUsed() => this.components = new List<Component>();
    public executor? get<TComponent>() where TComponent : executor => components.Find(component => component is TComponent) as TComponent;

    public fetcher<GRead>? get<GRead, TComponent>() where TComponent : fetcher<GRead> =>
        components.Find(component => component is fetcher<GRead>) as fetcher<GRead>;

    public void execute<TComponent>() where TComponent : executor => (get<TComponent>())?.execute();

    public GRead? read<GRead, TComponent>() where TComponent : fetcher<GRead>
    {
        Component? reader = get<GRead, TComponent>();
        return reader is fetcher<GRead> ? ((fetcher<GRead>)reader).read() : default;
    }

    public void add(executor executor) => components.Add(executor);
}