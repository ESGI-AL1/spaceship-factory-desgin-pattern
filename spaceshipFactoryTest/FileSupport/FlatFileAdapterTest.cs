using JetBrains.Annotations;
using spaceshipFactory.FileSupport;

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


    
}