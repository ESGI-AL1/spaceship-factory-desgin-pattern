namespace spaceshipFactory.Commands;

public class CommandParser
{
    public ICommand? ParseCommand(string? commandLine)
    {
        var parts = commandLine?.Split(' ', 2);
        var command = parts?[0].ToUpper();
        var args = parts is { Length: > 1 } ? parts[1] : string.Empty;

        switch (command)
        {
            case "STOCKS":
                return new ListCurrentStockCommand();
            case "VERIFY":
                var cmdVerify = ParseArgs(args);
                return new VerifyCommand(cmdVerify);
            case "PRODUCE":
                var cmdProduce = ParseArgs(args);
                return new ProduceCommand(cmdProduce);
            case "NEEDED_STOCKS":
                var neededStockCmd = ParseArgs(args);
                return new ListRequiredPiecesCommand(neededStockCmd);
            case "INSTRUCTIONS":
                var cmdInstructions = ParseArgs(args);
                return new ListInstructionCommand(cmdInstructions);
            default:
                Console.WriteLine("ERROR: Unknown command");
                return null;
        }
    }

    private Dictionary<string, int> ParseArgs(string args)
    {
        var commands = new Dictionary<string, int>();
        var items = args.Split(',');

        foreach (var item in items)
        {
            var parts = item.Trim().Split(' ');
            var quantity = int.Parse(parts[0]);
            var spaceship = parts[1];

            if (!commands.TryAdd(spaceship, quantity))
            {
                commands[spaceship] += quantity;
            }
        }

        return commands;
    }
}
