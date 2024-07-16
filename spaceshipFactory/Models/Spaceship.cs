namespace spaceshipFactory.Models;
public class Spaceship(string name, Dictionary<string, int> requiredPieces)
{
    public string Name { get; } = name;
    public Dictionary<string, int> RequiredPieces { get; set; } = requiredPieces;
    public int Quantity { get; set; }
    
}

