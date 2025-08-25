using System.Text.Json.Serialization;

namespace MazeGame.MazeGame.Core;

public class IntVector2 : IEquatable<IntVector2>
{
    public int X { get; set; }
    public int Y { get; set; }

    public IntVector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public IntVector2(IntVector2 vector)
    {
        X = vector.X;
        Y = vector.Y;
    }

    public static IntVector2 operator +(IntVector2 a, IntVector2 b) => new IntVector2(a.X + b.X, a.Y + b.Y);
    public static IntVector2 operator -(IntVector2 a, IntVector2 b) => new IntVector2(a.X - b.X, a.Y - b.Y);
    public static IntVector2 operator *(IntVector2 a, IntVector2 b) => new IntVector2(a.X * b.X, a.Y * b.Y);
    public static IntVector2 operator /(IntVector2 a, IntVector2 b) => new IntVector2(a.X / b.X, a.Y / b.Y);
    public static IntVector2 operator *(IntVector2 a, int b) => new IntVector2(a.X * b, a.Y * b);
    public static IntVector2 operator /(IntVector2 a, int b) => new IntVector2(a.X / b, a.Y / b);
    public static bool operator ==(IntVector2 a, IntVector2 b) => a.X == b.X && a.Y == b.Y;
    public static bool operator !=(IntVector2 a, IntVector2 b) => !(a == b);
    public override string ToString() => $"({X}, {Y})";

    public bool Equals(IntVector2? other) => X == other?.X && Y == other?.Y;

    public override bool Equals(object? compared) => compared is IntVector2 other && this == other;
    public override int GetHashCode() => HashCode.Combine(X, Y);
}