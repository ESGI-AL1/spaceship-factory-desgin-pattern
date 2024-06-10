using System.Collections.Generic;

namespace spaceshipFactory
{
    public class InventoryManager
    {
        private static InventoryManager _instance;
        private Dictionary<string, int> _parts;
        private Dictionary<string, int> _ships;

        private InventoryManager()
        {
            _parts = new Dictionary<string, int>();
            _ships = new Dictionary<string, int>();
        }

        public static InventoryManager Instance => _instance ??= new InventoryManager();

        public void AddPart(string part, int quantity)
        {
            if (_parts.ContainsKey(part))
                _parts[part] += quantity;
            else
                _parts[part] = quantity;
        }

        public void AddShip(string ship, int quantity)
        {
            if (_ships.ContainsKey(ship))
                _ships[ship] += quantity;
            else
                _ships[ship] = quantity;
        }

        public bool HasPart(string part, int quantity)
        {
            return _parts.ContainsKey(part) && _parts[part] >= quantity;
        }

        public void UsePart(string part, int quantity)
        {
            if (HasPart(part, quantity))
                _parts[part] -= quantity;
        }

        public void DisplayParts()
        {
            Console.WriteLine("Parts Inventory:");
            foreach (var part in _parts)
            {
                Console.WriteLine($"{part.Key}: {part.Value}");
            }
        }

        public void DisplayShips()
        {
            Console.WriteLine("Ships Inventory:");
            foreach (var ship in _ships)
            {
                Console.WriteLine($"{ship.Key}: {ship.Value}");
            }
        }
    }
}
