namespace spaceshipFactory.Models;

public class Piece(string name, int quantity)
{
    public string Name { get; } = name;
    public int Quantity { get; set; } = quantity;
}
