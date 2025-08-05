namespace MazeGame.CommandInterfaces;

public interface Iuse
{
    void use();

    bool canItemBeUsed(string item);
}