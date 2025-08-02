namespace MazeGame;

public abstract class PlayerManager
{
    protected Player player;
    protected PlayerManager(Player player)
    {
        this.player = player;
    }
}