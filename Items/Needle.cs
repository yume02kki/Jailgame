using MazeGame.CommandInterfaces;
using MazeGame.Entitys;

namespace MazeGame.Items;

public class Needle : Obj, Iuse
{
    private Use usePart;

    public Needle(string name, Use usePart) : base(name)
    {
        this.usePart = usePart;
    }

    public void use(Entity ent) =>usePart.use(ent);
}