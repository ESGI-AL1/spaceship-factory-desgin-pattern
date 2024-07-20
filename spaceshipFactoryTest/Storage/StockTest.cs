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
        
        
        /// <summary>
        /// Assert that the get the right movement of stock
        /// </summary>
        [Fact]
        public void GetMovements_ShouldListAllMovements()
        {
            var stock = Stock.GetInstance();
            stock.InitStock();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                stock.GetMovements();
                var result = sw.ToString().Trim();

                Assert.Contains("INCREASE 10 Hull_HC1", result);
                Assert.Contains("INCREASE 1 Hull_HE1", result);
                Assert.Contains("INCREASE 2 Wings_WE1", result);
                Assert.Contains("INCREASE 1 Thruster_TE1", result);
            }
        }

        /// <summary>
        /// Assert that the methode GetMovements(string[] args) print the wright movements of stock
        /// </summary>
        [Fact]
        public void GetMovements_WithArgs_ShouldListFilteredMovements()
        {
            var stock = Stock.GetInstance();
            stock.InitStock();
            var args = new string[] { "Hull_HC1", "Wings_WE1" };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                stock.GetMovements(args);
                var result = sw.ToString().Trim();

                Assert.Contains("INCREASE 10 Hull_HC1", result);
                Assert.Contains("INCREASE 2 Wings_WE1", result);
                Assert.DoesNotContain("INCREASE 1 Hull_HE1", result);
                Assert.DoesNotContain("INCREASE 1 Thruster_TE1", result);
            }
        }

        /// <summary>
        /// Assert listing  the all wright instructions  to assembly spaceship depends on command
        /// </summary>
        [Fact]
        public void ListInstruction_ShouldListAllInstructions()
        {
            var stock = Stock.GetInstance();
            stock.InitStock();
            var command = new Dictionary<string, int> { { "Explorer", 1 } };

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                stock.ListInstruction(command);
                var result = sw.ToString().Trim();

                Assert.Contains("PRODUCING Explorer", result);
                Assert.Contains("GET_OUT_STOCK 1 Hull_HE1", result);
                Assert.Contains("GET_OUT_STOCK 1 Engine_EE1", result);
                Assert.Contains("GET_OUT_STOCK 2 Wings_WE1", result);
                Assert.Contains("GET_OUT_STOCK 1 Thruster_TE1", result);
                Assert.Contains("ASSEMBLE TMP1 Hull_HE1 Engine_EE1", result);
                Assert.Contains("ASSEMBLE TMP1 Wings_WE1", result);
                Assert.Contains("ASSEMBLE TMP3 [TMP1,Wings_WE1] Thruster_TE1", result);
                Assert.Contains("ASSEMBLE TMP3 Thruster_TE1", result);
                Assert.Contains("FINISHED Explorer", result);
            }
        }

    }
    
}