using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Collide : Component<bool>
{
    [JsonConstructor]
    public Collide()
    { }

    public Collide(Func<bool> value)
    {
        setFunction(_ => value());
    }
}