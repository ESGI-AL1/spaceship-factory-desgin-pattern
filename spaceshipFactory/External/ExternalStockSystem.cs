namespace spaceshipFactory.External
{
	public class ExternalStockSystem
	{
		public List<(string Item, int Quantity)> GetExternalStock()
		{
			// Simule le retour d'un stock externe
			return new List<(string Item, int Quantity)>
			{
				("Hull_HC1", 5),
				("Engine_EC1", 5),
				("Wings_WC1", 5),
				("Thruster_TC1", 5)
			};
		}
	}
}
