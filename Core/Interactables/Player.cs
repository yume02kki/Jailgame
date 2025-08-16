using MazeGame.MazeGame.Core.Enforcers;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Interactables;

public class Player
{
    private Dictionary<string, Entity> inventory;
    public Room currentRoom { get; set; }
    public IntVector2 pos { get; set; } = new(0, 0);
    public Render render { get; } = new Render("☺");

    public Player(Room room, IntVector2 pos, Dictionary<string, Entity>? inventory = null)
    {
        this.inventory = inventory ?? new Dictionary<string, Entity>();
        this.currentRoom = room;
        this.pos = pos;
    }

    public Entity? getFromInventory(string itemName)
    {
        return inventory.ContainsKey(itemName) ? inventory[itemName] : null;
    }

    public List<Entity> getInventoryList()
    {
        return inventory.Values.ToList();
    }

    public void addToInventory(Entity item)
    {
        inventory.TryAdd(item.name, item);
    }

    public void move(Directions directions)
    {
        IntVector2 posOffset =
            new IntVector2(Util.directionVector[directions]) * new IntVector2(1, -1); //Y to Column

        MovementEnforcer movementEnforcer = new(this, posOffset);

        if (!movementEnforcer.collide())
        {
            if (movementEnforcer.isPortal())
            {
                currentRoom = currentRoom.getRoom(directions)!;
                pos = movementEnforcer.wrapPosAround();

                //run onLoad parts for room
                movementEnforcer.onLoad();
            }
            else if (!movementEnforcer.isClipping())
            {
                pos += posOffset;
            }
        }
    }
}