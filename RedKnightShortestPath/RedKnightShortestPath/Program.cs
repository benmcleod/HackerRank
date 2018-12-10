using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedKnightShortestPath
{

    public class Program
    {
        static void Main(string[] args)
        {
            //https://www.hackerrank.com/challenges/red-knights-shortest-path/problem

        }
        public static string printShortestPath(int n, int i_start, int j_start, int i_end, int j_end)
        {
            int[,] grid = new int[n,n];
            grid[i_start, i_end] = 1;

            Queue<Location> q = new Queue<Location>();
            q.Enqueue(new Location(i_start, j_start, "", 0));

            while(q.Count > 0)
            {
                var currentLocation = q.Dequeue();

                if(currentLocation.x == j_end && currentLocation.y == i_end)
                {
                    return $"{currentLocation.moves}{currentLocation.path}";
                }
                
                // moves

                // ul
                if(currentLocation.y >= 2 && currentLocation.x >= 1 && grid[currentLocation.y-2,currentLocation.x-1] == 0)
                {
                    grid[currentLocation.y - 2, currentLocation.x - 1] = 1;
                    q.Enqueue(new Location(currentLocation.y - 2, currentLocation.x - 1, currentLocation.path + " UL", currentLocation.moves + 1));
                }

                // ur
                if (currentLocation.y >= 2 && currentLocation.x <= n - 2 && grid[currentLocation.y - 2, currentLocation.x + 1] == 0)
                {
                    grid[currentLocation.y - 2, currentLocation.x + 1] = 1;
                    q.Enqueue(new Location(currentLocation.y - 2, currentLocation.x + 1, currentLocation.path + " UR", currentLocation.moves + 1));
                }
                // r
                if(currentLocation.x <= n - 3 && grid[currentLocation.y,currentLocation.x + 2] == 0)
                {
                    grid[currentLocation.y, currentLocation.x + 2] = 1;
                    q.Enqueue(new Location(currentLocation.y, currentLocation.x + 2, currentLocation.path + " R", currentLocation.moves + 1));
                }


                // lr
                if (currentLocation.y <= n - 3 && currentLocation.x <= n - 2 && grid[currentLocation.y + 2, currentLocation.x + 1] == 0)
                {
                    grid[currentLocation.y + 2, currentLocation.x + 1] = 1;
                    q.Enqueue(new Location(currentLocation.y + 2, currentLocation.x + 1, currentLocation.path + " LR", currentLocation.moves + 1));
                }

                // ll
                if (currentLocation.y <= n - 3 && currentLocation.x >= 1 && grid[currentLocation.y + 2, currentLocation.x - 1] == 0)
                {
                    grid[currentLocation.y + 2, currentLocation.x - 1] = 1;
                    q.Enqueue(new Location(currentLocation.y + 2, currentLocation.x - 1, currentLocation.path + " LL", currentLocation.moves + 1));
                }

                // l

                if (currentLocation.x >= 2 && grid[currentLocation.y, currentLocation.x - 2] == 0)
                {
                    grid[currentLocation.y, currentLocation.x - 2] = 1;
                    q.Enqueue(new Location(currentLocation.y, currentLocation.x - 2, currentLocation.path + " L", currentLocation.moves + 1));
                }

            }


            return "Impossible";
        }
    }

    public class Location
    {
        public Location(int y, int x, string path, int moves)
        {
            this.y = y;
            this.x = x;
            this.path = path;
            this.moves = moves;
        }

        public string path { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int moves { get; set; }
    }
}
