using MazeGame.CommandInterfaces;

namespace MazeGame.Commands;

public class BedCommands : Commands,Iexamine
{
    private Player _player;
    private string _item;

    public BedCommands(Player player, string item)
    {
        _player = player;
        _item = item;
    
}
    public Player Player
    {
        get => _player;
        set => _player = value;
    }

    public string Item
    {
        get => _item;
        set => _item = value;
    }

    public void examine() => Player.setInventory(Item);
    
    public bool collide() => false;
    
    
}