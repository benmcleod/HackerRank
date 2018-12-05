using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountLuck
{
    public class Location
    {
        public Location(Tuple<int, int> xy, int turns)
        {
            XY = xy;
            Turns = turns;
        }

        public int Turns { get; set; }
        public Tuple<int, int> XY { get; set; }
    }


    public class Program
    {
        static void Main(string[] args)
        {


            string[] lines = File.ReadAllLines(@"C:\Users\Ben\source\repos\CountLuck\CountLuck\test1.txt");
            CountLuck(lines, 1);

        }



        public static string CountLuck(string[] matrix, int k)
        {
            int wandwaves = 0;
            Queue<Location> q = new Queue<Location>();

            char[][] forest = matrix.Select(item => item.ToArray()).ToArray();

            Tuple<int, int> loc = findIndex(forest);

            q.Enqueue(new Location(loc, 0));

            while (q.Count() > 0)
            {
                bool left = false;
                bool right = false;
                bool up = false;
                bool down = false;

                int availableMovements = 0;
                Location currentLoc = q.Dequeue();
                wandwaves = currentLoc.Turns;

                //mark current location as visited
                forest[currentLoc.XY.Item1][currentLoc.XY.Item2] = '0';

                //find next location - add it to queue
                //down
                if (currentLoc.XY.Item1 < forest.Count() - 1)
                {
                    if (forest[currentLoc.XY.Item1 + 1][currentLoc.XY.Item2] == '.')
                    {
                        availableMovements++;
                        down = true;
                        
                    }
                    if (forest[currentLoc.XY.Item1 + 1][currentLoc.XY.Item2] == '*')
                    {
                        availableMovements++;
                        q.Clear();
                    }
                }
                //up
                if (currentLoc.XY.Item1 > 0)
                {
                    if (forest[currentLoc.XY.Item1 - 1][currentLoc.XY.Item2] == '.')
                    {
                        availableMovements++;
                        up = true;
                        
                    }
                    if (forest[currentLoc.XY.Item1 - 1][currentLoc.XY.Item2] == '*')
                    {
                        availableMovements++;
                        q.Clear();
                    }
                }
                //left
                if (currentLoc.XY.Item2 > 0)
                {
                    if (forest[currentLoc.XY.Item1][currentLoc.XY.Item2 - 1] == '.')
                    {
                        availableMovements++;
                        left = true;

                    }
                    if (forest[currentLoc.XY.Item1][currentLoc.XY.Item2 - 1] == '*')
                    {
                        availableMovements++;
                        q.Clear();
                    }
                }
                //right
                if (currentLoc.XY.Item2 < forest[0].Length - 1)
                {
                    if (forest[currentLoc.XY.Item1][currentLoc.XY.Item2 + 1] == '.')
                    {
                        availableMovements++;
                        right = true;

                    }
                    if (forest[currentLoc.XY.Item1][currentLoc.XY.Item2 + 1] == '*')
                    {
                        availableMovements++;
                        q.Clear();
                    }
                }



                if (availableMovements > 1)
                {
                    wandwaves++;
                }

                if (up) q.Enqueue(new Location(Tuple.Create(currentLoc.XY.Item1 - 1, currentLoc.XY.Item2), wandwaves));
                if (down) q.Enqueue(new Location(Tuple.Create(currentLoc.XY.Item1 + 1, currentLoc.XY.Item2), wandwaves));
                if (right) q.Enqueue(new Location(Tuple.Create(currentLoc.XY.Item1, currentLoc.XY.Item2 + 1), wandwaves));
                if (left) q.Enqueue(new Location(Tuple.Create(currentLoc.XY.Item1, currentLoc.XY.Item2 - 1), wandwaves));

            }
            //return wandWaves.ToString();
            return (wandwaves == k) ? "Impressed" : "Oops!";

        }

        public static Tuple<int, int> findIndex(char[][] forest)
        {
            for (int rows = 0; rows < forest.Count(); rows++)
            {
                for (int col = 0; col < forest[rows].Length; col++)
                {
                    if (forest[rows][col] == 'M')
                    {
                        return Tuple.Create(rows, col);
                    }
                }
            }
            return Tuple.Create(0, 0);
        }
    }
}
