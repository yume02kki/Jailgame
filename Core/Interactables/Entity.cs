using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Core.Interactables;

public class Entity
{
    public string name { get; set; }
    public CompsUsed components { get; set; }
    public IntVector2? pos { get; set; }
    public HashSet<Tags> tags { get; set; }

    public Entity(string name, IntVector2? pos = null, HashSet<Tags>? tags = null, List<Component>? components = null)
    {
        this.name = name;
        this.pos = pos;
        this.tags = tags ?? new HashSet<Tags>();
        this.components = new CompsUsed(components ?? new List<Component>());
    }

    public override string ToString() => name;
}