using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
            int lis = LIS(arr);
            Console.WriteLine("Longest increasing subsequence is {0}", lis);

            int lisD = LISDynamic(arr);
            Console.WriteLine("Longest increasing subsequence with LISDynamic is {0}", lisD);
            Console.Read();

            // Check out O(nlogn) solution at: http://www.geeksforgeeks.org/longest-monotonically-increasing-subsequence-size-n-log-n/
        }

        static int LIS(int[] arr)
        {
            return LisHelper(arr, 0, Int32.MinValue);
        }

        static int LisHelper(int[] arr, int i, int prev)
        {
            if (i == arr.Length)
            {
                return 0;
            }

            // Exclude the current element and go with previous
            int excl = LisHelper(arr, i + 1, prev);
            int incl = 0;
            if (arr[i] > prev)
            {
                // Include the current element and increment subsequence size
                incl = 1 + LisHelper(arr, i + 1, arr[i]);
            }

            return Math.Max(incl, excl);
        }

        static int LISDynamic(int[] arr)
        {
            // Build LIS array L bottom up
            int[] L = new int[arr.Length];

            // Initialize L with '1'
            for (int i = 0; i < arr.Length; i++)
            {
                L[i] = 1;
            }

            // Build up L based on the LIS optimal substructure from overlapping subproblems
            for (int j = 1; j < arr.Length; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    if (arr[i] < arr[j] && L[j] < L[i] + 1)
                    {
                        L[j] = L[i] + 1;
                    }
                }
            }

            // Find the max value in L to get LIS value
            int max = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < L[i])
                {
                    max = L[i];
                }
            }

            return max;
        }
    }
}
