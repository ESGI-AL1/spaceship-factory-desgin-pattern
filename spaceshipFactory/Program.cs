namespace spaceshipFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryManager inventory = InventoryManager.Instance;
            ShipAssembler assembler = new ShipAssembler(inventory);
            Stock stock = Stock.GetInstance();
            
            stock.InitStock();

			Console.WriteLine("Welcome to the spaceship factory!");
			Console.WriteLine("Available commands: ADD_PART <part_name> <quantity>, ADD_SHIP <ship_type> <quantity>, DISPLAY_PARTS, DISPLAY_SHIPS, EXIT");

            while (true)
            {
                Console.Write("> ");
                string? command = Console.ReadLine();
                if (command is not null)
                {
                    var result = command?
                        .Split(',')
                        .SelectMany(cmd => cmd.Trim().Split(' '))
                        .ToArray();
                    
                    foreach (var commands in result)
                    {
                        Console.WriteLine(commands);
                    }
                    
                    CommandParser.ParseAndExecute(result);
                }

                if (command?.ToUpper() == "EXIT")
                    break;
            }
        }
    }
}
