using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class ProduceCommand(Dictionary<string, int> command) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();

    public void Execute()
    {
        _stock.ProduceCommand(command);
    }
}
