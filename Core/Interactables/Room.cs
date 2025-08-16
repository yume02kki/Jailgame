using MazeGame.MazeGame.Core.Enums;

namespace MazeGame.MazeGame.Core.Interactables;

public class Room
{
    private Room? upRoom;
    private Room? rightRoom;
    private Room? downRoom;
    private Room? leftRoom;
    private String name;
    Entity[,] map;
    private Dictionary<string, Entity> entityDict = new Dictionary<string, Entity>();

    public Room(String name, int width, int height)
    {
        map = new Entity[width, height];
        this.upRoom = null;
        this.rightRoom = null;
        this.downRoom = null;
        this.leftRoom = null;
        this.name = name;
    }

    public Room? getRoom(Direction direction)
    {
        return direction switch
        {
            Direction.UP => upRoom,
            Direction.RIGHT => rightRoom,
            Direction.DOWN => downRoom,
            Direction.LEFT => leftRoom,
            _ => null
        };
    }

    public List<Entity> getEntityList()
    {
        return entityDict.Values.ToList();
    }

    public void linkRoom(Direction direction, Room otherRoom)
    {
        switch (direction)
        {
            case Direction.UP:
                this.upRoom = otherRoom;
                otherRoom.downRoom = this;
                break;
            case Direction.RIGHT:
                this.rightRoom = otherRoom;
                otherRoom.leftRoom = this;
                break;
            case Direction.DOWN:
                this.downRoom = otherRoom;
                otherRoom.upRoom = this;
                break;
            case Direction.LEFT:
                this.leftRoom = otherRoom;
                otherRoom.rightRoom = this;
                break;
        }
    }

    public void setEntity(Entity entity)
    {
        entityDict[entity.name] = entity;
        if (entity.pos.HasValue)
        {
            map[entity.pos.Value.X, entity.pos.Value.Y] = entity;
        }
    }

    public Entity? getEntity(string name)
    {
        return entityDict.Values.ToList().Find(a => a.name == name);
    }

    public String getName()
    {
        return this.name;
    }

    public override string ToString()
    {
        return this.name;
    }

    public Entity[,] Map
    {
        get { return this.map; }
    }

    public int getWidth()
    {
        return this.map.GetLength(0);
    }

    public int playAreaWidth()
    {
        return getWidth() - 1;
    }

    public int playAreaHeight()
    {
        return getHeight() - 1;
    }

    public int getHeight()
    {
        return this.map.GetLength(1);
    }

    public Entity? tryGet(IntVector2 pos)
    {
        if (pos.X >= 0 && pos.X < getWidth() && pos.Y >= 0 && pos.Y < getHeight())
        {
            return map[pos.X, pos.Y];
        }

        return null;
    }
}