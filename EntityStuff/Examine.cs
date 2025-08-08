using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Examine:Executable
{
    private string _item;
    private Action<string> _action;

    public Examine(string item, Action<string> action)
    {
        _item = item;
        _action = action;
    }
    public void execute()
    {
        _action(_item);
    }
}