namespace spaceshipFactory.Commands;

public class CommandParser
{
    public ICommand? ParseCommand(string? commandLine, Invoker invoker)
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
                return cmdVerify != null ? new VerifyCommand(cmdVerify) : null;
            case "PRODUCE":
                var cmdProduce = ParseArgs(args);
                return cmdProduce != null ? new ProduceCommand(cmdProduce) : null;
            case "NEEDED_STOCKS":
                var neededStockCmd = ParseArgs(args);
                return neededStockCmd != null ? new ListRequiredPiecesCommand(neededStockCmd) : null;
            case "INSTRUCTIONS":
                var cmdInstructions = ParseArgs(args);
                return cmdInstructions != null ? new ListInstructionCommand(cmdInstructions) : null;
            case "GET_MOVEMENTS":
                var movementsArgs = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                return new GetMovementsCommand(movementsArgs);
            default:
                Console.WriteLine("ERROR: Unknown command");
                return null;
        }
    }

    private Dictionary<string, int>? ParseArgs(string args)
    {
        var commands = new Dictionary<string, int>();
        var items = args.Split(',');

        foreach (var item in items)
        {
            var parts = item.Trim().Split(' ');
            if (parts.Length != 2 || !int.TryParse(parts[0], out var quantity))
            {
                Console.WriteLine($"ERROR: Invalid format for '{item.Trim()}'");
                return null;
            }
            var spaceship = parts[1];

            if (!commands.TryAdd(spaceship, quantity))
            {
                commands[spaceship] += quantity;
            }
        }

        return commands;
    }
}

