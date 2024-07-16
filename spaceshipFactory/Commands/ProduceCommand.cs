using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class ProduceCommand(Dictionary<string, int> command) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();
    private Dictionary<string, int> Command { get; } = command;

    public void Execute()
    {
        _stock.ProduceCommand(Command);
    }
}