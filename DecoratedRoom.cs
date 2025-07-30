using System;

class DecoratedRoom : Room
{
    Func<Boolean> logic;
    public DecoratedRoom(string name, Func<Boolean> logic) : base(name)
    {
        this.logic = logic;
    }
    public override Room? getRoom(Direction direction)
    {
        return logic() ? base.getRoom(direction) : null;
    }
}