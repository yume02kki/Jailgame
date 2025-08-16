using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Core.Interactables;

public class GameObject
{
    public string name { get; set; }
    public CompsUsed components { get; set; }

    public GameObject(string name, params List<Component> components)
    {
        this.components = new CompsUsed(components);
        this.name = name;
    }

    public GameObject(string name)
    {
        components = new CompsUsed();
        this.name = name;
    }

    public override string ToString() => name;
}