using MazeGame.MazeGame.Core.Enforcers;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Misc;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core;

public class Player
{
    private Dictionary<string, GameObject> inventory = new Dictionary<string, GameObject>();
    private movementEnforcer movementEnforcer;
    public Room currentRoom { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public Render render { get; } = new Render("☺");

    public Player(Room room, int x, int y)
    {
        this.currentRoom = room;
        this.x = x;
        this.y = y;
        this.movementEnforcer = new movementEnforcer(this);
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
        int x_offset = 0;
        int y_offset = 0;
        switch (direction)
        {
            case Direction.up:
                y_offset--;
                break;
            case Direction.down:
                y_offset++;
                break;
            case Direction.left:
                x_offset--;
                break;
            case Direction.right:
                x_offset++;
                break;
        }

        movementEnforcer.setOffset(x_offset, y_offset);
        if (!movementEnforcer.collide())
        {
            if (movementEnforcer.isPortal())
            {
                currentRoom = currentRoom.getRoom(direction)!;
                x = movementEnforcer.xClamp(x_offset);
                y = movementEnforcer.yClamp(y_offset);

                //run onLoad parts for room
                movementEnforcer.onLoad();
            }
            else if (!movementEnforcer.isClipping())
            {
                x += x_offset;
                y += y_offset;
            }
        }
    }
}