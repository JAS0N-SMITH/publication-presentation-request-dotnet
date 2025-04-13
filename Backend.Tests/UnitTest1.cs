using Xunit;

namespace Backend.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
    }

    public class ExampleTests
    {
        [Fact]
        public void ExampleTest_ShouldPass()
        {
            // Arrange
            int expected = 5;
            int actual = 2 + 3;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
