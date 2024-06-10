using System;
using spaceshipFactory.Models;
using spaceshipFactory.Utils;

namespace spaceshipFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandParser parser = new CommandParser();
            InventoryManager inventory = InventoryManager.Instance;
            ShipAssembler assembler = new ShipAssembler(inventory);

			Console.WriteLine("Welcome to the spaceship factory!");
			Console.WriteLine("Available commands: ADD_PART <part_name> <quantity>, ADD_SHIP <ship_type> <quantity>, DISPLAY_PARTS, DISPLAY_SHIPS, EXIT");

            while (true)
            {
                Console.Write("> ");
                string command = Console.ReadLine();
                if (command.ToUpper() == "EXIT")
                    break;
                parser.ParseAndExecute(command, inventory,assembler);
            }

			while (true)
            {
                try
                {
                    string? command = Console.ReadLine();
                    parser.ParseAndExecute(command, inventory, assembler);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
