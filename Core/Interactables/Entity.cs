using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Core.Interactables;

public class Entity
{
    public string name { get; set; }
    public CompsUsed components { get; set; }
    public IntVector2? pos { get; set; }

    public Entity(string name, IntVector2? pos = null, params List<Component> components)
    {
        this.pos = pos;
        this.components = new CompsUsed(components);
        this.name = name;
    }

    public Entity(string name, IntVector2? pos = null)
    {
        components = new CompsUsed();
        this.name = name;
    }

    public override string ToString() => name;
}