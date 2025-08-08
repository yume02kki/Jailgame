using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Entitys;

public class Door : Entity, Icollide, Iopen,Iused, Irender,Ilocked
{
public Door(string name, int x, int y, Direction direction,PartsUsed parts) : base(name, x, y,parts)
{
}

public override string icon() => (parts.get<Open>()?.isOpen??false) ? "☐" : "▥";
public void open() => parts.execute<Open>();
public void unlock() => parts.get<OpenLock>()?.unlock();
public void used() => unlock();
public override bool collide() => !parts.get<Open>()?.isOpen??false;
}