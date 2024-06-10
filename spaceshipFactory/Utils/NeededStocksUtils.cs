using System.Collections.Generic;

namespace spaceshipFactory.Utils
{
    public static class NeededStocksUtils
    {
        public static Dictionary<string, int> GetNeededStocks(string shipType)
        {
            var neededStocks = new Dictionary<string, int>();

            switch (shipType)
            {
                case "Fighter":
                    neededStocks["Engine"] = 1;
                    neededStocks["Hull"] = 1;
                    neededStocks["Wing"] = 2;
                    break;
                case "Bomber":
                    neededStocks["Engine"] = 2;
                    neededStocks["Hull"] = 1;
                    neededStocks["Wing"] = 2;
                    neededStocks["BombBay"] = 1;
                    break;
                // Add other ship types...
                default:
                    break;
            }

            return neededStocks;
        }
    }
}
