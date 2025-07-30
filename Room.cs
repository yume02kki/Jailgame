using System;

class Room
{
    private String name = "";
    private Room? upRoom = null;
    private Room? rightRoom = null;
    private Room? downRoom = null;
    private Room? leftRoom = null;

    public Room? getRoom(Direction direction)
    {
        return direction switch
        {
            Direction.up => upRoom,
            Direction.right => rightRoom,
            Direction.down => downRoom,
            Direction.left => leftRoom,
            _ => null
        };
    }

    public void SetRoom(Direction direction, Room? room)
    {
        switch (direction)
        {
            case Direction.up: this.upRoom = room; break;
            case Direction.right: this.rightRoom = room; break;
            case Direction.down: this.downRoom = room; break;
            case Direction.left: this.leftRoom = room; break;
        }
    }

    public String getName()
    {
        return this.name;
    }

    public void setName(String name)
    {
        this.name = name;
    }
}


