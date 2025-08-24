using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Used : Component<bool>
{
    [JsonConstructor]
    public Used()
    { }


    public Used(Entity expected, Action<Entity> action)
    {
        setFunction((sender) =>
        {
            if (sender == expected) action((Entity)sender);
        });
    }
}