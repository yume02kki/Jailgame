using MazeGame.MazeGame.Core.Enums;

namespace MazeGame.MazeGame.Core.Utility;

public static class TransformDirection
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
}