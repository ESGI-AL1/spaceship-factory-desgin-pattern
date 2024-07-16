using spaceshipFactory.Models;

namespace spaceshipFactory.Storage;

public sealed class Stock
{
    private Stock() {}
    private static Stock? _instance;
    private readonly Dictionary<string, Piece> _pieces = new();
    private readonly Dictionary<string, Spaceship> _spaceships = new();
    
    public static Stock GetInstance()
    {
        return _instance ??= new Stock();
    }

    public void InitStock()
    {
        //IncreaseItemQuantityInStock("Hull_HE1", 10);
        //IncreaseItemQuantityInStock("Hull_HS1", 10);
        IncreaseItemQuantityInStock("Hull_HC1", 10);
        
        //IncreaseItemQuantityInStock("Engine_EE1", 10);
        //IncreaseItemQuantityInStock("Engine_ES1", 10);
        IncreaseItemQuantityInStock("Engine_EC1", 10);
        
        //IncreaseItemQuantityInStock("Wings_WE1", 10);
        //IncreaseItemQuantityInStock("Wings_WS1", 10);
        IncreaseItemQuantityInStock("Wings_WC1", 10);
        
        //IncreaseItemQuantityInStock("Thruster_TE1", 10);
        //IncreaseItemQuantityInStock("Thruster_TS1", 10);
        IncreaseItemQuantityInStock("Thruster_TC1", 10);
        
        var explorerPieces = new Dictionary<string, int>
        {
            { "Hull_HE1", 1 },
            { "Engine_EE1", 1 },
            { "Wings_WE1", 2 },
            { "Thruster_TE1", 1 }
        };

        var speederPieces = new Dictionary<string, int>
        {
            { "Hull_HS1", 1 },
            { "Engine_ES1", 1 },
            { "Wings_WS1", 2 },
            { "Thruster_TS1", 1 }
        };

        var cargoPieces = new Dictionary<string, int>
        {
            { "Hull_HC1", 1 },
            { "Engine_EC1", 1 },
            { "Wings_WC1", 2 },
            { "Thruster_TC1", 1 }
        };

        IncreaseSpaceshipQuantityInStock("Explorer", explorerPieces, 0);
        IncreaseSpaceshipQuantityInStock("Speeder", speederPieces, 0);
        IncreaseSpaceshipQuantityInStock("Cargo", cargoPieces, 0);
    }
    
    public void ListCurrentStock()
    {
        foreach (var item in _pieces.Values)
        {
            Console.WriteLine($"{item.Quantity} {item.Name}");
        }

        foreach (var spaceship in _spaceships.Values)
        {
            if (spaceship.Quantity > 0)
            {
                Console.WriteLine($"{spaceship.Quantity} {spaceship.Name}");
            }
        }
    }

    private void IncreaseItemQuantityInStock(string itemName, int quantity)
    {
        if (_pieces.TryGetValue(itemName, out var piece))
        {
            piece.Quantity += quantity;
        }
        else
        {
            _pieces[itemName] = new Piece(itemName, quantity);
        }
    }

    private void IncreaseSpaceshipQuantityInStock(string name, Dictionary<string, int> requiredPieces, int quantity)
    {
        if (_spaceships.TryGetValue(name, out var spaceship))
        {
            spaceship.Quantity += quantity;
        }
        else
        {
            spaceship= new Spaceship(name, requiredPieces)
            {
                Quantity = quantity
            };
            _spaceships[name] = spaceship;
        }
    }

    public bool VerifyCommand(Dictionary<string, int> command)
    {
        var insufficientStockItems = new List<string>();

        foreach (var item in command)
        {
            if (!_spaceships.TryGetValue(item.Key, out var spaceship))
            {
                insufficientStockItems.Add($"{item.Key} unknown or insufficient stock");
                continue;
            }

            foreach (var piece in spaceship.RequiredPieces)
            {
                if (!_pieces.ContainsKey(piece.Key) || _pieces[piece.Key].Quantity < piece.Value * item.Value)
                {
                    insufficientStockItems.Add($"{piece.Key} insufficient stock");
                }
            }
        }

        if (insufficientStockItems.Count > 0)
        {
            Console.WriteLine("ERROR: Insufficient stock for the following items:");
            foreach (var item in insufficientStockItems)
            {
                Console.WriteLine(item);
            }
            return false;
        }

        Console.WriteLine("AVAILABLE");
        return true;
    }
    
    public void ProduceCommand(Dictionary<string, int> command)
    {
        foreach (var item in command)
        {
            if (!_spaceships.TryGetValue(item.Key, out var spaceship))
            {
                Console.WriteLine($"ERROR: {item.Key} unknown or insufficient stock");
                continue;
            }

            if (VerifyCommand(new Dictionary<string, int> { { item.Key, item.Value } }))
            {
                Console.WriteLine($"PRODUCING {item.Value} {item.Key}");
                foreach (var piece in spaceship.RequiredPieces)
                {
                    _pieces[piece.Key].Quantity -= piece.Value * item.Value;
                    Console.WriteLine($"GET_OUT_STOCK {piece.Value * item.Value} {piece.Key}");
                }
                Console.WriteLine($"FINISHED {item.Key}");

                if (!_spaceships.ContainsKey(item.Key))
                {
                    _spaceships[item.Key] = new Spaceship(item.Key, spaceship.RequiredPieces);
                }

                IncreaseSpaceshipQuantityInStock(item.Key, spaceship.RequiredPieces, item.Value);
                Console.WriteLine("STOCK_UPDATED");
            }
        }
    }

    public void ListRequiredPieces(Dictionary<string, int> command)
    {
        var totalRequiredPieces = new Dictionary<string, int>();
        foreach (var item in command)
        {
            if (!_spaceships.TryGetValue(item.Key, out var spaceship))
            {
                Console.WriteLine($"WARNING: {item.Key} not found in inventory or templates");
                continue;
            }

            Console.WriteLine($"{item.Value} {item.Key}:");
            foreach (var piece in spaceship.RequiredPieces)
            {
                int total = piece.Value * item.Value;
                Console.WriteLine($"{total} {piece.Key}");
                if (!totalRequiredPieces.TryAdd(piece.Key, total))
                {
                    totalRequiredPieces[piece.Key] += total;
                }
            }
        }
        Console.WriteLine("Total:");
        foreach (var piece in totalRequiredPieces)
        {
            Console.WriteLine($"{piece.Value} {piece.Key}");
        }
    }

    public void ListInstruction(Dictionary<string, int> command)
    {
        foreach (var item in command)
        {
            if (!_spaceships.TryGetValue(item.Key, out var spaceship))
            {
                Console.WriteLine($"WARNING: {item.Key} not found in inventory or templates");
                continue;
            }

            for (int i = 0; i < item.Value; i++)
            {
                Console.WriteLine($"PRODUCING {spaceship.Name}");
                foreach (var piece in spaceship.RequiredPieces)
                {
                    Console.WriteLine($"GET_OUT_STOCK {piece.Value} {piece.Key}");
                }
                Console.WriteLine($"FINISHED {spaceship.Name}");
            }
        }
    }
}
