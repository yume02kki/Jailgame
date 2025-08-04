using MazeGame.CommandInterfaces;
using MazeGame.Entitys;

namespace MazeGame;

public class God
{
    //singleton
    private static readonly Lazy<God> _instance = new Lazy<God>(() => new God());
    public static God Instance => _instance.Value;
    public readonly bool gameOver = false;

    public readonly Dictionary<string, Room> rooms = new Dictionary<string, Room>
    {
        ["C4"] = new Room("C4"),
        ["B4"] = new Room("B4"),
        ["B3"] = new Room("B3"),
        ["B2"] = new Room("B2"),
        ["C2"] = new Room("C2"),
        ["C1"] = new Room("C1"),
        ["B1"] = new Room("B1"),
        ["A1"] = new Room("A1")
    };

    public readonly Player player;

    private God()
    {
        rooms["C4"].linkRoom(Direction.left, rooms["B4"]);
        rooms["B4"].linkRoom(Direction.up, rooms["B3"]);
        rooms["B3"].linkRoom(Direction.up, rooms["B2"]);
        rooms["B2"].linkRoom(Direction.up, rooms["B1"]);
        rooms["B2"].linkRoom(Direction.right, rooms["C2"]);
        rooms["C2"].linkRoom(Direction.up, rooms["C1"]);
        rooms["C1"].linkRoom(Direction.left, rooms["B1"]);
        rooms["B1"].linkRoom(Direction.left, rooms["A1"]);
        rooms["C4"].addEntity(new Bed("bed"));
        player = new Player(rooms["C4"]);
    }
    
    public void examine(Entity ent)
    {
        if (ent is Iexamine)
        {
            player.setInventory(((Iexamine)ent).examine());
        }
    }
    
    public void inventory()
    {
        Console.WriteLine("You have: " + String.Join(", ", player.getInventory()));
    }
}