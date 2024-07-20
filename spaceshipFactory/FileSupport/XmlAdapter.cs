using System.Xml.Serialization;

namespace spaceshipFactory.FileSupport;

public class XmlFileAdapter : IFileAdapter
{
    public List<string>? LoadCommands(string filePath)
    {
        var serializer = new XmlSerializer(typeof(List<string>));
        using var reader = new StreamReader(filePath);
        return (List<string>)serializer.Deserialize(reader)!;
    }

    public void SaveOutput(string filePath, List<string> output)
    {
        var serializer = new XmlSerializer(typeof(List<string>));
        using var writer = new StreamWriter(filePath);
        serializer.Serialize(writer, output);
    }
}
