
using System;
using System.Reflection.Metadata.Ecma335;

class Player
{
    private Room currentRoom;

    public Player(Room startingRoom)
    {
        this.currentRoom = startingRoom;
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }
    public void setCurrentRoom(Room room)
    {
        this.currentRoom = room;
    }

    public void move(Direction direction)
    {
        if (getCurrentRoom().getRoom(direction) != null)
        {
            setCurrentRoom(getCurrentRoom().getRoom(direction)!);
        }

    }
    // Main Method
}