using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Module;

namespace MazeGame.MazeGame.Application.Commands;

public class Open : Component<bool>
{
    public bool isOpen { get; set; }

    public Open()
    {
        setFunction(() =>
        {
            isOpen = true;
            return isOpen;
        });
    }
}