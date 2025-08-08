using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Open:Iopen
{
    private bool _isOpen;
    
    public Open(bool isOpen=true)
    {
        this._isOpen = isOpen;
    }
    public virtual void open()
    {
        _isOpen = true;
    }

    public bool isOpen
    {
        get => _isOpen;
        set => _isOpen = value;
    }
    
}