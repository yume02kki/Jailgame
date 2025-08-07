using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Open:Executable 
{
    private bool _isOpen;
    
    public Open(bool isOpen=true)
    {
        this._isOpen = isOpen;
    }
    public virtual void execute()
    {
        _isOpen = true;
    }

    public bool isOpen
    {
        get => _isOpen;
        set => _isOpen = value;
    }
    
}