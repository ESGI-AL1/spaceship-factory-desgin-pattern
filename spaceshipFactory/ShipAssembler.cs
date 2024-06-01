using spaceshipFactory.Utils;

namespace spaceshipFactory
{
    public class ShipAssembler
    {
        private InventoryManager _inventory;

        public ShipAssembler(InventoryManager inventory)
        {
            _inventory = inventory;
        }

        public void AssembleShip(string shipType, int quantity)
        {
            var neededParts = NeededStocksUtils.GetNeededStocks(shipType);

            foreach (var part in neededParts)
            {
                if (!_inventory.HasPart(part.Key, part.Value * quantity))
                {
                    Console.WriteLine($"Not enough {part.Key} parts to assemble the ship.");
                    return;
                }
            }

            foreach (var part in neededParts)
            {
                _inventory.UsePart(part.Key, part.Value * quantity);
            }

            _inventory.AddShip(shipType, quantity);
            Console.WriteLine($"Assembled {quantity} {shipType}(s).");
        }
    }
}
