using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class CompsUsed
{
    public List<Icomponent> components { get; set; }

    [JsonConstructor]
    public CompsUsed()
    { }

    public CompsUsed(params List<Icomponent> components)
    {
        this.components = new List<Icomponent>(components);
    }

    public Icomponent? get(Type type) => components.Find(component => component.GetType() == type);

    public object? execute(Type type, object? argument = null) => get(type)?.execute(argument);
}