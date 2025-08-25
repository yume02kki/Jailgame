using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class OnLoad : Component<VoidType>
{
    [JsonConstructor]
    public OnLoad() : base(null)
    { }

    public OnLoad(string name, Action action) : base(name)
    {
        setFunction(action);
    }
}