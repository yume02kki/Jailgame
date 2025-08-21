using System.Text.Json;
using System.Xml.Serialization;

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
        using FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Save.xml", FileMode.Create);
        JsonSerializer.Serialize(fs, anyObject);

        Console.WriteLine(JsonSerializer.Serialize(anyObject)); //debug
    }

    public static T? load<T>() where T : class
    {
        using FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Save.xml", FileMode.Open);
        return JsonSerializer.Deserialize<T>(fs);
    }
}