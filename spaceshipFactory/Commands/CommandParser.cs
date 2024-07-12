using spaceshipFactory.Models;
using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands
{
    public class CommandParser(Stock stock)
    {
        public void ExecuteCommand(string? commandLine)
        {
            var parts = commandLine?.Split(' ', 2);
            var command = parts?[0].ToUpper();
            var args = parts is { Length: > 1 } ? parts[1] : string.Empty;

            switch (command)
            {
                case "STOCKS":
                    stock.GetCurrentStock();
                    break;
                case "VERIFY":
                    var cmdVerify = ParseCommand(args);
                    break;
                case "PRODUCE":
                    var cmdProduce = ParseCommand(args);
                    break;
                case "NEEDED_STOCKS":
                    var cmdNeededStocks = ParseCommand(args);
                    Spaceship spaceship = new Spaceship();
                    spaceship.ExecuteNeededStocks(cmdNeededStocks);
                    break;
                case "INSTRUCTIONS":
                    var cmdInstructions = ParseCommand(args);
                    break;
                default:
                    Console.WriteLine("ERROR: Unknown command");
                    break;
            }
        }

        private Dictionary<string, int> ParseCommand(string args)
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
}
