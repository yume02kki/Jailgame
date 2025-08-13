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

    public static (int, int) addTuples((int a, int b) aPair, (int a, int b) bPair)
    {
        return (aPair.a + bPair.a, aPair.b + bPair.b);
    }

    public static (int, int) directionToPosition(Direction direction)
    {
        int x = 0;
        int y = 0;
        switch (direction)
        {
            case Direction.up:
                y++;
                break;
            case Direction.down:
                y--;
                break;
            case Direction.left:
                x--;
                break;
            case Direction.right:
                x++;
                break;
        }

        return (x, y);
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