namespace MazeGame.MazeGame.Core.Interactables;

public class Room
{
    private Entity[,] map;
    private string name;
    private Dictionary<string, Entity> entityDict = new();

    public Room(string name, int width, int height)
    {
        map = new Entity[width, height];
        this.name = name;
    }

    public List<Entity> getEntityList() => entityDict.Values.ToList();

    public void setEntity(Entity entity)
    {
        entityDict[entity.name] = entity;
        map[entity.pos!.Value.X, entity.pos!.Value.Y] = entity;
    }

    public Entity? getEntity(string name) => entityDict.Values.ToList().Find(entity => (entity.name == name));

    public override string ToString() => this.name;

    public int getWidth() => map.GetLength(0);
    public int getHeight() => map.GetLength(1);
    public int getPlayareaWidth() => getWidth() - 1;
    public int getPlayareaHeight() => getHeight() - 1;

    public Entity? tryGet(IntVector2 pos)
    {
        if (pos.X >= 0 && pos.X < getWidth() && pos.Y >= 0 && pos.Y < getHeight())
        {
            return map[pos.X, pos.Y];
        }

        return null;
    }
}