using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyQueries
{
    public class Program
    {
        static void Main(string[] args)
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var result = freqQuery(a);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        public static List<int> freqQuery(List<List<int>> queries)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            Dictionary<int, int> count = new Dictionary<int, int>();
            List<int> result = new List<int>();

            foreach (var item in queries)
            {
                if (item[0] == 1)
                {
                    if (d.ContainsKey(item[1]))
                    {
                        count[d[item[1]]]--;
                        d[item[1]]++;
                        if (count.ContainsKey(d[item[1]]))
                            count[d[item[1]]]++;
                        else
                            count.Add(d[item[1]], 1);

                    }
                    else
                    {
                        d.Add(item[1], 1);
                        if (count.ContainsKey(1))
                            count[1]++;
                        else count.Add(1, 1);
                    }
                }
                else if(item[0] == 2)
                {
                    if (d.ContainsKey(item[1]))
                    {
                        if (d[item[1]] > 1)
                        {
                            count[d[item[1]]]--;
                            d[item[1]]--;
                            count[d[item[1]]]++;

                        }
                        else
                        {
                            d.Remove(item[1]);
                            count[1]--;
                        }
                    }
                }
                else
                {
                    if (count.ContainsKey(item[1]) && count[item[1]] > 0)
                        result.Add(1);
                    else
                        result.Add(0);
                }
            }


            return result;
        }
        
    }
}
