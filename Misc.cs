using System.Text.RegularExpressions;

namespace MazeGame;

public static class Misc
{
    public static int clamp(int num,int border)
    {
        return (num >= border) ? 0 : (num <= 0 ? border: num);
    }

    public static string commaList(List<string> list)
    {
        return string.Join(", ", list);
    }
    public static (int, int) addTuples((int a, int b) pa, (int a, int b) pb)
    {
        return (pa.a+pb.a,pa.b+pb.b);
    }
    public static (int, int) dirToPos(Direction dir)
    {
        int x = 0;
        int y = 0;
        switch (dir)
        {
            case Direction.up:
                y++;
                break;
            case Direction.down:
                y--;
                break;
            case Direction.left:
                x--;
                break;
            case Direction.right:
                x++;
                break;
        }
        return (x,y);
    }
    public static Direction mirror(Direction direction)
    {
        switch (direction)
        {
            case Direction.up:
                return Direction.down;
            case Direction.down:
                return Direction.up;
            case Direction.left:
                return Direction.right;
            case Direction.right:
                return Direction.left;
            default:
                return direction;
        }
    }

    public static void write(Render render,bool newLine=false)
    {
        write(render.icon() + (newLine?"\n":""),render.color());
    }
    public static void write(string message, ConsoleColor? colorOptional,bool newLine = false,bool selective = false)
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