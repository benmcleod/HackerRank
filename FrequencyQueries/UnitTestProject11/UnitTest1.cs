using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using FrequencyQueries;

namespace UnitTestProject11
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            var d = File.ReadAllLines
                (@"C:\Users\Ben\source\repos\FrequencyQueries\UnitTestProject11\TextFile1.txt");
            List<List<int>> a = new List<List<int>>();
            foreach (string s in d)
            {
                a.Add(s.Split(' ').Select(Int32.Parse).ToList());
            }

            var f = File.ReadAllLines
                (@"C:\Users\Ben\source\repos\FrequencyQueries\UnitTestProject11\TextFile2.txt");
            List<int> expected = new List<int>();
            foreach (string s in f)
            {
                expected.Add(Int32.Parse(s));
            }

            
            List<int> actual = Program.freqQuery(a);

            File.WriteAllLines(@"C:\Users\Ben\source\repos\FrequencyQueries\UnitTestProject11\TextFile3.txt", actual.Select(i => i.ToString()).ToArray());
            Assert.Equal(expected,actual);
        }
        
    }
}
