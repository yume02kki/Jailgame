using MazeGame.MazeGame.Core.Interactables;

namespace MazeGame.MazeGame.Core.LoadScene;

public class GameProfile
{
    public RoomGeneration roomGenerator { get; }
    public Dictionary<string, Room> rooms { get; }
    public Player player { get; }

    public GameProfile(int width, int height, string RoomSequence)
    {
        roomGenerator = new RoomGeneration(width, height);
        rooms = new();
        rooms["spawn"] = roomGenerator.generateRooms(RoomSequence);
        rooms["exit"] = roomGenerator.tryGetRoom(new IntVector2(-1, 4))!;
        rooms["dog"] = roomGenerator.tryGetRoom(new IntVector2(-1, 3))!;
        rooms["guard"] = roomGenerator.tryGetRoom(new IntVector2(-2, 3))!;
        rooms["dogfood"] = roomGenerator.tryGetRoom(new IntVector2(0, 3))!;
        player = new Player(rooms["spawn"],
            new IntVector2(rooms["spawn"].playAreaWidth() - 1, rooms["spawn"].playAreaHeight() - 1));
    }
}