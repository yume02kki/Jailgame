namespace MazeGame;

public abstract class Misc
{
    public static int clamp(int num,int border)
    {
        return (num >= border) ? 0 : (num <= 0 ? border: num);
    }

    public static Direction mirror(Direction direction)
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