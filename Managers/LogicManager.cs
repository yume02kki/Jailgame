using MazeGame.Entitys;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame;

public class LogicManager
{
    private const int SIZE_W = 6;
    private const int SIZE_H = 4;
    private const string SEQUENCE = "LUURULUDL";

    //singleton
    private static readonly Lazy<LogicManager> _instance = new Lazy<LogicManager>(() => new LogicManager());
    public static LogicManager Instance => _instance.Value;
    public readonly bool gameOver = false;
    public readonly Player player;
    public GameInit init;

    private LogicManager()
    {
        init = new GameInit(SIZE_W, SIZE_H);

        //sketchy ↓
        Dictionary<string, Room> rooms = new();
        rooms["spawn"] = init.roomGen(SEQUENCE);
        rooms["exit"] = init.tryGetRoom(-1, 4)!;
        rooms["dog"] = init.tryGetRoom(-1, 3)!;
        rooms["guard"] = init.tryGetRoom(-2, 3)!;
        rooms["dogfood"] = init.tryGetRoom(0, 3)!;
        player = new Player(rooms["spawn"], rooms["spawn"].playAreaWidth() - 1, rooms["spawn"].playAreaHeight() - 1);
        // player = new Player(rooms["dogfood"], rooms["dogfood"].playAreaWidth() - 1, rooms["dogfood"].playAreaHeight() - 1);

        //having class for door but not for other implementations, fix
        Door firstDoor = (Door)rooms["spawn"].getEntityList().Find((ent) => ent is Door)!;
        OpenLock doorLock = new OpenLock();
        Obj needle = new Obj("needle");
        needle.parts.add(new Use(needle));
        init.addEntity((0, 0),
            (new Door(firstDoor.Name, firstDoor.x, firstDoor.y, new PartsUsed(doorLock, new Used(needle)))));
        init.addEntity((0, 0),
            new Entity("bed", 2, 1, new Render("_", ConsoleColor.Blue),
                new PartsUsed(new Examine(needle, player.addInv))));
        Obj dogFood = new Obj("bonzo");
        dogFood.parts.add(new Use(dogFood));

        //also sketchy ↓
        Door dogDoor = (Door)rooms["dog"].getEntityList().Find((ent) => ent is Door && ent.Name.Contains("up"))!;
        init.addEntity((0, 0),
            (new Door(firstDoor.Name, firstDoor.x, firstDoor.y, new PartsUsed(doorLock, new Used(needle)))));
        init.addEntity((-1, 3), new Dog("dog", dogDoor.x, dogDoor.y + 1, new PartsUsed(new Used(dogFood))));
        init.addEntity((0, 3),
            new Entity("bowl", 4, 1, new Render("◡", ConsoleColor.Yellow),
                new PartsUsed(new Examine(dogFood, player.addInv))));
    }
}