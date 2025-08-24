using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Utility;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Enforcers;

public class MovementEnforcer
{
    private Player player { get; set; }

    public void runAll(Player player, Directions direction)
    {
        this.player = player;
        IntVector2 posOffset = new IntVector2(TransformDirection.directionVector[direction]) * new IntVector2(1, -1); //Y to Column

        if (collide(posOffset)) return;
        if (isPortal(posOffset))
        {
            player.currentNode = player.currentNode.neighbbors[direction]!;
            roomSwitchHook();

            player.pos = wrapPosAround(posOffset);
        }
        else if (isClipping(posOffset)) return;


        player.pos += posOffset;
    }

    private void roomSwitchHook()
    {
        player.currentNode.room.getEntityList().ForEach(entity => entity.components.execute(typeof(OnLoad)));
    }

    private bool collide(IntVector2 offsetPos) => (bool?)player.currentNode.room.tryGet(player.pos + offsetPos)?.components.execute(typeof(Collide)) ?? false;

    private bool isPortal(IntVector2 offsetPos) => player.currentNode.room.tryGet(player.pos + offsetPos)?.tags.Contains(Tags.Doorway) ?? false;

    private IntVector2 wrapPosAround(IntVector2 offsetPos)
    {
        IntVector2 result = new IntVector2(
            Misc.wrapAround(player.pos.X + offsetPos.X, player.currentNode.room.getPlayareaWidth())
            , Misc.wrapAround(player.pos.Y + offsetPos.Y, player.currentNode.room.getPlayareaHeight()));
        return result;
    }

    private bool isClipping(IntVector2 offsetPos)
    {
        IntVector2 newPos = new IntVector2(offsetPos + player.pos);
        return player.currentNode.room.getPlayareaWidth() <= newPos.X || newPos.X == 0 ||
               player.currentNode.room.getPlayareaHeight() <= newPos.Y || newPos.Y == 0;
    }
}