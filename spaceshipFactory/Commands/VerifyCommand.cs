using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class VerifyCommand(Dictionary<string, int> command) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();

    public void Execute()
    {
        var valid = true;

        foreach (var item in command.Where(item => !_stock.IsValidSpaceship(item.Key)))
        {
            Console.WriteLine($"ERROR: `{item.Key}` is not a recognized spaceship");
            valid = false;
        }

        if (valid)
        {
            Console.WriteLine(_stock.VerifyCommand(command) ? "AVAILABLE" : "UNAVAILABLE");
        }
    }
}
