namespace spaceshipFactory.Storage;

// Singleton
public sealed class Stock
{
    private Stock() {}
    private static Stock? _instance;

    public static Stock GetInstance()
    {
        return _instance ??= new Stock();
    }
    
    private readonly Dictionary<string, int> _stock = new();
    public void InitStock()
    {
        _stock.Add("Spaceship 1", 2 );
        _stock.Add("Spaceship 2", 8);
        _stock.Add("Spaceship 3", 1);
    }
    
    public void GetCurrentStock()
    {
        foreach (var item in _stock)
        {
            Console.WriteLine($"{item.Value} {item.Key}");
        }    
    }
    
    public void IncreaseItemQuantityInStock(string itemName, int quantity)
    {
        _stock[itemName] += quantity;
    }
    
    public void DecreaseItemQuantityInStock(string itemName)
    {
        if (_stock.ContainsKey(itemName))
        {
            if (_stock[itemName] > 1)
            {
                _stock[itemName] -= 1;
            }
            else
            {
                _stock.Remove(itemName);
            }
        }
        else
        {
            Console.WriteLine($"Item '{itemName}' not found in stock.");
        }
    }
}