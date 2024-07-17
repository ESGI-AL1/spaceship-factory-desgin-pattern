using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands;

public class ListRequiredPiecesCommand(Dictionary<string, int> command) : ICommand
{
    private readonly Stock _stock = Stock.GetInstance();

    public void Execute()
    {
        _stock.ListRequiredPieces(command);
    }
}