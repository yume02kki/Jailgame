using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Open : Writer
{
    private bool _isOpen;
    private bool _locked;

    public Open(bool isOpen = true, bool locked = false)
    {
        this._isOpen = !locked && isOpen;
        this._locked = locked;
    }

    public void unlock()
    {
        _locked = false;
    }

    public override void execute()
    {
        _isOpen = !_locked;
    }

    public bool isOpen
    {
        get => _isOpen;
    }
}