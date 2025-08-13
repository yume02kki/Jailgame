namespace MazeGame.MazeGame.Core.Misc;

public class GameProfile
{
    public GameInit init { get; }
    public Dictionary<string, Room> rooms { get; }
    public Player player { get; }

    public GameProfile(int width, int height, string RoomSequence)
    {
        init = new GameInit(width, height);
        rooms = new();
        rooms["spawn"] = init.roomGen(RoomSequence);
        rooms["exit"] = init.tryGetRoom(-1, 4)!;
        rooms["dog"] = init.tryGetRoom(-1, 3)!;
        rooms["guard"] = init.tryGetRoom(-2, 3)!;
        rooms["dogfood"] = init.tryGetRoom(0, 3)!;
        player = new Player(rooms["spawn"], rooms["spawn"].playAreaWidth() - 1, rooms["spawn"].playAreaHeight() - 1);
    }
}