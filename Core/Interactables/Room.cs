using System.Text.Json.Serialization;

namespace MazeGame.MazeGame.Core.Interactables;

public class Room
{
    public IntVector2 size { get; set; }
    public string name { get; set; }
    public Dictionary<IntVector2, Entity> map { get; set; }
    public Dictionary<string, Entity> entityDict { get; set; }

    [JsonConstructor]
    public Room()
    { }

    public Room(string name, IntVector2 size)
    {
        this.name = name;
        this.size = size;
        map = new Dictionary<IntVector2, Entity>();
        entityDict = new Dictionary<string, Entity>();
    }

    public List<Entity> getEntityList() => entityDict.Values.ToList();

    public void setEntity(Entity entity)
    {
        entityDict[entity.name] = entity;
        if (entity.pos is IntVector2 pos) map[pos] = entity;
    }

    public Entity? getEntity(string name) => entityDict.Values.ToList().Find(entity => entity.name == name);

    public override string ToString() => name;

    public int getWidth() => size.X;
    public int getHeight() => size.Y;
    public int getPlayareaWidth() => getWidth() - 1;
    public int getPlayareaHeight() => getHeight() - 1;

    public Entity? tryGet(IntVector2 pos)
    {
        if (pos.X >= 0 && pos.X < getWidth() && pos.Y >= 0 && pos.Y < getHeight())
        {
            return map.GetValueOrDefault(pos);
        }

        return null;
    }
}