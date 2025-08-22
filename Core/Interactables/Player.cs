using System.Text.Json.Serialization;
using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Core.Enforcers;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Core.Utility;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Interactables;

public class Player
{
    public Dictionary<string, Entity> inventory { get; set; }
    public Node currentNode { get; set; }
    public IntVector2 pos { get; set; }
    public Render render { get; } = Icons.get("player");
    [JsonIgnore] public MovementEnforcer movementEnforcer { get; set; }

    public Player(Node currentNode, IntVector2 pos, Dictionary<string, Entity>? inventory = null)
    {
        this.movementEnforcer = new MovementEnforcer(this);
        this.inventory = inventory ?? new Dictionary<string, Entity>();
        this.currentNode = currentNode;
        this.pos = pos;
    }

    public Entity? getFromInventory(string itemName) => inventory.GetValueOrDefault(itemName);

    public List<Entity> getInventoryList() => inventory.Values.ToList();

    public void addToInventory(Entity item) => inventory.TryAdd(item.name, item);


    public void move(Directions direction)
    {
        movementEnforcer.runAll(direction);
    }
}