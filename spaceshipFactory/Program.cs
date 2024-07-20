using spaceshipFactory.Adapters;
using spaceshipFactory.Commands;
using spaceshipFactory.External;
using spaceshipFactory.Storage;

Stock stock = Stock.GetInstance();
stock.InitStock();

// Initialiser le système externe et l'adapter
ExternalStockSystem externalSystem = new ExternalStockSystem();
IStockAdapter externalAdapter = new ExternalStockAdapter(externalSystem);

// Définir l'adapter dans le stock
stock.SetAdapter(externalAdapter);

// Importer le stock externe dans le stock interne
stock.ImportExternalStock();


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
