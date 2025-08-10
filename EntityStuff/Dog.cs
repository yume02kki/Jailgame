using System.Collections.Concurrent;
using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Entitys;

public class Dog : Entity, Icollide, Iused, Irender
{
    private bool hungry = true;
    Render _renderOpen = new Render("☖", ConsoleColor.Yellow);
    Render _renderClosed = new Render("☗",ConsoleColor.Yellow);

    public Dog(string name, int x, int y, PartsUsed parts) : base(name, x, y, parts)
    {
    }

    public override Render getRender() => hungry ?_renderClosed:_renderOpen;
    public void used(Obj user)
    {
        if (user == parts.get<Used>().get())
        {
            hungry = false;
        }
    }

    
    public override bool collide() => hungry;
}