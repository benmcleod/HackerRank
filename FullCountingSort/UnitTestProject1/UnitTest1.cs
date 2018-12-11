using System;
using Xunit;
using FullCountingSort;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(20,@"C:\Users\Ben\source\repos\FullCountingSort\UnitTestProject1\TextFile1.txt", "- - - - - to be or not to be - that is the question - - - -")]
        public void TestMethod1(int n, string path, string expected)
        {
            string[] input = File.ReadAllLines(path);


            List<List<string>> arr = new List<List<string>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(input[i].TrimEnd().Split(' ').ToList());
            }

            var actual = Program.countSort(arr);
            Assert.Equal(expected, actual);

        }
    }
}
