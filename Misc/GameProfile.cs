namespace MazeGame;

public class GameProfile
{
    private GameInit _init;
    private Dictionary<string, Room> _rooms;
    private Player _player;

    public GameProfile(int SIZE_W, int SIZE_H, string SEQUENCE)
    {
        _init = new GameInit(SIZE_W, SIZE_H);
        _rooms = new();
        _rooms["spawn"] = _init.roomGen(SEQUENCE);
        _rooms["exit"] = _init.tryGetRoom(-1, 4)!;
        _rooms["dog"] = _init.tryGetRoom(-1, 3)!;
        _rooms["guard"] = _init.tryGetRoom(-2, 3)!;
        _rooms["dogfood"] = _init.tryGetRoom(0, 3)!;
        _player = new Player(_rooms["spawn"], _rooms["spawn"].playAreaWidth() - 1,
            _rooms["spawn"].playAreaHeight() - 1);
    }

    public Player player
    {
        get { return _player; }
    }

    public GameInit init
    {
        get { return _init; }
    }

    public Dictionary<string, Room> rooms
    {
        get { return _rooms; }
    }
}