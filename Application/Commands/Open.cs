using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Enforcers;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Open : Executor
{
    public bool isOpen { get; set; }
    [JsonInclude]
    private LockEnforcer? lockEnforcer;

    public Open(bool startsOpen = true, LockEnforcer? lockEnforcer = null)
    {
        this.isOpen = startsOpen && (!lockEnforcer?.isLocked ?? true);
        this.lockEnforcer = lockEnforcer;
    }

    public override void execute()
    {
        isOpen = true && (!lockEnforcer?.isLocked ?? true);
    }
}