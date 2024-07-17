using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class VerifyCommand(Dictionary<string, int> command) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();

    public void Execute()
    {
        Console.WriteLine(_stock.VerifyCommand(command) ? "AVAILABLE" : "UNAVAILABLE");
    }
}