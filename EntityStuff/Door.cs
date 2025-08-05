using MazeGame.CommandInterfaces;
using Terminal.Gui;

namespace MazeGame.Entitys;

public class Door : Entity, Iopen, Iuse
{
    private bool _opened;
    private bool _locked; 
    private Direction _direction;
    public Door(string name,int x,int y,Direction direction,bool locked,bool opened = false) : base(name,x,y)
    {
        _locked = locked;
        _opened = opened;
        _direction = direction;
    }

    private bool locked
    {
        get { return _locked; }
        set { _locked = value; }
    }

    public bool opened
    {
        get { return _opened; }
        set { _opened = value; }
    }
    public void open(){
        if(!locked)
            opened = true;
    }

    public Direction Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public override string icon()
    {
        return opened ? "☐":"▥";
    }

    public override bool collide()
    {
        return !opened;
    }

    public void use()
    {
        locked = false;
    }

    public bool canItemBeUsed(string item)
    {
        return item=="Needle";
    }
 }    
