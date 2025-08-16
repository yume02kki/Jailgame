using MazeGame.MazeGame.Core.Module;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Application.Commands;

public class Renders : fetcher<Render>
{
    private Queue<Render> _renders;
    private Func<bool> _hook;
    private Render _renderDefault;
    private Render? _renderChanged;

    public Renders(Func<bool> hook, Render renderDefault, Render renderChanged)
    {
        _renderDefault = renderDefault;
        _renderChanged = renderChanged;
        _hook = hook;
    }

    public Renders(Render renderDefault)
    {
        _renderDefault = renderDefault;
        _renderChanged = null;
        _hook = () => true;
    }

    public override Render read() => _hook() ? _renderDefault : (_renderChanged ?? _renderDefault);
}