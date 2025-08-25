using System.Diagnostics;
using System.Text.Json.Serialization;
using MazeGame.MazeGame.Application.Commands;

namespace MazeGame.MazeGame.Core.Module;

public readonly struct VoidType
{
    public static readonly VoidType empty = new VoidType();
}

[JsonDerivedType(typeof(Collide), "Collide")]
[JsonDerivedType(typeof(Examine), "Examine")]
[JsonDerivedType(typeof(OnLoad), "OnLoad")]
[JsonDerivedType(typeof(Open), "Open")]
[JsonDerivedType(typeof(Renders), "Renders")]
[JsonDerivedType(typeof(Used), "Used")]
public interface Icomponent
{
    public object? execute(object? argument = null);
}

public class Component<Treturn> : Icomponent
{
    private static int entityId { get; set; } = 0;
    public int myId { get; set; }
    private static readonly Dictionary<int, Delegate> registry = new Dictionary<int, Delegate>();

    public Component()
    {
        myId = entityId++;
    }

    public Delegate getFunction(Delegate? fallback = null)
    {
        fallback ??= () => { };
        return registry.TryGetValue(myId, out Delegate? found) ? found : fallback;
    }


    public void setFunction(Delegate func)
    {
        registry[myId] = func;
    }


    public object? execute(object? arg = null)
    {
        Delegate func = getFunction();
        var paramsCount = func.Method.GetParameters().Length;
        return paramsCount == 0 ? func.DynamicInvoke() : func.DynamicInvoke(arg);
    }
}