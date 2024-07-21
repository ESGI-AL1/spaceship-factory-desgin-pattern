using System.Xml.Serialization;
using JetBrains.Annotations;
using spaceshipFactory.FileSupport;

namespace TestProject1.FileSupport;

[TestSubject(typeof(XmlFileAdapter))]
public class XmlFileAdapterTest
{

    [Fact]
    public void METHOD()
    {
        
    }
    
    
    /// <summary>
    /// Verifies that the LoadCommands method of the XmlFileAdapter correctly deserializes commands from an XML file
    /// and returns them as a list of strings.
    /// </summary>
    
    [Fact]
    public void LoadCommands_ShouldDeserializeXmlFromFile()
    {
        // Arrange
        var adapter = new XmlFileAdapter();
        var filePath = "test_xmlfile.xml";
        var commands = new List<string> { "STOCKS", "VERIFY 1 Explorer" };
        var serializer = new XmlSerializer(typeof(List<string>));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, commands);
        }

        // Act
        var loadedCommands = adapter.LoadCommands(filePath);

        // Assert
        Assert.NotNull(loadedCommands);
        Assert.Equal(2, loadedCommands.Count);
        Assert.Equal("STOCKS", loadedCommands[0]);
        Assert.Equal("VERIFY 1 Explorer", loadedCommands[1]);

        // Cleanup
        File.Delete(filePath);
    }
}
