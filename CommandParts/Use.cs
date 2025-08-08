using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Use : Iuse
{

    public void use(Entity entity)
    {
        if (entity is Iused)
        {
            ((Iused)entity).used();
        }
    }
}