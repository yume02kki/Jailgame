using MazeGame.MazeGame.Core.Enforcers;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Interactables;

public class Player
{
    private Dictionary<string, GameObject> inventory;
    public Room currentRoom { get; set; }
    public IntVector2 pos { get; set; } = new(0, 0);
    public Render render { get; } = new Render("☺");

    public Player(Room room, IntVector2 pos, Dictionary<string, GameObject>? inventory = null)
    {
        this.inventory = inventory ?? new Dictionary<string, GameObject>();
        this.currentRoom = room;
        this.pos = pos;
    }

    public GameObject? getFromInventory(string itemName)
    {
        return inventory.ContainsKey(itemName) ? inventory[itemName] : null;
    }

    public List<GameObject> getInventoryList()
    {
        return inventory.Values.ToList();
    }

    public void addToInventory(GameObject item)
    {
        inventory.TryAdd(item.name, item);
    }

    public void move(Direction direction)
    {
        IntVector2 posOffset = new IntVector2(Util.directionVector[direction]) * new IntVector2(1, -1);//Y to Column

        MovementEnforcer movementEnforcer = new(this, posOffset);

        if (!movementEnforcer.collide())
        {
            if (movementEnforcer.isPortal())
            {
                currentRoom = currentRoom.getRoom(direction)!;
                pos = movementEnforcer.clamp();

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