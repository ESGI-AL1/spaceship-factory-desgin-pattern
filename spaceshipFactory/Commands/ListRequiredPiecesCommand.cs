using spaceshipFactory.Storage;

namespace spaceshipFactory.Commands
{
	public class ListRequiredPiecesCommand : ICommand
	{
		private readonly Dictionary<string, int> _requiredSpaceships;
		private readonly Stock _stock = Stock.GetInstance();

		public ListRequiredPiecesCommand(Dictionary<string, int> requiredSpaceships)
		{
			_requiredSpaceships = requiredSpaceships;
		}

		public void Execute()
		{
			_stock.ListRequiredPieces(_requiredSpaceships);
		}
	}
}
