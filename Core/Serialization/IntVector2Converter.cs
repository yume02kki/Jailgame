using System.Text.Json;
using System.Text.Json.Serialization;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core;

public class IntVector2Converter : JsonConverter<IntVector2>
{
    public override IntVector2 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? str = reader.GetString();
        if (str == null) return default;

        string[] coordinates = str[(str.IndexOf('(')+1)..str.IndexOf(')')].Split(',');

        return new IntVector2(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
    }

    public override void Write(Utf8JsonWriter writer, IntVector2 value, JsonSerializerOptions options) => writer.WriteStringValue($"IntVector2({value.X},{value.Y})");

    public override IntVector2 ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => Read(ref reader, typeToConvert, options);
    public override void WriteAsPropertyName(Utf8JsonWriter writer, IntVector2 value, JsonSerializerOptions options) => writer.WritePropertyName($"IntVector2({value.X},{value.Y})");
}