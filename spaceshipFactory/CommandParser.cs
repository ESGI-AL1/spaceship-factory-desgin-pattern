using spaceshipFactory.Models;

namespace spaceshipFactory
{
    public static class CommandParser
    {
        public static void ParseAndExecute(string[] command)
        {
            Console.WriteLine("Parse and Execute");
            switch (command[0])
            {
                case "STOCKS":
                    Stock.GetInstance().GetCurrentStock();
                    break;
                case "NEEDED_STOCKS":
                    Console.WriteLine("Needed stocks");

                    List<int> numberOfItems = new();
                    List<string> nameOfSpaceships = new();

                    for (int i = 1; i < command.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            nameOfSpaceships.Add(command[i]);
                        }
                        else
                        {
                            try
                            {
                                numberOfItems.Add(int.Parse(command[i]));
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            
                        }
                    }

                    Spaceship sp = new();

                    foreach (var item in numberOfItems)
                    {
                        foreach (var name in nameOfSpaceships.Distinct())
                        {
                            sp.ListRequiredItems(name, item);
                        }    
                    }
                    

                    break;
                case "ADD_SHIP":
                    break;
                case "DISPLAY_PARTS":
                    break;
				case "DISPLAY_SHIPS":
					break;
				default:
                    Console.WriteLine("Unknown command.");
                    break;
            }
        }
    }
}
