namespace spaceshipFactory.Utils;

public static class NeededStocksUtils
{
    private const string Explorer = "Explorer";
    private const string Speeder = "Speeder";
    private const string Cargo = "Cargo";
    public static void ListRequiredItemsForSpaceship(string spaceshipName, int quantity = 1)
    {
        switch (spaceshipName)
        {
            case Explorer:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{quantity * 1} Hull_HE1");
                Console.WriteLine($"{quantity * 1} Engine_EE1");
                Console.WriteLine($"{quantity * 1} Wings_WE1");
                Console.WriteLine($"{quantity * 1} Thruster_TE1");
                break;
            case Speeder:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{quantity * 1} Hull_HS1");
                Console.WriteLine($"{quantity * 1} Engine_ES1");
                Console.WriteLine($"{quantity * 1} Wings_WS1");
                Console.WriteLine($"{quantity * 2} Thruster_TS1");
                break;
            case Cargo:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{quantity * 1} Hull_HC1");
                Console.WriteLine($"{quantity * 1} Engine_EC1");
                Console.WriteLine($"{quantity * 1} Wings_WC1");
                Console.WriteLine($"{quantity * 2} Thruster_TC1");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[ERROR] Invalid spaceship name.");
                break;
        }
    }
}