namespace MazeGame.MazeGame.Core.Misc;

public enum Direction
{
    up,
    right,
    down,
    left
}

public enum GameStatus
{
    ongoing = 0,
    win = 1,
    lose = 2
}

public enum CommandsName
{
    up,
    right,
    down,
    left,
    inventory,
    examine,
    open,
    use,
    save,
    load,
}