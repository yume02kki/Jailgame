using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Application.Commands;

public class Locked : Open
{
    public bool isLocked { get; set; }
    public Entity? expected { get; set; }


    public Locked(Entity expected)
    {
        setFunction(item =>
        {
            if (isLocked) return false;
            if (item == expected)
            {
                isLocked = false;
                isOpen = true;
                return false;
            }

            return isOpen;
        });
    }
}