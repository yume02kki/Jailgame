using MazeGame.Entitys;

namespace MazeGame;

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
            Direction.up => upRoom,
            Direction.right => rightRoom,
            Direction.down => downRoom,
            Direction.left => leftRoom,
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
            case Direction.up:
                this.upRoom = otherRoom;
                otherRoom.downRoom = this;
                break;
            case Direction.right:
                this.rightRoom = otherRoom;
                otherRoom.leftRoom = this;
                break;
            case Direction.down:
                this.downRoom = otherRoom;
                otherRoom.upRoom = this;
                break;
            case Direction.left:
                this.leftRoom = otherRoom;
                otherRoom.rightRoom = this;
                break;
        }

    }

    public void setEntity(Entity entity)
    {
        entityDict[entity.Name] = entity;
        map[entity.x, entity.y] = entity;
    }

    public Entity? getEntity(string name)
    {
        return entityDict.Values.ToList().Find((a) => a.Name == name);
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

    public Entity? tryGet(int x, int y)
    {
        if (x >= 0 && x < getWidth() && y >= 0 && y < getHeight())
        {
            return map[x, y];
        }

        return null;
    }
}