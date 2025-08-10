using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Entitys;

public class Door : Entity, Icollide, Iopen, Iused, Irender, Ilocked
{
    Render _renderOpen = new Render("☐", ConsoleColor.Green);
    Render _renderClosed = new Render("▥", ConsoleColor.Red);

    public Door(string name, int x, int y, PartsUsed parts) : base(name, x, y, parts)
    {
    }

    public override Render getRender() => (parts.get<Open>()?.isOpen ?? false) ? _renderOpen : _renderClosed;
    public void open() => parts.execute<Open>();
    public void unlock() => parts.get<OpenLock>()?.unlock();

    public void used(Obj user)
    {
        if (user == parts.get<Used>().get())
        {
            unlock();
        }
    }

public override bool collide() => !parts.get<Open>()?.isOpen ?? false;

}