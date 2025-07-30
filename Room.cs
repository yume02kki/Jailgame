using System;

class Room
{
    private Room? upRoom;
    private Room? rightRoom;
    private Room? downRoom;
    private Room? leftRoom;
    private String name = "";

    public Room(String name)
    {
        this.upRoom = null;
        this.rightRoom = null;
        this.downRoom = null;
        this.leftRoom = null;
        this.name = name;
    }

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

    public void linkRoom(Direction direction, Room otherRoom)
    {
        switch (direction)
        {
            case Direction.up: this.upRoom = otherRoom; otherRoom.downRoom = this; break;
            case Direction.right: this.rightRoom = otherRoom; otherRoom.leftRoom = this; break;
            case Direction.down: this.downRoom = otherRoom; otherRoom.upRoom = this; break;
            case Direction.left: this.leftRoom = otherRoom; otherRoom.rightRoom = this; break;
        }
    }

    public String getName()
    {
        return this.name;
    }
    public override string ToString()
    {
        return this.name;
    }
}


