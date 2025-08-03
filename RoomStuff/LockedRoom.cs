namespace MazeGame;

public class LockedRoom : Room, Scripted
{
    private Boolean _locked = true;

    public LockedRoom(string name) : base(name)
    {
    }

    public Boolean Locked
    {
        get => _locked;
        set => _locked = value;
    }

    public Boolean onEnter()
    {
        return Locked;
    }

}