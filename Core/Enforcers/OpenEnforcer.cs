using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Interactables;

namespace MazeGame.MazeGame.Core.Enforcers;

public class OpenEnforcer
{
    [JsonInclude] private Entity key { get; set; }
    public bool allow { get; set; }

    public OpenEnforcer(Entity key)
    {
        this.key = key;
        allow = false;
    }

    public void unlock(Entity item)
    {
        if (key == item) allow = true;
    }
}