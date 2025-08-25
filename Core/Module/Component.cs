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
    public string? name { get; set; }
    private static int entityId = 0;
    private static readonly Dictionary<string, Delegate> registry = new Dictionary<string, Delegate>();

    public Component(string? name = null)
    {
        this.name = "" + entityId;
        entityId++;
    }

    public Delegate getFunction(Delegate? fallback = null)
    {
        fallback ??= () => { };
        return name != null && registry.TryGetValue(name, out Delegate? found) ? found : fallback;
    }


    public void setFunction(Delegate func)
    {
        if (name != null) registry[name] = func;
    }


    public object? execute(object? arg = null)
    {
        Delegate func = getFunction();
        var paramsCount = func.Method.GetParameters().Length;
        return paramsCount == 0 ? func.DynamicInvoke() : func.DynamicInvoke(arg);
    }
}