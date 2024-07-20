using System.Reflection;
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
    /// <summary>
    /// Verifies that the ParseArgs method returns a correct dictionary
    /// when given valid arguments, using reflection to access the private method.
    /// </summary>
    [Fact]
    public void ParseArgs_ShouldReturnDictionary_WhenArgsAreValid()
    {
        // Arrange
        string args = "10 spaceship1, 20 spaceship2";
        //this line bellow is use to get information and meta data from ParseArgs because this methode is private in  Class CommandParser
        MethodInfo methodInfo = typeof(CommandParser).GetMethod("ParseArgs", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(methodInfo);

        // Act
        var result = methodInfo.Invoke(_commandParser, new object[] { args }) as Dictionary<string, int>;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(10, result["spaceship1"]);
        Assert.Equal(20, result["spaceship2"]);
    }
    
    /// <summary>
    /// Vérifie que la méthode ParseArgs gère correctement les arguments avec des espaces supplémentaires,
    /// en utilisant la réflexion pour accéder à la méthode privée.
    /// </summary>
    [Fact]
    public void ParseArgs_ShouldHandleExtraSpacesCorrectly()
    {
        // Arrange
        string args = " 10 spaceship1 ,  20 spaceship2 ";
        MethodInfo methodInfo = typeof(CommandParser).GetMethod("ParseArgs", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(methodInfo);  

        // Act
        var result = methodInfo.Invoke(_commandParser, new object[] { args }) as Dictionary<string, int>;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(10, result["spaceship1"]);
        Assert.Equal(20, result["spaceship2"]);
    }
 
    [Fact]
    public void ParseArgs_ShouldReturnNull_WhenQuantitiesAreNotNumbers()
    {
        // Arrange
        string args = "ten spaceship1, 20 spaceship2";
        MethodInfo methodInfo = typeof(CommandParser).GetMethod("ParseArgs", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(methodInfo); 

        // Act
        var result = methodInfo.Invoke(_commandParser, new object[] { args });

        // Assert
        Assert.Null(result);
    }
    

    /// <summary>
    /// when  I give invalid args like TOTO  the test return nul
    /// </summary>
    [Fact]
    public void ParseArgs_ShouldReturnNull_WhenArgsAreInvalid()
    {
        // Arrange
        string args = "invalid args";
        MethodInfo methodInfo = typeof(CommandParser).GetMethod("ParseArgs", BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.NotNull(methodInfo);  // Vérifier que la méthode a bien été trouvée

        // Act
        var result = methodInfo.Invoke(_commandParser, new object[] { args });

        // Assert
        Assert.Null(result);
    }
    
}