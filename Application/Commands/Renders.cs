using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Module;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Application.Commands;

public class Renders : Component<Render>
{
    public Render renderDefault { get; set; }
    public Render? renderChanged { get; set; }

    [JsonConstructor]
    public Renders()
    {
        getFunction(() => renderDefault);
    }


    public Renders(Render renderDefault, Render? renderChanged = null, Func<bool>? hook = null)
    {
        this.renderDefault = renderDefault;
        this.renderChanged = renderChanged;
        hook ??= () => true;
        setFunction(() => hook() ? this.renderDefault : this.renderChanged ?? this.renderDefault);
    }
}