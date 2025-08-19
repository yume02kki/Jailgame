using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Utility;

namespace MazeGame.MazeGame.Core.Enforcers;

public class MovementEnforcer
{
    private Player player;
    private IntVector2 offsetPos;

    public MovementEnforcer(Player player, IntVector2 offsetPos)
    {
        this.offsetPos = offsetPos;
        this.player = player;
    }

    public void roomSwitchHook()
    {
        player.currentNode.room.getEntityList().ForEach(entity => entity.components.execute<OnLoad>());
    }

    public bool collide()
    {
        return player.currentNode.room.tryGet(
            player.pos + offsetPos)?.components.read<bool, Collide>() ?? false;
    }

    public bool isPortal()
    {
        return ((player.currentNode.room.tryGet(player.pos + offsetPos))?.tags.Contains(Tags.Doorway) ?? false) &&
               !(player.currentNode.room.tryGet(player.pos + offsetPos)?.components.read<bool, Collide>() ?? false);
    }

    public IntVector2 wrapPosAround()
    {
        IntVector2 result = new()
        {
            X = Misc.wrapAround(player.pos.X + offsetPos.X, player.currentNode.room.getPlayareaWidth()),
            Y = Misc.wrapAround(player.pos.Y + offsetPos.Y, player.currentNode.room.getPlayareaHeight())
        };
        return result;
    }

    public bool isClipping()
    {
        IntVector2 newPos = new IntVector2(offsetPos + player.pos);
        return (player.currentNode.room.getPlayareaWidth() <= newPos.X || newPos.X == 0) ||
               (player.currentNode.room.getPlayareaHeight() <= newPos.Y || newPos.Y == 0);
    }
}