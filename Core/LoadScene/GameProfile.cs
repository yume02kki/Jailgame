using MazeGame.MazeGame.Core.Interactables;

namespace MazeGame.MazeGame.Core.LoadScene;

public class GameProfile
{
    public GameInit init { get; }
    public Dictionary<string, Room> rooms { get; }
    public Player player { get; }

    public GameProfile(int width, int height, string RoomSequence)
    {
        init = new GameInit(width, height);
        rooms = new();
        rooms["spawn"] = init.generateRooms(RoomSequence);
        rooms["exit"] = init.tryGetRoom(new IntVector2(-1, 4))!;
        rooms["dog"] = init.tryGetRoom(new IntVector2(-1, 3))!;
        rooms["guard"] = init.tryGetRoom( new IntVector2(-2, 3))!;
        rooms["dogfood"] = init.tryGetRoom(new IntVector2(0, 3))!;
        player = new Player(rooms["spawn"], new IntVector2(rooms["spawn"].playAreaWidth() - 1, rooms["spawn"].playAreaHeight() - 1));
    }
}