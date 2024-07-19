using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class GetMovementsCommand(string[] args) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();

    public void Execute()
    {
        if (args.Length == 0)
        {
            _stock.GetMovements();
        }
        else
        {
            _stock.GetMovements(args);
        }
    }
}
