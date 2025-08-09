using MazeGame.Entitys;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame;

public class GameInit
{
    private int width;
    private int height;

    public GameInit(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    
    public Room roomGen(string sequence)
    {
        int count = 1;
        Room spawnRoom = new Room("spawn", width, height);
        Room travRoom = spawnRoom;
        foreach (char letter in sequence)
        {
            Direction dir = strDir(letter);
            Room tempRoom = new Room($"generated room {count}", width, height);
            travRoom.linkRoom(dir, tempRoom);
            doorLink(travRoom, tempRoom, dir);
            travRoom = tempRoom;
            count++;
        }

        return spawnRoom;
    }

    public void doorLink(Room thisRoom, Room otherRoom, Direction direction)
    {
        int normalX, normalY;
        (normalX, normalY) = doorPos(direction, thisRoom.playAreaWidth(), thisRoom.playAreaHeight());

        int mirrorX = Misc.clamp(normalX, otherRoom.playAreaWidth());
        int mirrorY = Misc.clamp(normalY, otherRoom.playAreaHeight());

        var open = new PartsUsed(new Open(true));
        var mirror = Misc.mirror(direction);

        if (direction == Direction.right || direction == Direction.down)
        {
            int tx = normalX, ty = normalY;
            normalX = mirrorX; normalY = mirrorY;
            mirrorX = tx; mirrorY = ty;
        }
        
        
        thisRoom.addEntity(new Door("door", normalX, normalY, direction, open));
        otherRoom.addEntity(new Door("door", mirrorX, mirrorY, mirror, open));

    }

    public (int x, int y) doorPos(Direction direction, int x, int y)
    {
        double multX = 1;
        double multY = 1;
        if (direction == Direction.up || direction == Direction.down)
        {
            multX = 0.5;
            multY = 0;
        }
        else if (direction == Direction.left || direction == Direction.right)
        {
            multX = 0;
            multY = 0.5; 
        }

        
        return ((int)Math.Ceiling(x * multX), (int)Math.Ceiling(y * multY));
    }

    public Direction strDir(char letter)
    {
        switch (letter)
        {
            case 'L':
                return Direction.left;
            case 'R':
                return Direction.right;
            case 'U':
                return Direction.up;
            case 'D':
                return Direction.down;
        }

        return default(Direction);
    }
}