using System.Security.Cryptography;
using MazeGame.Entitys;

namespace MazeGame;

public class Player : Irender
{
    private Dictionary<string,Obj> inventory = new Dictionary<string,Obj>();
    private Room _currentRoom;
    private int _x = 0;
    private int _y = 0;
    private string _icon = "☺";

    public Player(Room room, int x, int y)
    {
        this._currentRoom = room;
        this._x = x;
        this._y = y;
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

    public bool onBorder()
    {
        return (currentRoom.playAreaWidth() <= x || x == 0) || (currentRoom.playAreaHeight() <= y || y == 0);
        ;
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
        int[] offset = { 0, 0 };
        switch (direction)
        {
            case Direction.up:
                offset[1]--;
                break;
            case Direction.down:
                offset[1]++;
                break;
            case Direction.left:
                offset[0]--;
                break;
            case Direction.right:
                offset[0]++;
                break;
        }
        x += offset[0];
        y += offset[1];
        
        if (currentRoom.tryGet(x, y) is Door&&!currentRoom.tryGet(x, y)!.collide())
        {
            currentRoom = currentRoom.getRoom(direction)!;
            x = Misc.clamp(x,currentRoom.playAreaWidth());
            y = Misc.clamp(y,currentRoom.playAreaHeight());
        }
        else if (onBorder())
        {
            x -= offset[0];
            y -= offset[1];
        }
    }
}