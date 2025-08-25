using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Used : Component<bool>
{
    [JsonConstructor]
    public Used()
    {
        getFunction();
    }


    public Used(Entity expected, Action<Entity> action)
    {
        setFunction((Action<Entity>)(sender =>
        {
            if (sender == expected) action(sender);
        }));
    }
}