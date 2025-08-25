using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class OnLoad : Component<VoidType>
{
    [JsonConstructor]
    public OnLoad()
    {
        getFunction();
    }

    public OnLoad(Action action)
    {
        setFunction(action);
    }
}