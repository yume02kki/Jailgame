namespace MazeGame.MazeGame.Presentation;

public struct Render
{
    public string _icon {get; set; }
    public ConsoleColor? _color {get; set; }
    
    public Render(string icon, ConsoleColor? color=null)
    {
        _icon = icon;
        _color = color;
    }

    public string icon()
    {
        return this._icon;
    }

    public ConsoleColor? color()
    {
        return this._color;
    }
}