using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class VerifyCommand(Dictionary<string, int> items) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();
    private Dictionary<string, int> Command { get; } = items;

    public void Execute()
    {
        _stock.VerifyCommand(Command);
    }
}