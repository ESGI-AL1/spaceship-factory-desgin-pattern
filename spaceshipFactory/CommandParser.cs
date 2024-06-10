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
                    Console.WriteLine($"Added {parts[2]} of {parts[1]} to inventory.");
                    break;
                case "ADD_SHIP":
                    assembler.AssembleShip(parts[1], int.Parse(parts[2]));
                    break;
                case "DISPLAY_PARTS":
                    // Implement display logic
                    inventory.DisplayParts();
                    break;
				case "DISPLAY_SHIPS":
					// Implement display logic
					inventory.DisplayShips();
					break;
				default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}
