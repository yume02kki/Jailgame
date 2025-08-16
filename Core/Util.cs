using MazeGame.MazeGame.Core.Enums;

namespace MazeGame.MazeGame.Core;

public static class Util
{
    public static Dictionary<Directions, IntVector2> directionVector { get; } =
        new Dictionary<Directions, IntVector2>
        {
            { Directions.UP, new IntVector2(0, 1) },
            { Directions.DOWN, new IntVector2(0, -1) },
            { Directions.LEFT, new IntVector2(-1, 0) },
            { Directions.RIGHT, new IntVector2(1, 0) }
        };

    public static Dictionary<Directions, Directions> mirrorDirection { get; } =
        new Dictionary<Directions, Directions>
        {
            { Directions.UP, Directions.DOWN },
            { Directions.DOWN, Directions.UP },
            { Directions.LEFT, Directions.RIGHT },
            { Directions.RIGHT, Directions.LEFT }
        };

    public static int clamp(int num, int border)
    {
        return (num >= border) ? 0 : (num <= 0 ? border : num);
    }

    public static string listToString(List<string> list)
    {
        return string.Join(", ", list);
    }

    public static string enumToString(Enum value)
    {
        return value.ToString().ToLower();
    }
}