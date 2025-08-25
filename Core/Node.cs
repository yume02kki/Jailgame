using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Utility;

namespace MazeGame.MazeGame.Core;

public class Node
{
    public Room room { get; set; }
    private static int nodeId = 0;
    private static Dictionary<int, Node> allNodes { get; set; } = new Dictionary<int, Node>();
    public int[] neighbors { get; set; } = [-1, -1, -1, -1]; // up down left right
    public int myId { get; set; }

    public Node(Room room)
    {
        myId = nodeId;
        allNodes[myId] = this;
        nodeId++;

        this.room = room;
    }

    public Node? getNeighbor(Directions direction) => allNodes[neighbors[(int)direction]];

    public void link(Directions direction, Node? target)
    {
        if (target == null) return;
        neighbors[(int)direction] = target.myId;
        Directions mirrorDirection = TransformDirection.mirrorDirection[direction];
        allNodes[target.myId].neighbors[(int)mirrorDirection] = myId;
    }
}