using System;

namespace spaceshipFactory
{
    public class CommandParser
    {
        public void ParseAndExecute(string command, InventoryManager inventory, ShipAssembler assembler)
        {
            var parts = command.Split(' ');

            switch (parts[0])
            {
                case "ADD_PART":
                    inventory.AddPart(parts[1], int.Parse(parts[2]));
                    break;
                case "ADD_SHIP":
                    assembler.AssembleShip(parts[1], int.Parse(parts[2]));
                    break;
                case "DISPLAY":
                    // Implement display logic
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}
