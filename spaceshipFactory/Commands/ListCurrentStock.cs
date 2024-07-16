using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class ListCurrentStockCommand : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();

    public void Execute()
    {
        _stock.ListCurrentStock();
    }
}