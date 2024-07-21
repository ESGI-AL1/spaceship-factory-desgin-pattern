using FluentAssertions;

namespace TestProject1;

public class SpaceshipFactoryTest
{
    [Fact]
    public void Test1()
    {
        1.Should().Be(1);
    }
    
    [Fact]
    public void Test2()
    {
        IEnumerable<int> numbers = new[] { 1, 2, 3 };
        numbers.Should().OnlyContain(n => n > 0);
    }
    
}