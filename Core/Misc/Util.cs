using System.Numerics;

namespace MazeGame.MazeGame.Core.Misc;

public static class Util
{
    public static int clamp(int num, int border)
    {
        return (num >= border) ? 0 : (num <= 0 ? border : num);
    }

    public static string listToString(List<string> list)
    {
        return string.Join(", ", list);
    }

    public static IntVector2 directionToPosition(Direction direction)
    {
        IntVector2 pos = new IntVector2(0,0);
        switch (direction)
        {
            case Direction.up:
                pos.Y++;
                break;
            case Direction.down:
                pos.Y--;
                break;
            case Direction.left:
                pos.X--;
                break;
            case Direction.right:
                pos.X++;
                break;
        }

        return pos;
    }

    public static Direction mirrorDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                return Direction.down;
            case Direction.down:
                return Direction.up;
            case Direction.left:
                return Direction.right;
            case Direction.right:
                return Direction.left;
            default:
                return direction;
        }
    }
}