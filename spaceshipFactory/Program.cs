using spaceshipFactory.Models;
using spaceshipFactory.Utils;

List<Spaceship> spaceships = new List<Spaceship>();
List<Piece> pieces = new List<Piece>();

spaceships.Add(new Spaceship("Vaisseau 1"));
spaceships.Add(new Spaceship("Vaisseau 1"));
spaceships.Add(new Spaceship("Vaisseau 1"));
spaceships.Add(new Spaceship("Vaisseau 2"));
spaceships.Add(new Spaceship("Vaisseau 3"));
spaceships.Add(new Spaceship("Vaisseau 3"));
pieces.Add(new Piece("Piece 1"));
pieces.Add(new Piece("Piece 1"));
pieces.Add(new Piece("Piece 2"));
pieces.Add(new Piece("Piece 3"));

while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("Enter command: ");
    Console.ForegroundColor = ConsoleColor.Green;
    string? command = Console.ReadLine();
    
    command?.Trim(',');
    string[] parStrings = command.Split(' ');
    foreach (var VARIABLE in parStrings)
    {
        Console.WriteLine(VARIABLE);
    }

    for (int i = 1; i < parStrings.Length; i++)
    {
        Console.WriteLine(parStrings[i]);
    }
    Console.WriteLine(parStrings);
    switch (command?.ToUpper())
    {
        case "STOCKS":
            Console.ForegroundColor = ConsoleColor.White;
            Spaceship.GetSpaceshipStocks(spaceships);
            Piece.GetPiecesStocks(pieces);
            break;
        case "NEEDED_STOCKS":
            Console.ForegroundColor = ConsoleColor.White;
            string? spaceshipeName = Console.ReadLine();
            NeededStocksUtils.ListRequiredItemsForSpaceship(spaceshipeName);
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] Invalid. Please enter a valid command.\n" +
                              "[ERROR] To list all the commands, type HELP.\n" +
                              "[ERROR] Press CTRL+C to exit the program.");
            break;
    }
}
