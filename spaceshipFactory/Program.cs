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
        if (command.ToUpper() == "EXIT")
            break;

        var cmd = commandParser.ParseCommand(command);
        if (cmd != null)
        {
            invoker.SetCommand(cmd);
            invoker.ExecuteCommands();
        }
    }
}
