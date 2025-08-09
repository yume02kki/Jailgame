using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MazeGame.CommandInterfaces;
using MazeGame.Entitys;
using MazeGame.Items;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame;

public class LogicManager
{
    private const int SIZE_W = 6;
    private const int SIZE_H = 4;

    //singleton
    private static readonly Lazy<LogicManager> _instance = new Lazy<LogicManager>(() => new LogicManager());
    public static LogicManager Instance => _instance.Value;

    public readonly bool gameOver = false;

    public readonly Player player;
    public GameInit init;

    private LogicManager()
    {
        init = new GameInit(SIZE_W, SIZE_H);
        Room spawnRoom = init.roomGen("LUURULL");
        player = new Player(spawnRoom, spawnRoom.playAreaWidth() - 1, spawnRoom.playAreaHeight() - 1);


        Door firstDoor = (Door)spawnRoom.getEntityList().Find((ent) => ent is Door)!;
        OpenLock doorLock = new OpenLock();
        init.addEntity((0, 0),
            (new Door(firstDoor.Name, firstDoor.x, firstDoor.y, Direction.left, new PartsUsed(doorLock))));


        Needle needle = new Needle("needle", new PartsUsed(new Use()));
        init.addEntity((0, 0), new Bed("bed", 2, 1, new PartsUsed(new Examine(needle, player.addInv))));
    }
}