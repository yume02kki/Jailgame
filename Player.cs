namespace MazeGame;

public class Player
{
    private HashSet<String> inventory = new HashSet<string>();
    private Room _currentRoom;

    public Player(Room room)
    {
        this._currentRoom = room;
    }

    public Room currentRoom
    {
        get => _currentRoom;
        set => _currentRoom = value;
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
        if (currentRoom.getRoom(direction) == null)
        {
            return;
        }

        Room selectedRoom = currentRoom.getRoom(direction)!;
        if (selectedRoom is Scripted)
        {
            if (((Scripted)selectedRoom).onEnter())
            {
                currentRoom = selectedRoom;
            }
        }
        else
        {
            currentRoom = selectedRoom;
        }
    }
}