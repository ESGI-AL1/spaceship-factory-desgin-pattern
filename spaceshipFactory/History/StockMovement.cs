namespace spaceshipFactory.Storage;

public class StockMovement(string itemName, int quantity, string action)
{
    public string ItemName { get; } = itemName;
    public int Quantity { get; } = quantity;
    public string Action { get; } = action;
}
