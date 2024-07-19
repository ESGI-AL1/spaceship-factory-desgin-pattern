using spaceshipFactory.Commands;
using spaceshipFactory.Storage;

var stock = Stock.GetInstance();
stock.InitStock();

var commandParser = new CommandParser();
var invoker = new Invoker();

while (true)
{
    Console.Write("> ");
    string? command = Console.ReadLine();
    if (command is not null)
    {
        if (command.ToUpper() == "EXIT")
            break;

        var cmd = commandParser.ParseCommand(command, invoker);
        if (cmd != null)
        {
            invoker.SetCommand(cmd);
            invoker.ExecuteCommands();
        }
    }
}
