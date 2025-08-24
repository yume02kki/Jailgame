using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using MazeGame.MazeGame.Core.Module;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Application.Commands;

public class Renders : Component<Render>
{
    public Render renderDefault { get; set; }
    public Render? renderChanged { get; set; }
    [JsonInclude] private string? name { get; set; }
    private Func<Render> getRender { get; set; }

    [JsonConstructor]
    public Renders()
    {
        setFunction(() =>
            {
                if (name != null)
                {
                    return readRegister(name)!(null);
                }

                return renderDefault;
            }
        );
    }


    public Renders(Render renderDefault, Render? renderChanged = null, Func<bool>? hook = null, string? name = null)
    {
        this.renderDefault = renderDefault;
        this.name = name;
        this.renderChanged = renderChanged;
        hook = hook ?? (() => true);
        getRender = () => hook() ? renderDefault : renderChanged ?? renderDefault;
        if (name != null) writeRegister(name, (_) => getRender());
        setFunction(_ => getRender());
    }
}