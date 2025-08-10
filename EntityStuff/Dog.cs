using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Entitys;

public class Dog : Entity, Icollide, Iused, Irender, Ilocked
{
    Render _renderOpen =  new Render("☖",ConsoleColor.Yellow);
    Render _renderClosed =  new Render("☗",ConsoleColor.Red);
    
    public Dog(string name, int x, int y, PartsUsed parts) : base(name, x, y, parts)
    {
    }

    public override Render getRender() => (parts.get<Open>()?.isOpen ?? false) ? _renderOpen: _renderClosed;
    public void unlock() => parts.get<OpenLock>()?.unlock();
    public void used()
    {
        unlock();
        parts.execute<Open>();
    }

    public override bool collide() => !parts.get<Open>()?.isOpen ?? false;
}