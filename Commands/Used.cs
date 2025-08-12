using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Used : Writer
{
    public Used(Obj expected, Action action) : base((sender) =>
    {
        if (sender == expected)
        {
            action();
        }
    })
    {
    }
}