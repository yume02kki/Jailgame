using MazeGame.MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Dog : Entity
{
    private bool hungry = true;
    Render _renderOpen = new Render("☖", ConsoleColor.Yellow);
    Render _renderClosed = new Render("☗",ConsoleColor.Yellow);

    public Dog(string name, int x, int y, params List<Part> parts) : base(name, x, y, parts)
    {
    }

    public override Render getRender() => hungry ?_renderClosed:_renderOpen;
    
    public override bool collide() => hungry;
}