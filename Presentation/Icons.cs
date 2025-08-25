using MazeGame.MazeGame.Presentation;

public static class Icons
{
    public static Render get(string iconName) => icons.GetValueOrDefault(iconName);


    private static Dictionary<string, Render> icons = new Dictionary<string, Render>
    {
        ["doorOpen"] = new("☐", ConsoleColor.Green),
        ["doorClosed"] = new("▥", ConsoleColor.Red),
        ["bed"] = new("_", ConsoleColor.Blue),
        ["dogHungry"] = new("☗", ConsoleColor.Yellow),
        ["dogFed"] = new("☖", ConsoleColor.Yellow),
        ["bowl"] = new("◡", ConsoleColor.Yellow),
        ["guard"] = new("¶", ConsoleColor.Blue),
        ["crown"] = new("♕", ConsoleColor.Yellow),
        ["player"] = new("☺"),

        ["topLeftCorner"] = new("╔"),
        ["topRightCorner"] = new("╗"),
        ["bottomLeftCorner"] = new("╚"),
        ["bottomRightCorner"] = new("╝"),
        ["wallX"] = new("═"),
        ["wallY"] = new("║"),
    };
}