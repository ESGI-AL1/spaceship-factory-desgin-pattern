namespace spaceshipFactory.Models;

public class Spaceship
{
    private string Name { get; }
    public Spaceship(string name)
    { 
        Name = name;
    }
    public static void GetSpaceshipStocks(List<Spaceship> spaceshipsCollection)
    {
        var spaceshipCount = new Dictionary<string, int>();
        
        foreach (var spaceship in spaceshipsCollection)
        {
            if (spaceshipCount.ContainsKey(spaceship.Name))
            {
                spaceshipCount[spaceship.Name]++;
            }
            else
            {
                spaceshipCount.Add(spaceship.Name, 1);
            }
        }

        foreach (var kvp in spaceshipCount)
        {
            Console.WriteLine($"{kvp.Value} {kvp.Key}");
        }
    }
}
