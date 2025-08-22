using MazeGame.MazeGame.Application;
using MazeGame.MazeGame.Application.Commands;
using MazeGame.MazeGame.Application.Enums;
using MazeGame.MazeGame.Core.Enums;
using MazeGame.MazeGame.Core.Interactables;
using MazeGame.MazeGame.Core.Module;
using MazeGame.MazeGame.Core.Serialization;
using MazeGame.MazeGame.Presentation;

namespace MazeGame.MazeGame.Core.Managers;

public static class CommandManager
{
    public static Dictionary<string, Action<List<Entity>?>> commander { get; } = new();
    private static Player player = GameCreator.Instance.player;

    static CommandManager()
    {
        void add(dynamic command, Action<List<Entity>> action) => commander.Add(command.ToString(), action);

        add(Commands.open, operands => execute<Open>(operands));
        add(Commands.use, operands => execute<Used>(operands.LastOrDefault(), operands.FirstOrDefault()));
        add(Commands.examine, operands => execute<Examine>(operands));
        add(Commands.inventory, _ => Terminal.printInventory(GameCreator.Instance.player.getInventoryList()));
        add(Commands.up, _ => player.move(Directions.UP));
        add(Commands.right, _ => player.move(Directions.RIGHT));
        add(Commands.down, _ => player.move(Directions.DOWN));
        add(Commands.left, _ => player.move(Directions.LEFT));
        add(Commands.save, _ => GameSaver.save(GameCreator.Instance));
        add(Commands.load, _ =>
        {
            GameCreator.Instance.resetInstance(GameSaver.load<GameCreator>()!);
            Terminal.log(() => Console.WriteLine(player.pos));
        });

        //shortcuts
        add("inv", commander[nameof(Commands.inventory)]);
        add("u", commander[nameof(Commands.up)]);
        add("d", commander[nameof(Commands.down)]);
        add("r", commander[nameof(Commands.right)]);
        add("l", commander[nameof(Commands.left)]);
    }

    private static void execute<TExecutor>(params List<Entity> operands) where TExecutor : Executor
    {
        if (operands.Count == 0) return;
        if (operands.Count == 1)
        {
            operands.First().components.execute<TExecutor>();
        }
        else
        {
            operands.First().components.execute<TExecutor>(operands.Last());
        }
    }

    public static bool get(string str)
    {
        var parsedString = str.Split(' ');
        var operatorStr = parsedString.First();

        {
            var cleanedStr = parsedString.Skip(1).ToArray();
            if (cleanedStr.Length > 1) cleanedStr = [cleanedStr.First(), cleanedStr.Last()];

            return GameManager.run(operatorStr, getOperands(cleanedStr));
        }
    }

    //terminalWrapper for logging status
    private static string autoComplete(string str, params List<string>[] lists)
    {
        string result = autoComplete(str, out List<string> filter, lists);
        Terminal.autoCompleteLog(filter, str);
        return result;
    }

    private static string autoComplete(string str, out List<string> filter, params List<string>[] lists)
    {
        filter = new List<string>();
        if (str == "") return "";
        var list = lists.SelectMany(listTemp => listTemp).ToList();
        filter = list.FindAll(word => word.StartsWith(str));

        return filter.Count == 1 ? filter.First() : str;
    }

    private static List<Entity> getOperands(string[] names)
    {
        var result = new List<Entity>();
        foreach (var name in names)
        {
            var nameFound = autoComplete(name, player.getInventoryList().Select(entity => entity.name).ToList(),
                player.currentNode.room.getEntityList().Select(entity => entity.name).ToList());
            var inventoryOperand = player.getFromInventory(nameFound);
            var roomOperand = player.currentNode.room.getEntity(nameFound);
            if (inventoryOperand != null) result.Add(inventoryOperand);

            if (roomOperand != null) result.Add(roomOperand);
        }

        return result;
    }
}