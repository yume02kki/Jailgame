using MazeGame.Entitys;

namespace MazeGame;

public class Player : Renderable
{
    private HashSet<String> inventory = new HashSet<string>();
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

    public Room currentRoom
    {
        get => _currentRoom;
        set => _currentRoom = value;
    }

    public string icon()
    {
        return _icon;
}
    public HashSet<String> getInventory()
    {
        return inventory;
    }

    public void setInventory(String item)
    {
        inventory.Add(item);
    }

    public void removeInventory(String item)
    {
        inventory.Remove(item);
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
    }
}