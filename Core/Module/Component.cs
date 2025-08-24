using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;
using MazeGame.MazeGame.Application.Commands;

namespace MazeGame.MazeGame.Core.Module;

public readonly struct VoidType
{
    public static readonly VoidType empty = new VoidType(); //readonly static therefore nothing happens
}

[JsonDerivedType(typeof(Collide), "Collide")]
[JsonDerivedType(typeof(Examine), "Examine")]
[JsonDerivedType(typeof(Locked), "Locked")]
[JsonDerivedType(typeof(OnLoad), "OnLoad")]
[JsonDerivedType(typeof(Open), "Open")]
[JsonDerivedType(typeof(Renders), "Renders")]
[JsonDerivedType(typeof(Used), "Used")]
public interface Icomponent
{
    public object? execute(object? argument = null);
};

public class Component<returnType> : Icomponent
{
    [JsonIgnore] public Func<object?, returnType> function { get; private set; }
    public Dictionary<string, object> data { get; set; }

    private static Dictionary<string, Func<object?, returnType>> registry = new Dictionary<string, Func<object?, returnType>>();


    public Component()
    {
        data = new Dictionary<string, object>();
    }

    public void set(params (string key, object value)[] pairs) => pairs.ToList().ForEach(pair => data[pair.key] = pair.value);

    public void writeRegister(string name, Func<object?, returnType> func) => function = registry[name] = func;
    public Func<object?, returnType>? readRegister(string name) => registry.GetValueOrDefault(name);

    public void setFunction(Func<object?, returnType> func) => function = func;
    public void setFunction(Func<returnType> func) => setFunction(_ => func());

    public void setFunction(Action<object?> action) => setFunction(arg =>
    {
        action(arg);
        return default!;
    });

    public void setFunction(Action action) => setFunction(_ =>
    {
        action();
        return default!;
    });

    public object? execute(object? argument = null) => function(argument);
}