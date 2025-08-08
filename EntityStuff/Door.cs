using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Door : Entity, Icollide, Iopen,Iused, Irender
{
    private OpenLock _openLockPart;
    // private Open openPart;
    private Open openPart;
    private Action usedAction;
    private bool isUsed = false;
public Door(string name, int x, int y, Direction direction,Open open,Action used=null) : base(name, x, y)
{
    this.openPart = open;
    this.usedAction = used;
}

public override string icon() =>  this.openPart.isOpen ? "☐" : "▥";
public void open() => this.openPart.open();
public void used() => this.usedAction();
public override bool collide() => !openPart.isOpen;
}