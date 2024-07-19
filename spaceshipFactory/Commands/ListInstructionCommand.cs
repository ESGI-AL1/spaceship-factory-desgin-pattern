using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class ListInstructionCommand(Dictionary<string, int> command) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();

    public void Execute()
    {
        foreach (var item in command)
        {
            _stock.ListInstruction(new Dictionary<string, int> { { item.Key, item.Value } });
        }
    }
}
