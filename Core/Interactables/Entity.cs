using MazeGame.MazeGame.Core.Misc;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Core.Interactables;

public class Entity : GameObject
{
    public IntVector2 pos { get; set; }
    
    public Entity(string name, IntVector2 pos, params List<Component> components) : base(name, components)
    {
        this.pos = pos;
    }
}