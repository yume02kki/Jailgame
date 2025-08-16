using MazeGame.MazeGame.Core.Enums;

namespace MazeGame.MazeGame.Core;

public static class Util
{
    public static Dictionary<Direction,IntVector2> directionVector { get; } = new Dictionary<Direction,IntVector2>
    {
        { Direction.UP, new IntVector2(0,1) },
        { Direction.DOWN, new IntVector2(0, -1) },
        { Direction.LEFT, new IntVector2(-1, 0) },
        { Direction.RIGHT, new IntVector2(1, 0) }
    };

    public static Dictionary<Direction, Direction> mirrorDirection { get; } = new Dictionary<Direction, Direction>
    {
        { Direction.UP, Direction.DOWN },
        { Direction.DOWN, Direction.UP },
        { Direction.LEFT, Direction.RIGHT },
        { Direction.RIGHT, Direction.LEFT }
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