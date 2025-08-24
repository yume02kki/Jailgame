using MazeGame.MazeGame.Core.Interactables;

namespace MazeGame.MazeGame.Core.Managers;

public static class GameManager
{
    public static bool run(string command, List<Entity> arguments)
    {
        try
        {
            CommandManager.commander[command](arguments);
            return true;
        }

        catch (InvalidCastException exception)
        { }
        catch (KeyNotFoundException exception)
        { }

        return false;
    }
}