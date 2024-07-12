namespace spaceshipFactory.Models;
public class Spaceship
{
    public string? Name { get; set; }

    private void ListRequiredItems(string name, int numberOfSpaceships)
    {
        switch (name)
        {
            case "Explorer":
                Console.WriteLine($"{1 * numberOfSpaceships} Explorer:");
                Console.WriteLine($"{1 * numberOfSpaceships} Hull_HE1");
                Console.WriteLine($"{1 * numberOfSpaceships} Engine_EE1");
                Console.WriteLine($"{2 * numberOfSpaceships} Wings_WE1");
                Console.WriteLine($"{1 * numberOfSpaceships} Thruster_TE1");
                break;
            case "Speeder":
                Console.WriteLine($"{1 * numberOfSpaceships} Speeder:");
                Console.WriteLine($"{1 * numberOfSpaceships} Hull_HS1");
                Console.WriteLine($"{1 * numberOfSpaceships} Engine_ES1");
                Console.WriteLine($"{2 * numberOfSpaceships} Wings_WS1");
                Console.WriteLine($"{1 * numberOfSpaceships} Thruster_TS1");
                break;
            case "Cargo":
                Console.WriteLine($"{1 * numberOfSpaceships} Cargo:");
                Console.WriteLine($"{1 * numberOfSpaceships} Hull_HC1");
                Console.WriteLine($"{1 * numberOfSpaceships} Engine_EC1");
                Console.WriteLine($"{2 * numberOfSpaceships} Wings_WC1");
                Console.WriteLine($"{1 * numberOfSpaceships} Thruster_TC1");
                break;
            default:
                Console.WriteLine("Invalid spaceship name.");
                break;
        }
    }

    public void ExecuteNeededStocks(Dictionary<string, int> neededStocks)
    {
        Spaceship sp = new();

        foreach (var kvp in neededStocks)
        {
            sp.ListRequiredItems(kvp.Key, kvp.Value);
        }
    }

}

