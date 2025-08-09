using System.Security.Cryptography;
using MazeGame.Entitys;

namespace MazeGame;

public class Player : Irender
{
    private Dictionary<string,Obj> inventory = new Dictionary<string,Obj>();
    private movementEnforcer movementEnforcer;
    private Room _currentRoom;
    private int _x = 0;
    private int _y = 0;
    private string _icon = "☺";

    public Player(Room room, int x, int y)
    {
        this._currentRoom = room;
        this._x = x;
        this._y = y;
        this.movementEnforcer = new movementEnforcer(this);
    }

    public int x
    {
        get => _x;
        set => _x = value;
    }

    public int y
    {
        get => _y;
        set => _y = value;
    }
    

    public Room currentRoom
    {
        get => _currentRoom;
        set => _currentRoom = value;
    }

    public string icon()
    {
        return _icon;
    }

    public Obj? getInv(string itemName)
    {
        
        return inventory.ContainsKey(itemName)?inventory[itemName]:null;
    }

    public void addInv(Obj item)
    {
        inventory.TryAdd(item.Name, item);
    }

    public void removeInventory(string itemName)
    {
        inventory.Remove(itemName);
    }

    public string invString()
    {
        return inventory.Values.Aggregate("",(current, item) => current + $"{item.Name}, ");
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
        if (movementEnforcer.isPortal())
        {
            currentRoom = currentRoom.getRoom(direction)!;
            x = movementEnforcer.xClamp(x_offset);
            y = movementEnforcer.yClamp(y_offset);
        }

        else if (!movementEnforcer.isClipping())
        {
            x+=x_offset;
            y+=y_offset;
        }
    }
}