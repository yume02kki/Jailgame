namespace MazeGame.MazeGame.Core.Utility;

public static class Misc
{
    public static int wrapAround(int num, int border)
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