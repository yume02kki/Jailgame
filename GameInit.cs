using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using MazeGame.Entitys;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame;

public class GameInit
{
    private int width;
    private int height;
    private Dictionary<(int x, int y), Room> roomPositions;

    public GameInit(int width, int height)
    {
        roomPositions = new();
        this.width = width;
        this.height = height;
    }

    public void addEntity((int,int) roomPos,Entity entity)
    {
        if (roomPositions.TryGetValue(roomPos,out Room room))
        {
            room.setEntity(entity);
        }
    }

    public Room? getRoom((int x, int y) roomPos)
    {
        roomPositions.TryGetValue(roomPos, out Room? room);
        return room;
    }
    public Room roomGen(string sequence)
    {
        int count = 1;
        Room spawnRoom = new Room("spawn", width, height);
        roomPositions.Add((0, 0), spawnRoom);
        Room travRoom = spawnRoom;
        foreach (char letter in sequence)
        {
            (int, int) lastPos = roomPositions.Last().Key;
            Direction dir = strDir(letter);
            Room tempRoom = new Room("" + count, width, height);
            roomPositions.TryAdd(Misc.addTuples(lastPos, Misc.dirToPos(dir)), tempRoom);
            neighborLink(travRoom, lastPos, roomPositions);
            travRoom = tempRoom;
            count++;
        }

        return spawnRoom;
    }

    private void neighborLink(Room room, (int, int) pos, Dictionary<(int x, int y), Room> roomPositions)
    {
        foreach (Direction dir in Enum.GetValues<Direction>())
        {
            (int, int) tup = Misc.addTuples(Misc.dirToPos(dir), pos);
            if (roomPositions.ContainsKey(tup))
            {
                doorLink(room, roomPositions[tup], dir);
            }
        }
    }

    private void doorLink(Room thisRoom, Room otherRoom, Direction direction)
    {
        thisRoom.linkRoom(direction, otherRoom);
        int normalX, normalY;
        (normalX, normalY) = doorPos(direction, thisRoom.playAreaWidth(), thisRoom.playAreaHeight());
        int mirrorX = Misc.clamp(normalX, otherRoom.playAreaWidth());
        int mirrorY = Misc.clamp(normalY, otherRoom.playAreaHeight());
        PartsUsed open = new PartsUsed(new Open(true));
        Direction mirror = Misc.mirror(direction);
        if (direction == Direction.right || direction == Direction.down)
        {
            int tx = normalX, ty = normalY;
            normalX = mirrorX;
            normalY = mirrorY;
            mirrorX = tx;
            mirrorY = ty;
        }

        thisRoom.setEntity(new Door($"door_{direction}", normalX, normalY, open));
        otherRoom.setEntity(new Door($"door_{mirror}", mirrorX, mirrorY,  open));
    }

    private (int x, int y) doorPos(Direction direction, int x, int y)
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

    private Direction strDir(char letter)
    {
        letter = letter.ToString().ToUpper()[0];
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