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
