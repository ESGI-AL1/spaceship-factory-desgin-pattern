namespace spaceshipFactory.Models;

public class Piece(string name, int quantity)
{
    public string Name { get; set; } = name;
    public int Quantity { get; set; } = quantity;
}
