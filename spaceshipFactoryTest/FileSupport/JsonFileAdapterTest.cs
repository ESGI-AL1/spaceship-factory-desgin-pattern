using JetBrains.Annotations;
using Newtonsoft.Json;
using spaceshipFactory.FileSupport;

namespace TestProject1.FileSupport;

[TestSubject(typeof(JsonFileAdapter))]
public class JsonFileAdapterTest
{

    [Fact]
    public void METHOD()
    {
        
    }

        /// <summary>
        /// Verifies that the SaveOutput method of the JsonFileAdapter correctly serializes the output
        /// as JSON and writes it to a file.
        /// </summary>
        [Fact]
        public void SaveOutput_ShouldSerializeJsonToFile()
        {
            // Arrange
            var adapter = new JsonFileAdapter();
            var filePath = "output_jsonfile.json";
            var output = new List<string> { "SUCCESS: STOCKS command executed", "ERROR: VERIFY command failed" };

            // Act
            adapter.SaveOutput(filePath, output);
            var jsonContent = File.ReadAllText(filePath);
            var lines = JsonConvert.DeserializeObject<List<string>>(jsonContent);

            // Assert
            Assert.NotNull(lines);
            Assert.Equal(2, lines.Count);
            Assert.Equal("SUCCESS: STOCKS command executed", lines[0]);
            Assert.Equal("ERROR: VERIFY command failed", lines[1]);

            // Cleanup
            File.Delete(filePath);
        }
}