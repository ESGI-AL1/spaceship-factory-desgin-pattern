using JetBrains.Annotations;
using spaceshipFactory.Commands;
using spaceshipFactory.FileSupport;
using spaceshipFactory.Storage;

namespace TestProject1.FileSupport;

[TestSubject(typeof(FlatFileAdapter))]
public class FlatFileAdapterTest
{

    [Fact]
    public void METHOD()
    {
        
    }

    /// <summary>
    /// Verifies LoadCommands method of the FlatFileAdapter correctly reads all lines from a text file
    /// and returns them as a list of strings.
    /// </summary>

    [Fact]
    public void LoadCommands_ShouldLoadAllLinesFromFile()
    {
        // Arrange
        var adapter = new FlatFileAdapter();
        var filePath = "test_flatfile.txt";
        File.WriteAllLines(filePath, new[] { "STOCKS", "VERIFY 1 Explorer" });

        // Act
        var commands = adapter.LoadCommands(filePath);

        // Assert
        Assert.NotNull(commands);
        Assert.Equal(2, commands.Count);
        Assert.Equal("STOCKS", commands[0]);
        Assert.Equal("VERIFY 1 Explorer", commands[1]);

        // Cleanup
        File.Delete(filePath);
    }

    /// <summary>
    /// Verifies that the LOAD command with FLAT format loads commands correctly from a text file
    /// and executes them, check the stock also after
    ///</summary>
    [Fact]
    public void LoadCommands_ShouldLoadFlatFile()
    {
        // Arrange
        var stock = Stock.GetInstance();
        stock.InitStock();

        var commandParser = new CommandParser();
        var invoker = new Invoker();
        var adapter = new FlatFileAdapter();

        var filePath = "test_flatfile.txt";
        var commands = new List<string> { "STOCKS", "VERIFY 1 Explorer" };
        File.WriteAllLines(filePath, commands);

        // Capture the console output
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Act
            var loadedCommands = adapter.LoadCommands(filePath);
            if (loadedCommands != null)
            {
                foreach (var parsedCmd in loadedCommands.Select(cmd => commandParser.ParseCommand(cmd, invoker)).OfType<ICommand>())
                {
                    invoker.SetCommand(parsedCmd);
                }
                invoker.ExecuteCommands();
            }

            // Assert
            var result = sw.ToString().Trim();
            Assert.Contains("AVAILABLE", result);  

            // Cleanup
            File.Delete(filePath);
        }
    }


    
}