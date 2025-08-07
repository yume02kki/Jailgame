using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;
using MazeGame.Commands;

namespace MazeGame.Entitys;

public class Door : Entity, Icollide, Iopen
{
    private OpenLock _openLockPart;
    // private Open openPart;
    private Open openPart;
    private Use usePart;
    private bool isUsed = false;
public Door(string name, int x, int y, DoorCommands commands,Open open,Use use=null) : base(name, x, y, commands)
{
    this.openPart = open;
    this.usePart = use;
}

public void open() => this.openPart.execute();
public void use(string item) => this.usePart.execute(item);
public override bool collide() => !openPart.isOpen;
}