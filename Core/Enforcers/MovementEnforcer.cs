using System.Text.Json.Serialization;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Utility;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Enforcers;
public class MovementEnforcer(Player player)
{
    public void runAll(Directions direction)
    {
        IntVector2 posOffset = new IntVector2(TransformDirection.directionVector[direction]) * new IntVector2(1, -1); //Y to Column
        
        if (collide(posOffset)) return;
        if (isPortal(posOffset))
        {
            player.currentNode = player.currentNode.neighbbors[direction]!;
            roomSwitchHook();

            player.pos = wrapPosAround(posOffset);
        }
        else if(isClipping(posOffset)) return;
        

        player.pos += posOffset;
    }

    public void roomSwitchHook()
    {
        player.currentNode.room.getEntityList().ForEach(entity => entity.components.execute<OnLoad>());
    }

    public bool collide(IntVector2 offsetPos)
    {
        return player.currentNode.room.tryGet(player.pos + offsetPos)?.components.read<bool, Collide>()??false;
    }

    public bool isPortal(IntVector2 offsetPos)
    {
        return player.currentNode.room.tryGet(player.pos + offsetPos)?.tags.Contains(Tags.Doorway) ?? false;
    }

    public IntVector2 wrapPosAround(IntVector2 offsetPos)
    {
        IntVector2 result = new()
        {
            X = Misc.wrapAround(player.pos.X + offsetPos.X, player.currentNode.room.getPlayareaWidth()),
            Y = Misc.wrapAround(player.pos.Y + offsetPos.Y, player.currentNode.room.getPlayareaHeight())
        };
        return result;
    }

    public bool isClipping(IntVector2 offsetPos)
    {
        IntVector2 newPos = new IntVector2(offsetPos + player.pos);
        return (player.currentNode.room.getPlayareaWidth() <= newPos.X || newPos.X == 0) ||
               (player.currentNode.room.getPlayareaHeight() <= newPos.Y || newPos.Y == 0);
    }
}