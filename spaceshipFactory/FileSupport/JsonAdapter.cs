using Newtonsoft.Json;

namespace spaceshipFactory.FileSupport;

public class JsonFileAdapter : IFileAdapter
{
    public List<string>? LoadCommands(string filePath)
    {
        var json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<string>>(json);
    }

    public void SaveOutput(string filePath, List<string> output)
    {
        var json = JsonConvert.SerializeObject(output, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}
