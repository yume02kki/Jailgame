
using System;

class Player
{
    private Room? currentRoom = null;

    public Room? getCurrentRoom()
    {
        return this.currentRoom;
    }
    public void setCurrentRoom(Room? room)
    {
        this.currentRoom = room;
    }

    public static void move(Direction direction)
    {

    }
    // Main Method
}