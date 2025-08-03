using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Bed : Entity , Iexamine
{
    private string contains = "Needle";

    public Bed(string name) : base(name)
    {
    }

    public string examine()
    {
        String temp = contains;
        contains = "";
        return temp;
    }
}