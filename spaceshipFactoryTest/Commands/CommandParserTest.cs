using JetBrains.Annotations;
using spaceshipFactory.Commands;

namespace TestProject1.Commands;

[TestSubject(typeof(CommandParser))]
public class CommandParserTest
{
    
    private readonly CommandParser _commandParser = new CommandParser();


    [Fact]
    public void METHOD()
    {
        
    }
    
    
    /// <summary>
    /// Verifies the ParseCommand method returns an instance of ListCurrentStockCommand
    /// when I give the STOCKS command.
    /// </summary>
    [Fact]
    public void ParseCommand_ShouldReturnListCurrentStockCommand_WhenCommandIsSTOCKS()
    {
        // Arrange
        string commandLine = "STOCKS";
        var invoker = new Invoker();

        // Act
        var result = _commandParser.ParseCommand(commandLine, invoker);

        // Assert
        Assert.IsType<ListCurrentStockCommand>(result);
    }
    

    /// <summary>
    /// Verifies that the ParseCommand method returns an instance of VerifyCommand
    /// when I give the VERIFY command with valid arguments.
    /// </summary>
    [Fact]
    public void ParseCommand_ShouldReturnVerifyCommand_WhenCommandIsVERIFY_WithValidArgs()
    {
        // Arrange
        string commandLine = "VERIFY 10 spaceship1, 20 spaceship2";
        var invoker = new Invoker();

        // Act
        var result = _commandParser.ParseCommand(commandLine, invoker);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<VerifyCommand>(result);
    }
    
    
    /// <summary>
    /// Verifies that the ParseCommand method returns an instance of ProduceCommand
    /// when I give the PRODUCE command with valid arguments.
    /// </summary>
    [Fact]
    public void ParseCommand_ShouldReturnProduceCommand_WhenCommandIsPRODUCE_WithValidArgs()
    {
        // Arrange
        string commandLine = "PRODUCE 10 spaceship1, 20 spaceship2";
        var invoker = new Invoker();

        // Act
        var result = _commandParser.ParseCommand(commandLine, invoker);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ProduceCommand>(result);
    }
    
    /// <summary>
    /// Verifies  the ParseCommand method returns null and prints an error message
    /// when I give an unknown command.
    /// </summary>
    [Fact]
    public void ParseCommand_ShouldReturnNull_WhenCommandIsUnknown()
    {
        // Arrange
        string commandLine = "UNKNOWNCOMMAND";
        var invoker = new Invoker();

        // Act
        var result = _commandParser.ParseCommand(commandLine, invoker);

        // Assert
        Assert.Null(result);
    }
}