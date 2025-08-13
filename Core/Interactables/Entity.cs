using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Core.Interactables;

public class Entity : GameObject
{
    public int x { get; set; }
    public int y { get; set; }

    public Entity(string name, int x, int y, params List<Component> comps) : base(name, comps)
    {
        this.x = x;
        this.y = y;
    }
}