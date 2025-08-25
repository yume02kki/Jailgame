using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Collide : Component<bool>
{
    [JsonConstructor]
    public Collide()
    {
        getFunction(() => false);
    }

    public Collide(string name, Func<bool> value) : base(name)
    {
        setFunction(value);
    }
}