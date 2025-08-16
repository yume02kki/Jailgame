using System.Numerics;

namespace MazeGame.MazeGame.Core.Misc;

public static class Util
{
    public static Dictionary<Direction,IntVector2> directionVector { get; } = new Dictionary<Direction,IntVector2>
    {
        { Direction.up, new IntVector2(0, 1) },
        { Direction.down, new IntVector2(0, -1) },
        { Direction.left, new IntVector2(-1, 0) },
        { Direction.right, new IntVector2(1, 0) }
    };

    public static Dictionary<Direction, Direction> mirrorDirection { get; } = new Dictionary<Direction, Direction>
    {
        { Direction.up, Direction.down },
        { Direction.down, Direction.up },
        { Direction.left, Direction.right },
        { Direction.right, Direction.left }
    };
    
    public static int clamp(int num, int border)
    {
        return (num >= border) ? 0 : (num <= 0 ? border : num);
    }

    public static string listToString(List<string> list)
    {
        return string.Join(", ", list);
    }
}