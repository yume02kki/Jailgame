using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Use : Executable
{
    private string itemRequired;
    private Action actionTarget;
    public Use(string itemRequired,Action action)
    {
        this.itemRequired = itemRequired;
        this.actionTarget = action;
    }

    public void execute()
    {
        // if (itemRequired)
        // {
            // actionTarget();
        // }
    }
}