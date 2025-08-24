using System.Text.Json.Serialization;
using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;

public class Examine : Component<VoidType>
{
    [JsonInclude] public Entity item { get; set; } = null!;

    [JsonConstructor]
    public Examine()
    {
        rewire();
    }

    public void rewire()
    {
        setFunction(() => GameCreator.Instance.player.addToInventory(item));
    }

    public Examine(Entity item)
    {
        this.item = item;
        rewire();
    }
}