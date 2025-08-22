using System.Text.Json;
using System.Xml.Serialization;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Serialization;

public static class GameSaver
{
    static readonly JsonSerializerOptions jsonOptions = new()
    {
        WriteIndented = true,
    };

    static GameSaver()
    {
        jsonOptions.Converters.Add(new IntVector2Converter());
    }

    public static void save(object anyObject)
    {
        using FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.json", FileMode.Create);
        JsonSerializer.Serialize(fs, anyObject,jsonOptions);

        Terminal.log(JsonSerializer.Serialize(anyObject,jsonOptions)); //debug
    }

    public static T? load<T>() where T : class
    {
        using FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.json", FileMode.Open);
        return JsonSerializer.Deserialize<T>(fs,jsonOptions);
    }
}