using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).
The robot can only move either down or right at any point in time. The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).
How many possible unique paths are there?

Above is a 3 x 7 grid. How many possible unique paths are there? 
Note: m and n will be at most 100.
*/
namespace GridUniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sln = new Solution();
            int paths = sln.UniquePaths(3, 7, new Dictionary<LocationPair, int>());
            Console.Read();
        }
    }

    public class LocationPair
    {
        public int R { get; set; }
        public int C { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            LocationPair other = (LocationPair)obj;
            if (this.R == other.R && this.C == other.C)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int result = 37;
            result *= 397;
            result += this.R;
            result *= 397;
            result += this.C;
            return result * 397;
        }
    }

    // Solution without memoization times out.
    // Solution with memoization accepted
    public class Solution
    {
        private int[,] visited;

        public int UniquePaths(int m, int n, Dictionary<LocationPair, int> memo)
        {
            if (m <= 0 || n <= 0)
                return 0;

            if (m == 1 && n == 1)
                return 1;

            visited = new int[m, n];
            return this.UniquePathHelper(new LocationPair { R = 0, C = 0 }, m, n, memo);
        }

        public int UniquePathHelper(LocationPair currLoc, int m, int n, Dictionary<LocationPair, int> memo)
        {
            if (!this.IsValid(currLoc, m, n, this.visited))
                return 0;

            if (currLoc.R == m - 1 && currLoc.C == n - 1)
                return 1;

            if (memo.ContainsKey(currLoc))
                return memo[currLoc];

            this.visited[currLoc.R, currLoc.C] = 1;

            // move right
            int count = UniquePathHelper(new LocationPair { R = currLoc.R, C = currLoc.C + 1 }, m, n, memo);

            // move down
            count += UniquePathHelper(new LocationPair { R = currLoc.R + 1, C = currLoc.C }, m, n, memo);

            //Back track
            this.visited[currLoc.R, currLoc.C] = 0;

            memo.Add(currLoc, count);

            return count;
        }

        public bool IsValid(LocationPair currLoc, int m, int n, int[,] visited)
        {
            if (currLoc.R < 0 || currLoc.R >= m || currLoc.C < 0 || currLoc.C >= n)
                return false;

            if (visited[currLoc.R, currLoc.C] == 1)
                return false;

            return true;
        }
    }
}
