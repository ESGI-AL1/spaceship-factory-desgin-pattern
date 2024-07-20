using spaceshipFactory.Commands;
using spaceshipFactory.FileSupport;
using spaceshipFactory.Storage;

var stock = Stock.GetInstance();
stock.InitStock();

var commandParser = new CommandParser();
var invoker = new Invoker();

Console.WriteLine("Listing files in home/sample-files directory:");
var homeDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
var sampleFilesDir = Path.Combine(homeDir, "sample-files");

if (Directory.Exists(sampleFilesDir))
{
    var files = Directory.GetFiles(sampleFilesDir);
    foreach (var file in files)
    {
        Console.WriteLine(file);
    }
}
else
{
    Console.WriteLine("ERROR: sample-files directory not found.");
}

while (true)
{
    Console.Write("> ");
    var command = Console.ReadLine();
    if (command is null) continue;
    if (command.ToUpper() == "EXIT")
        break;

    if (command.StartsWith("LOAD"))
    {
        var parts = command.Split(' ', 3);
        if (parts.Length == 3)
        {
            var format = parts[1].ToUpper();
            var fileName = parts[2];
            var filePath = Path.Combine(sampleFilesDir, fileName);

            IFileAdapter? fileAdapter;
            switch (format)
            {
                case "FLAT":
                    fileAdapter = new FlatFileAdapter();
                    break;
                case "JSON":
                    fileAdapter = new JsonFileAdapter();
                    break;
                case "XML":
                    fileAdapter = new XmlFileAdapter();
                    break;
                default:
                    Console.WriteLine("ERROR: Unknown file format");
                    continue;
            }

            try
            {
                var commands = fileAdapter.LoadCommands(filePath);
                if (commands != null)
                    foreach (var parsedCmd in commands.Select(cmd => commandParser.ParseCommand(cmd, invoker)).OfType<ICommand>())
                    {
                        invoker.SetCommand(parsedCmd);
                    }

                invoker.ExecuteCommands();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("ERROR: Invalid LOAD command format.");
        }
    }
    else
    {
        var cmd = commandParser.ParseCommand(command, invoker);
        if (cmd != null)
        {
            invoker.SetCommand(cmd);
            invoker.ExecuteCommands();
        }
    }
}