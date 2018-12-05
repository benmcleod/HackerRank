using System;
using System.IO;
using Xunit;
using CountLuck;
using System.Linq;

namespace CountLuckUnitTestProject
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(@"C:\Users\Ben\source\repos\CountLuck\CountLuckUnitTestProject\test1.txt", 1, "Impressed")]
        [InlineData(@"C:\Users\Ben\source\repos\CountLuck\CountLuckUnitTestProject\test2.txt", 3, "Impressed")]
        [InlineData(@"C:\Users\Ben\source\repos\CountLuck\CountLuckUnitTestProject\test3.txt", 4, "Oops!")]
        [InlineData(@"C:\Users\Ben\source\repos\CountLuck\CountLuckUnitTestProject\TextFile1.txt", 1, "Oops!")]
        [InlineData(@"C:\Users\Ben\source\repos\CountLuck\CountLuckUnitTestProject\TextFile2.txt", 0, "Impressed")]
        [InlineData(@"C:\Users\Ben\source\repos\CountLuck\CountLuckUnitTestProject\TextFile3.txt", 1, "Impressed")]
        public void TestMethod1(string textfile, int turns, string expected)
        {
            string[] lines = File.ReadAllLines(textfile);
            string actual = Program.CountLuck(lines, turns);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(@"C:\Users\Ben\source\repos\CountLuck\CountLuckUnitTestProject\test1.txt",0,2)]
        public void TestFindIndex(string textfile, int x, int y)
        {
            string[] lines = File.ReadAllLines(textfile);

            char[][] forest = lines.Select(item => item.ToArray()).ToArray();

            Tuple<int, int> actual = Program.findIndex(forest);

            Assert.Equal(x, actual.Item1);
            Assert.Equal(y, actual.Item2);

        }
    }
}
