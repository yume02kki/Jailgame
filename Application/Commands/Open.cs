using MazeGame.MazeGame.Core.Enforcers;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Open : executor
{
    public bool isOpen { get; set; }
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