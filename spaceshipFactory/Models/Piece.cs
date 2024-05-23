namespace spaceshipFactory.Models;

public class Piece
{
    private string Name { get; }

    public Piece(string name)
    {
        Name = name;
    }
    
    public static void GetPiecesStocks(List<Piece> piecesCollection)
    {
        var piecesCount = new Dictionary<string, int>();
        
        foreach (var spaceship in piecesCollection)
        {
            if (piecesCount.ContainsKey(spaceship.Name))
            {
                piecesCount[spaceship.Name]++;
            }
            else
            {
                piecesCount.Add(spaceship.Name, 1);
            }
        }

        foreach (var kvp in piecesCount)
        {
            Console.WriteLine($"{kvp.Value} {kvp.Key}");
        }
    }
}