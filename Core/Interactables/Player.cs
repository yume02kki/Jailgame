using MazeGame.MazeGame.Core.Enforcers;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Interactables;

public class Player
{
    private Dictionary<string, Entity> inventory;
    public Node currentNode { get; set; }
    public IntVector2 pos { get; set; } = new(0, 0);
    public Render render { get; } = new Render("☺");

    public Player(Node currentNode, IntVector2 pos, Dictionary<string, Entity>? inventory = null)
    {
        this.inventory = inventory ?? new Dictionary<string, Entity>();
        this.currentNode = currentNode;
        this.pos = pos;
    }

    public Entity? getFromInventory(string itemName) => inventory.GetValueOrDefault(itemName);

    public List<Entity> getInventoryList() => inventory.Values.ToList();

    public void addToInventory(Entity item) => inventory.TryAdd(item.name, item);


    public void move(Directions direction)
    {
        IntVector2 posOffset = new IntVector2(Util.directionVector[direction]) * new IntVector2(1, -1); //Y to Column

        MovementEnforcer movementEnforcer = new(this, posOffset);

        if (movementEnforcer.collide()) return;

        if (movementEnforcer.isPortal())
        {
            currentNode = currentNode.neighbbors[direction]!;
            movementEnforcer.roomSwitchHook(); //currentNode hook

            pos = movementEnforcer.wrapPosAround();
        }
        else if (!movementEnforcer.isClipping()) pos += posOffset;
    }
}