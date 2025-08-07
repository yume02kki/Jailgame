using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Use : ExecutableArgs
{
    private string itemRequired;
    private Action action;
    public Use(string itemRequired,Action action)
    {
        this.itemRequired = itemRequired;
        this.action = action;
    }

    public void execute(string item)
    {
        if (item == itemRequired)
        {
            action();
        }
    }
}