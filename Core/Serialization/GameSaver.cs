using System.Text.Json;
using System.Text.Json.Serialization;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Serialization;

public static class GameSaver
{
    private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
    {
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    };

    static GameSaver()
    {
        jsonOptions.Converters.Add(new IntVector2Converter());
    }

    public static void save(object anyObject)
    {
        using FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.json", FileMode.Create);
        JsonSerializer.Serialize(fs, anyObject, jsonOptions);
    }

    public static T? load<T>() where T : class
    {
        using FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.json", FileMode.Open);
        return JsonSerializer.Deserialize<T>(fs, jsonOptions);
    }
}