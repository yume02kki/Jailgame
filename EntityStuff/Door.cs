using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Door : Entity, Icollide, Iopen, Renderable
{
    private OpenLock _openLockPart;
    // private Open openPart;
    private Open openPart;
    private Use usePart;
    private bool isUsed = false;
public Door(string name, int x, int y, Direction direction,Open open,Use use=null) : base(name, x, y)
{
    this.openPart = open;
    this.usePart = use;
}

public override string icon() =>  this.openPart.isOpen ? "☐" : "▥";
public void open() => this.openPart.execute();
public void use(string item) => this.usePart.execute();
public override bool collide() => !openPart.isOpen;
}