namespace spaceshipFactory.FileSupport;

public class FlatFileAdapter : IFileAdapter
{
    public List<string> LoadCommands(string filePath)
    {
        return [..File.ReadAllLines(filePath)];
    }

    public void SaveOutput(string filePath, List<string> output)
    {
        File.WriteAllLines(filePath, output);
    }
}
