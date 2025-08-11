using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Open:Part
{
    private bool _isOpen;
    private bool _locked;
    
    public Open(bool isOpen=true,bool locked=false):base(_ => {})
    {
        _locked = locked;
        this._isOpen = isOpen&&!_locked;
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