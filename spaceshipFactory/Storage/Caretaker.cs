using spaceshipFactory.History;

namespace spaceshipFactory.Storage;

public class Caretaker
{
    private readonly List<StockMemento> _history = [];

    public void AddMemento(StockMemento memento)
    {
        _history.Add(memento);
    }

    public void PrintHistory()
    {
        for (int i = 0; i < _history.Count; i++)
        {
            var memento = _history[i];
            Console.WriteLine($"Snapshot {i + 1}:");
            Console.WriteLine("Pieces:");
            foreach (var piece in memento.Pieces)
            {
                Console.WriteLine($"{piece.Key}: {piece.Value}");
            }
            Console.WriteLine("Spaceships:");
            foreach (var spaceship in memento.Spaceships)
            {
                Console.WriteLine($"{spaceship.Key}: {spaceship.Value}");
            }
            Console.WriteLine();
        }
    }
}
