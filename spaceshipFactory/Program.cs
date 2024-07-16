using spaceshipFactory.Commands;
using spaceshipFactory.Storage;


Stock stock = Stock.GetInstance();
stock.InitStock();

CommandParser commandParser = new CommandParser();
Invoker invoker = new Invoker();

while (true)
{
    Console.Write("> ");
    string? command = Console.ReadLine();
    if (command is not null)
    {
        var cmd = commandParser.ParseCommand(command);
        invoker.SetCommand(cmd);
        invoker.ExecuteCommands();
    }

    if (command?.ToUpper() == "EXIT")
        break;
}
