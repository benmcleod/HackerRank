using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonChild
{
    public class Program
    {
        static void Main(string[] args)
        {
	    //https://www.hackerrank.com/challenges/common-child/problem
            commonChild("ABCDEF", "FBDAMN");
        }

        public static int commonChild(string s1, string s2)
        {
            int[,] result = new int[s1.Length+1,s2.Length+1];

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    if(s1[i-1] == s2[j-1])
                    {
                        result[i, j] = result[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        result[i, j] = Math.Max(result[i, j - 1], result[i - 1, j]);
                    }
                }
            }

            return result[s1.Length,s2.Length];
        }
    }
}
