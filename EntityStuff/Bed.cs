using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Entitys;

public class Bed : Entity, Iexamine,Irender
{
    private Render _render = new Render("_",ConsoleColor.Blue);
    public Bed(string name, int x, int y, PartsUsed parts) : base(name, x, y,parts)
    {
    }

    public void examine() => parts.execute<Examine>();
    public override Render getRender() => _render;
}