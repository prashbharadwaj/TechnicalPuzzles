using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This question was asked in the Identity team loop

// Challenges: What will you mark the found regions with and also how much should be marked ?
//             Initial approach was to mark with region count but that will special case 1st region
//             Also, the initial approach was to just mark the region around a given one but that will
//             cause issues as we iterate through the solution where we may mark an already existing region as
//             a separate region

//             Final solution was to mark everything when the starting of a region is found (greedy way ?). This way
//             there is no need to worry about marking a region with a separate count. They can just be reverted back to '0'

/// <summary>
///  Given a matrix that has a few ones clustered, count the clustering of ones such that
///  ones reachable row wise and column wise are the only ones counted
/// </summary>
namespace MatrixRegionCount
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static int CountMatrixRegions(int[,] matArr)
        {
            if (matArr == null || matArr.GetLength(0) == 0 || matArr.GetLength(1) == 0)
            {
                throw new ArgumentException();
            }

            int regionCount = 0;
            for (int i = 0; i < matArr.GetLength(0); i++)
            {
                for (int j = 0; j < matArr.GetLength(1); j++)
                {
                    if (matArr[i,j] == 1)
                    {
                        MarkRegion(matArr, i, j, 0);
                        regionCount++;
                    }
                }
            }

            return regionCount;
        }

        static void MarkRegion(int[,] mat, int i, int j, int val)
        {
            if (i - 1 >= 0 && mat[i-1, j] == 1)
            {
                mat[i - 1, j] = 0;
                MarkRegion(mat, i - 1, j, val);
            }

            if (i+1 < mat.GetLength(0) && mat[i+1, j] == 1)
            {
                mat[i + 1, j] = 0;
                MarkRegion(mat, i + 1, j, val);
            }

            if (j-1 >= 0 && mat[i, j-1] == 1)
            {
                mat[i, j - 1] = 0;
                MarkRegion(mat, i, j - 1, val);
            }

            if (j+1 < mat.GetLength(1) && mat[i, j+1] == 1)
            {
                mat[i, j + 1] = 0;
                MarkRegion(mat, i, j + 1, val);
            }
        }

        static bool IsValid(int x, int y, int[,] mat)
        {
            // Validate if co-ordinates are within bounds
            if (x < 0 || x > mat.GetLength(0))
                return false;

            if (y < 0 || y > mat.GetLength(1))
                return false;

            return true;
        }

        // Iterative marking can be thought of as graph traversal
        static void MarkRegionIterative(int[,] mat, int i, int j, int val)
        {
            // Can do either DFS or BFS
            // We do DFS below
            Stack<Tuple<int, int>> s = new Stack<Tuple<int, int>>();
            s.Push(new Tuple<int, int>(i, j));

            while (s.Count != 0)
            {
                var dim = s.Pop();

                // Mark the obtained co-ordinate as visited
                mat[dim.Item1, dim.Item2] = 0;

                // Add all the reachable co-ordinates to the stack
                // no diagonals
                for (int x = i - 1; x <= i +1; x++)
                {
                    for (int y = j-1; j <= j+1; j++)
                    {
                        if (IsValid(x, y, mat))
                        {
                            s.Push(new Tuple<int, int>(x, y));
                        }
                    }
                }
            }
        }
    }
}
