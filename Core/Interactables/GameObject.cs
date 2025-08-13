using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Core.Interactables;

public class GameObject
{
    public string name { get; set; }
    public CompsUsed comps { get; set; }

    public GameObject(string name, params List<Component> comps)
    {
        this.comps = new CompsUsed(comps);
        this.name = name;
    }

    public GameObject(string name)
    {
        comps = new CompsUsed();
        this.name = name;
    }

    public override string ToString() => name;
}