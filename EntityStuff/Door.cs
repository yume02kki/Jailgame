using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Door : Entity
{
    Render _renderOpen = new Render("☐", ConsoleColor.Green);
    Render _renderClosed = new Render("▥", ConsoleColor.Red);

    public Door(string name, int x, int y, params List<Part> parts) : base(name, x, y, parts)
    {
    }

    public override Render getRender() => (parts.get<Open>()?.isOpen ?? false) ? _renderOpen : _renderClosed;

    public override bool collide() => !parts.get<Open>()?.isOpen ?? false;

}