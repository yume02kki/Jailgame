using System;

class GFG
{
    public static void Main(String[] args)
    {
        Boolean temp = false;
        var rooms = new Dictionary<string, Room>
        {
            ["C4"] = new DecoratedRoom("C4", () => temp && true),
            //["C4"] = new DecoratedRoom("C4", () => isLocked && true),
            ["B4"] = new Room("B4"),
            ["B3"] = new Room("B3"),
            ["B2"] = new Room("B2"),
            ["C2"] = new Room("C2"),
            ["C1"] = new Room("C1"),
            ["B1"] = new Room("B1"),
            ["A1"] = new Room("A1")
        };


        rooms["C4"].linkRoom(Direction.left, rooms["B4"]);
        rooms["B4"].linkRoom(Direction.up, rooms["B3"]);
        rooms["B3"].linkRoom(Direction.up, rooms["B2"]);
        rooms["B2"].linkRoom(Direction.up, rooms["B1"]);
        rooms["B2"].linkRoom(Direction.right, rooms["C2"]);
        rooms["C2"].linkRoom(Direction.up, rooms["C1"]);
        rooms["C1"].linkRoom(Direction.left, rooms["B1"]);
        rooms["B1"].linkRoom(Direction.left, rooms["A1"]);

        Player player = new Player(rooms["C4"]);

        Terminal.renderPlayer(player); //c4

        player.move(Direction.left);
        Terminal.renderPlayer(player); //c4

        temp = true;
        player.move(Direction.left);
        Terminal.renderPlayer(player); //b4
    }
}