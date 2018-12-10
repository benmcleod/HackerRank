using System;
using Xunit;
using RedKnightShortestPath;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(7,6,6,0,1,"4 UL UL UL L")]
        [InlineData(6, 5, 1, 0, 5, "Impossible")]
        [InlineData(7, 0, 3, 4, 3, "2 LR LL")]
        public void TestMethod1(int n, int ystart, int xstart, int yend, int xend, string expected)
        {
            string actual = Program.printShortestPath(n, ystart, xstart, yend, xend);
            Assert.Equal(expected, actual);
        }
    }
}
