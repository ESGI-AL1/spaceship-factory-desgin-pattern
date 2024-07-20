namespace spaceshipFactory.FileSupport;

public interface IFileAdapter
{
    List<string>? LoadCommands(string filePath);
    void SaveOutput(string filePath, List<string> output);
}
