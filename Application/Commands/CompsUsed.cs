using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class CompsUsed
{
    public List<Component> components { get; set; }
    // [JsonInclude] private List<dynamic> componentsJson { get; set; }

    public CompsUsed(params List<Component> components)
    {
        this.components = new(components);
        // this.componentsJson = new(components);
    }

    // [JsonConstructor]
    // public CompsUsed(){}

    public Executor? get<TComponent>() where TComponent : Executor =>
        components.Find(component => component is TComponent) as TComponent;

    public Fetcher<GRead>? get<GRead, TComponent>() where TComponent : Fetcher<GRead> =>
        components.Find(component => component is Fetcher<GRead>) as Fetcher<GRead>;

    public void execute<TComponent>() where TComponent : Executor => (get<TComponent>())?.execute();

    public void execute<TComponent>(dynamic argument) where TComponent : Executor =>
        (get<TComponent>())?.execute(argument);

    public GRead? read<GRead, TComponent>() where TComponent : Fetcher<GRead>
    {
        Component? reader = get<GRead, TComponent>();
        return reader is Fetcher<GRead> ? ((Fetcher<GRead>)reader).read() : default;
    }

    public void add(Executor executor) => components.Add(executor);
}