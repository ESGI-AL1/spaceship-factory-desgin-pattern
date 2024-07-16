using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class VerifyCommand(Dictionary<string, int> command) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();
    private Dictionary<string, int> Command { get; } = command;

    public void Execute()
    {
        Console.WriteLine(_stock.VerifyCommand(Command) ? "AVAILABLE" : "UNAVAILABLE");
    }
}