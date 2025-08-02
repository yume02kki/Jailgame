namespace MazeGame.Entitys;

public class Bed : Entity
{
    private string containsItem = "Needle";
    private Boolean hasBeenExamined = false;
    
    public Bed() : base("Bed")
    {
    }
    
    public String examine()
    {
        if (!hasBeenExamined)
        {
            hasBeenExamined = true;
            return containsItem;
        }
        return null;
    }
}