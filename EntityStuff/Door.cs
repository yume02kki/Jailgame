using MazeGame.CommandInterfaces;
using Terminal.Gui;

namespace MazeGame.Entitys;

public class Door : Entity, Iopen
{
    private bool opened = false;
    private bool locked = false; //todo: should be state of key used in future;
    public Door(string name,int x,int y) : base(name,x,y)
    {
    }
    
    public void open(){
        if(!locked)
            opened = true;
    }

    public override string icon()
    {
        return opened ? "☐":"▥";
    }
 }    
