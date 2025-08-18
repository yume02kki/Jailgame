using MazeGame.MazeGame.Core.Enums;

namespace MazeGame.MazeGame.Core.Interactables;

public class Node
{
    public Dictionary<Directions, Node?> neighbbors { get; }
    public Room room { get; set; }

    public Node(Room room, Node? up = null, Node? right = null, Node? down = null, Node? left = null)
    {
        this.room = room;
        neighbbors = new Dictionary<Directions, Node?>();

        link(Directions.UP, up);
        link(Directions.RIGHT, right);
        link(Directions.DOWN, down);
        link(Directions.LEFT, left);
    }

    public void link(Directions direction, Node? target)
    {
        if (target == null) return;

        neighbbors[direction] = target;
        target.neighbbors[Util.mirrorDirection[direction]] = this;
    }
}