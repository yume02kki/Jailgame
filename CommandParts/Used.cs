using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Used : Iexecute
{
    private Obj _user;
    public Used(Obj user)
    {
        _user = user;
    }
    
    public Obj get() => _user;
    
    //TODO: fix interface segregation 
    public void execute()
    {
    }
}