using spaceshipFactory.External;
using System.Linq;

namespace spaceshipFactory.Adapters
{
	public class ExternalStockAdapter : IStockAdapter
	{
		private readonly ExternalStockSystem _externalStockSystem;

		public ExternalStockAdapter(ExternalStockSystem externalStockSystem)
		{
			_externalStockSystem = externalStockSystem;
		}

		public Dictionary<string, int> GetStock()
		{
			var externalStock = _externalStockSystem.GetExternalStock();
			return externalStock.ToDictionary(item => item.Item, item => item.Quantity);
		}
	}
}
