using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Entitys;

public class Bed : Entity, Iexamine
{
    public Bed(string name, int x, int y, PartsUsed parts) : base(name, x, y,parts)
    {
    }

    public void examine() => parts.execute<Examine>();
    public override string icon() => "_";
}