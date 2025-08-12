using System.Text.RegularExpressions;

namespace MazeGame;

public static class Color
{
    public static void write(Render render, bool newLine = false)
    {
        write(render.icon() + (newLine ? "\n" : ""), render.color());
    }

    public static void write(string message, ConsoleColor? colorOptional, bool newLine = false, bool selective = false)
    {
        if (newLine)
        {
            message += "\n";
        }

        if (colorOptional == null)
        {
            Console.Write(message);
            return;
        }

        ConsoleColor color = colorOptional.Value;
        if (selective)
        {
            var pieces = Regex.Split(message, @"(\[[^\]]*\])");
            for (int i = 0; i < pieces.Length; i++)
            {
                string piece = pieces[i];
                if (piece.StartsWith("[") && piece.EndsWith("]"))
                {
                    Console.ForegroundColor = color;
                    piece = piece.Substring(1, piece.Length - 2);
                }

                Console.Write(piece);
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}