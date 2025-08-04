using MazeGame.CommandInterfaces;

namespace MazeGame.Entitys;

public class Bed : Entity , Iexamine
{
    private string contains = "Needle";

    public Bed(string name,int x,int y) : base(name,x,y)
    {
    }

    public string examine()
    {
        String temp = contains;
        contains = "";
        return temp;
    }
    
    public override string icon()
    {
        return "-";
    }
}