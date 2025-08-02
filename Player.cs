namespace MazeGame;

public class Player
{
    private List<String> inventory = new List<string>();
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

    public List<String> getInv()
    {
        return inventory;
    }
}