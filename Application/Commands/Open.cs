using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Enforcers;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Open : Component<VoidType>
{
    public bool isOpen { get; set; }
    public OpenEnforcer? enforcer { get; set; }

    [JsonConstructor]
    public Open()
    {
        getFunction();
    }

    public Open(string name, OpenEnforcer? enforcer = null) : base(name)
    {
        isOpen = false;
        this.enforcer = enforcer;
        setFunction(() => isOpen = enforcer?.allow ?? true);
    }
}