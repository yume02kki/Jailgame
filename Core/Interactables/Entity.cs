using System.Text.Json.Serialization;
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

    public Entity(string name, IntVector2? pos = null, List<Component>? components = null, HashSet<Tags>? tags = null)
    {
        this.name = name;
        this.pos = pos;
        this.tags = tags ?? new HashSet<Tags>();
        this.components = new CompsUsed(components??new List<Component>());
    }
    
    [JsonConstructor]
    public Entity(string name, CompsUsed components, IntVector2? pos, HashSet<Tags>? tags = null)
    {
        this.name = name;
        this.components = components;
        this.pos = pos;
        this.tags = tags ?? new HashSet<Tags>();
    }


    public override string ToString() => name;
}