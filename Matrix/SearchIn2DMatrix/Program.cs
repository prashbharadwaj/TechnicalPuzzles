using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Discuss
Pick One

Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:

Integers in each row are sorted from left to right.
The first integer of each row is greater than the last integer of the previous row.

For example,
Consider the following matrix: 
[
  [1,   3,  5,  7],
  [10, 11, 16, 20],
  [23, 30, 34, 50]
]
Given target = 3, return true.
*/

namespace SearchIn2DMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat = new int[,] { {-8, -7, -5, -3, -3, -1, 1 },
                                      { 2,  2,  2,  3,  3,  5, 7 },
                                      { 8,  9, 11, 11, 13, 15, 17 },
                                      { 18, 18, 18, 20, 20, 20, 21},
                                      { 23, 24, 26, 26, 26, 27, 27},
                                      { 28, 29, 29, 30, 32, 32, 34}
                                    };
            Solution soln = new Solution();
            bool exists = soln.SearchMatrix(mat, -5);
            Console.WriteLine("Value {0} exists : {1}", -5, exists);
            Console.Read();
        }
    }

    // Working solution that was accepted on LeetCode
    public class Solution
    {
        public bool SearchMatrix(int[,] matrix, int target)
        {
            // GetLength OR condition is important
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return false;

            // Start from last element of first row
            int x = 0;
            int y = matrix.GetLength(1) - 1;
            while (x < matrix.GetLength(0))
            {
                if (target == matrix[x, y])
                    return true;
                else if (target > matrix[x, y])
                {
                    x += 1;
                }
                else
                {
                    if (target == matrix[x, 0])
                        return true;
                    else if (target > matrix[x, 0])
                    {
                        return BinarySearch(matrix, x, target);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        bool BinarySearch(int[,] matrix, int row, int target)
        {
            int l = 0;
            int h = matrix.GetLength(1) - 1;
            
            // Important condition to check for all entries. l <= h (lesser than or equal to) is important
            while (l <= h)
            {
                int mid = l + (h - l) / 2;
                if (matrix[row, mid] == target)
                    return true;
                else if (matrix[row, mid] > target)
                {
                    h = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return false;
        }
    }
}
