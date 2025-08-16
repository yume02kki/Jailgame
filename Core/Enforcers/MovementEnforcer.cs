using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core.Interactables;

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

    public void onLoad()
    {
        player.currentRoom.getEntityList().ForEach(entity => entity.components.execute<OnLoad>());
    }

    public bool collide()
    {
        return player.currentRoom.tryGet(
            player.pos + offsetPos)?.components.read<bool, Collide>() ?? false;
    }

    public bool isPortal()
    {
        return ((player.currentRoom.tryGet(player.pos + offsetPos))?.tags.Contains(Tags.Doorway) ?? false) &&
               !(player.currentRoom.tryGet(player.pos + offsetPos)?.components.read<bool, Collide>() ?? false);
    }

    public IntVector2 wrapPosAround()
    {
        IntVector2 result = new()
        {
            X = Util.wrapAround(player.pos.X + offsetPos.X, player.currentRoom.playAreaWidth()),
            Y = Util.wrapAround(player.pos.Y + offsetPos.Y, player.currentRoom.playAreaHeight())
        };
        return result;
    }

    public bool isClipping()
    {
        IntVector2 newPos = new IntVector2(offsetPos + player.pos);
        return (player.currentRoom.playAreaWidth() <= newPos.X || newPos.X == 0) ||
               (player.currentRoom.playAreaHeight() <= newPos.Y || newPos.Y == 0);
    }
}