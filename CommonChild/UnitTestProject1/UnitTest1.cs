using System;
using Xunit;
using CommonChild;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("HARRY","SALLY", 2)]
        [InlineData("ABCDEF", "FBDAMN", 2)]
        [InlineData("AA", "BB", 0)]
        public void TestMethod1(string input1, string input2, int expected )
        {
            int actual = Program.commonChild(input1, input2);
            Assert.Equal(expected, actual);
        }
    }
}
