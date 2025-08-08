using MazeGame.CommandInterfaces;
using MazeGame.Entitys;
using MazeGame.MazeGame.CommandParts;

namespace MazeGame.Items;

public class Needle : Obj, Iuse
{

    public Needle(string name, PartsUsed parts) : base(name,parts)
    {
    }

    public void use() => parts.execute<Use>();
}