using System.Text.Json.Serialization;

namespace MazeGame.MazeGame.Presentation;

public class Render
{
    public string _icon { get; set; }
    public ConsoleColor? _color { get; set; }

    [JsonConstructor]
    public Render()
    { }

    public Render(string icon, ConsoleColor? color = null)
    {
        _icon = icon;
        _color = color;
    }

    public string icon() => _icon;

    public ConsoleColor? color() => _color;
}