using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCountingSort
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static string countSort(List<List<string>> arr)
        {
            StringBuilder[] sortedInput = new StringBuilder[100];
            for (int i = 0; i < 100; i++)
            {
                sortedInput[i] = new StringBuilder();
            }

            for (int i = 0; i < arr.Count() / 2; i++)
            {
                sortedInput[int.Parse(arr[i][0], CultureInfo.InvariantCulture)].Append("- ");
            }
            for (int i = arr.Count() / 2; i < arr.Count(); i++)
            {
                sortedInput[int.Parse(arr[i][0], CultureInfo.InvariantCulture)].Append(arr[i][1]).Append(" ");

            }

            string result = "";

            foreach (var item in sortedInput)
            {
                result += item;
                
            }



            return result.TrimEnd();
        }
    }
}
