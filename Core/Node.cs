using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Utility;

namespace MazeGame.MazeGame.Core;

public class Node
{
    [JsonIgnore] public Dictionary<Directions, Node?> neighbbors { get; }
    public Room room { get; set; }

    [JsonConstructor]
    public Node() { }

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
        target.neighbbors[TransformDirection.mirrorDirection[direction]] = this;
    }
}