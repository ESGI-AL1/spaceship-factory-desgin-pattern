namespace spaceshipFactory.History;

public class StockMemento(Dictionary<string, int> pieces, Dictionary<string, int> spaceships)
{
    public Dictionary<string, int> Pieces { get; } = new(pieces);
    public Dictionary<string, int> Spaceships { get; } = new(spaceships);
}