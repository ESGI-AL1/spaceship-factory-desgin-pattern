using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class ListInstructionCommand(Dictionary<string, int> command) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();

    public void Execute()
    {
        _stock.ListInstruction(command);
    }
}