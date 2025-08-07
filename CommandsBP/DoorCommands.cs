using MazeGame.CommandInterfaces;
using MazeGame.Entitys;

namespace MazeGame.Commands;

public class DoorCommands : Commands,Iopen,Iuse,Renderable,Icollide
{
    private bool opened;
    private bool locked;
    private Direction direction;
    
    public DoorCommands(Direction direction,bool opened=false,bool locked=false)
    {
        this.locked = locked;
        this.opened = opened;
    }

    public void open()
    {
        if (!locked)
        {
            this.opened = true;
        }
    }

    public bool collide()
    {
        return !this.opened;
    }


    public void use(string item)
    {
        if (item == "needle")
        {
            Console.WriteLine("unlock door");
            this.locked = false;
        }
    }

    public string icon() =>  this.opened ? "☐" : "▥";
}