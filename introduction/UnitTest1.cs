using Xunit;

namespace introduction
{
    public class UnitTest1
    {
        private int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }
    }
}