using System.Reflection;
using System.Text;
using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Bed : Entity, Iexamine
{
    private Examine examinePart;

    public Bed(string name, int x, int y, Examine examinePart) : base(name, x, y)
    {
        this.examinePart = examinePart;
    }

    public void examine() => this.examinePart.execute();
    public override string icon() => "_";
}