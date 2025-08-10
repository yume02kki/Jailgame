using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Open:Iexecute
{
    private bool _isOpen;
    
    public Open(bool isOpen=true)
    {
        this._isOpen = isOpen;
    }
    public void execute()
    {
        _isOpen = true;
    }

    public bool isOpen
    {
        get => _isOpen;
        set => _isOpen = value;
    }
    
}