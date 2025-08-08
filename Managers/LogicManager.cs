using System.Runtime.InteropServices;
using MazeGame.CommandInterfaces;
using MazeGame.Entitys;
using MazeGame.Items;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame;

public class LogicManager
{
    private const int SIZE_W = 5;
    private const int SIZE_H = 5;

    //singleton
    private static readonly Lazy<LogicManager> _instance = new Lazy<LogicManager>(() => new LogicManager());
    public static LogicManager Instance => _instance.Value;
    public readonly bool gameOver = false;

    //TODO: move to init class

    public readonly Dictionary<string, Room> rooms = new Dictionary<string, Room>
    {
        ["C4"] = new Room("C4", SIZE_W, SIZE_H),
        ["B4"] = new Room("B4", SIZE_W, SIZE_H),
        ["B3"] = new Room("B3", SIZE_W, SIZE_H),
        ["B2"] = new Room("B2", SIZE_W, SIZE_H),
        ["C2"] = new Room("C2", SIZE_W, SIZE_H),
        ["C1"] = new Room("C1", SIZE_W, SIZE_H),
        ["B1"] = new Room("B1", SIZE_W, SIZE_H),
        ["A1"] = new Room("A1", SIZE_W, SIZE_H)
    };

    public readonly Player player;

    private LogicManager()
    {
        OpenLock doorLock = new OpenLock();
        rooms["C4"].addEntity((new Door( "door",0, 3, Direction.left,new PartsUsed(doorLock))));
        rooms["C4"].linkRoom(Direction.left, rooms["B4"]);
        rooms["B4"].linkRoom(Direction.up, rooms["B3"]);
        rooms["B3"].linkRoom(Direction.up, rooms["B2"]);
        rooms["B2"].linkRoom(Direction.up, rooms["B1"]);
        rooms["B2"].linkRoom(Direction.right, rooms["C2"]);
        rooms["C2"].linkRoom(Direction.up, rooms["C1"]);
        rooms["C1"].linkRoom(Direction.left, rooms["B1"]);
        rooms["B1"].linkRoom(Direction.left, rooms["A1"]);
        Room spawnRoom = rooms["C4"];
        player = new Player(spawnRoom, spawnRoom.playAreaWidth() - 1, spawnRoom.playAreaHeight() - 1);

        Needle needle = new Needle("needle",new PartsUsed(new Use()));
        rooms["C4"].addEntity(new Bed("bed", 2, 3,new PartsUsed(new Examine(needle,player.addInv))));
    }

    public void move(Direction direction)
    {
        player.move(direction);
    }

    public void inventory()
    {
        Console.WriteLine("You have: " + player.invString());
    }
}