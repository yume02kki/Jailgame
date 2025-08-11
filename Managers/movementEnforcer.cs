using MazeGame.Entitys;

namespace MazeGame;

public class movementEnforcer
{
    private int new_x;
    private int new_y;
    private Player player;
    public movementEnforcer(Player player){
        this.player = player;
    }

    public void setOffset(int offset_x, int offset_y)
    {
        new_x = player.x + offset_x;
        new_y = player.y + offset_y;
    }

    public bool collide()
    {
        return player.currentRoom.tryGet(new_x, new_y)?.collide()??false;
    }
    public bool isPortal()
    {
        return (player.currentRoom.tryGet(new_x, new_y) is Door && !player.currentRoom.tryGet(new_x, new_y)!.collide());
    }

    public int xClamp(int x_offset)
    {
            return Util.clamp(player.x+x_offset, player.currentRoom.playAreaWidth());
    }
    public int yClamp(int y_offset)
    {
            return Util.clamp(player.y+y_offset, player.currentRoom.playAreaHeight());
    }

    public bool isClipping()
    {
        return (player.currentRoom.playAreaWidth() <= new_x || new_x == 0) || (player.currentRoom.playAreaHeight() <= new_y || new_y == 0);
    }
}