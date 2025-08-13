namespace MazeGame.MazeGame.Core.Enforcers;

public class LockEnforcer
{
    public bool isLocked { get; set; }

    public LockEnforcer()
    {
        this.isLocked = true;
    }

    public void unlock()
    {
        this.isLocked = false;
    }
}