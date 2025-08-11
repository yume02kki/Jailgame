namespace MazeGame;

public struct Render
{
    private string _icon;
    private ConsoleColor? _color;
    public Render(string icon)
    {
        _icon = icon;
        _color = null;
    }
    public Render(string icon, ConsoleColor? color)
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