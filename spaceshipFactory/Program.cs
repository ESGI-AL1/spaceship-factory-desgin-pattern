using spaceshipFactory;
using spaceshipFactory.Commands;
using spaceshipFactory.Storage;

Stock stock = Stock.GetInstance();
CommandParser commandParser = new CommandParser(stock);
            
stock.InitStock();

while (true)
{
    Console.Write("> ");
    string? command = Console.ReadLine();
    if (command is not null)
    {
        commandParser.ExecuteCommand(command);
    }

    if (command?.ToUpper() == "EXIT")
        break;
}