using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Utility;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Enforcers;

public static class MovementEnforcer
{
    public static void runAll(Directions direction)
    {
        Player player = GameCreator.Instance.player;

        IntVector2 posOffset = new IntVector2(TransformDirection.directionVector[direction]) * new IntVector2(1, -1); //Y to Column

        if (collide(posOffset, player)) return;
        if (isPortal(posOffset, player))
        {
            player.currentNode = player.currentNode.getNeighbor(direction) ?? player.currentNode;
            roomSwitchHook(player);

            player.pos = wrapPosAround(posOffset, player);
        }
        else if (isClipping(posOffset, player)) return;


        player.pos += posOffset;
    }

    private static void roomSwitchHook(Player player)
    {
        player.currentNode.room.getEntityList().ForEach(entity => entity.components.execute(typeof(OnLoad)));
    }

    private static bool collide(IntVector2 offsetPos, Player player) => (bool?)player.currentNode.room.tryGet(player.pos + offsetPos)?.components.execute(typeof(Collide)) ?? false;

    private static bool isPortal(IntVector2 offsetPos, Player player) => player.currentNode.room.tryGet(player.pos + offsetPos)?.tags.Contains(Tags.Doorway) ?? false;

    private static IntVector2 wrapPosAround(IntVector2 offsetPos, Player player)
    {
        IntVector2 result = new IntVector2(
            Misc.wrapAround(player.pos.X + offsetPos.X, player.currentNode.room.getPlayareaWidth())
            , Misc.wrapAround(player.pos.Y + offsetPos.Y, player.currentNode.room.getPlayareaHeight()));
        return result;
    }

    private static bool isClipping(IntVector2 offsetPos, Player player)
    {
        IntVector2 newPos = new IntVector2(offsetPos + player.pos);
        return player.currentNode.room.getPlayareaWidth() <= newPos.X || newPos.X == 0 ||
               player.currentNode.room.getPlayareaHeight() <= newPos.Y || newPos.Y == 0;
    }
}