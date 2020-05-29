using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubregionSumIn2DArray
{
    // Given a 2D array find the sum of a subregion of this array. It can be done in O(MN) time using two 'for' loops
    // If the constraint is that this function will be called multiple times, potentially thousands of times, the optimal way to do this
    // is to build a 2D matrix containing the sum of all the values from (0, 0) -> (x, y) in one pass through the original matrix and use
    // constant time to look up sum of a subregion from this built matrix
    //
    // To build a sum matrix, we use the formula: Sum(x, y) = Sum(x-1, y) + Sum(x, y-1) - Sum(x-1, y-1)
    // Given this matrix, and given a subregion (r1,c1) -> (r2,c2) and the computed Sum(M, N) array, we can use the following to calculate 
    // sum of a sub-region in constant time:
    // SUM({r1,c1} -> {r2,c2}) => Sum(r2, c2) - Sum(r1 -1, c2) - Sum(r2, c1 - 1) + Sum(r1 - 1, c1 - 1)
    // where SUM is a number and Sum(r, c) are co-ordinates in the built array using dynamic programming
    //
    // Watch Tushar Roy's video to understand more
    // https://www.youtube.com/watch?v=PwDqpOMwg6U
    class Program
    {
        // Sum array is the calculated array and is one dimension more for simplicity
        static int[,] sum;

        static void Main(string[] args)
        {
            int[,] arr = new int[,]
            {
                {3, 0, 1, 4 },
                {5, 6, 3, 2 },
                {1, 2, 0, 1 },
                {4, 1, 0, 1 }
            };

            // O(MN) for precomputation
            PreComputeSumArray(arr);

            // All subsequent calls to GetSubregionSum will be in constant time O(1)
            int r1 = 1;
            int c1 = 2;
            int r2 = 2;
            int c2 = 3;
            int srSum = GetSubregionSum(1, 2, 2, 3);

            Console.WriteLine("Sub region sum for r1 = {0}, c1 = {1} => r2 = {2}, c2 = {3} is {4}", r1, c1, r2, c2, srSum);
            Console.Read();
        }

        static void PreComputeSumArray(int[,] arr)
        {
            int sumRow = arr.GetLength(0) + 1;
            int sumColumn = arr.GetLength(1) + 1;
            sum = new int[sumRow, sumColumn];

            for (int i = 1; i < sumRow; i++)
            {
                for (int j = 1; j < sumColumn; j++)
                {
                    sum[i, j] = arr[i - 1, j - 1] + sum[i, j - 1] + sum[i - 1, j] - sum[i - 1, j - 1];
                }
            }
        }

        static int GetSubregionSum(int r1, int c1, int r2, int c2)
        {
            // Transform incoming parameters to work precomputed sum array 
            // for code readability, since sum array is constructed with an offset of 1 higher
            int sumRow1 = r1 + 1;
            int sumRow2 = r2 + 1;
            int sumColumn1 = c1 + 1;
            int sumColumn2 = c2 + 1;

            int srSum = sum[sumRow2, sumColumn2] - sum[sumRow1 - 1, sumColumn2] - sum[sumRow2, sumColumn1 - 1] + sum[sumRow1 - 1, sumColumn1 - 1];
            return srSum;
        }
    }
}
