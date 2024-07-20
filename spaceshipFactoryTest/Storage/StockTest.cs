using JetBrains.Annotations;
using spaceshipFactory.Storage;
using Xunit;

namespace TestProject1.Storage
{
    [TestSubject(typeof(Stock))]
    public class StockTest
    {
        /// <summary>
        /// Assert that GetInstance  return the same instance 
        /// </summary>
        [Fact]
        public void GetInstance_ShouldReturnSameInstance()
        {
            // Arrange
            var instance1 = Stock.GetInstance();
            var instance2 = Stock.GetInstance();

            // Assert
            Assert.Same(instance1, instance2);
        }
    }
}