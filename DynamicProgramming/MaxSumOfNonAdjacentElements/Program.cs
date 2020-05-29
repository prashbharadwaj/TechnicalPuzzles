using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Given an array of integers, find a maximum sum of non-adjacent elements.
For example, inputs [1, 0, 3, 9, 2] should return 10 (1 + 9).

Analysis:
Suppose we know the max sum for all subarrays, how can it help us to solve the overall problem?
Let’s use max_sum[i] denote the maximum sum for subarray arr[0…i]. If the last number arr[i] is included in the sum, max_sum[i] should equal
to arr[i] + max_sum[i-2] (because arr[i-1] cannot be included). Similarly, if arr[i] isn’t included, then max_sum[i] should equal to 
arr[i-1].Therefore, we have the following formula:
max_sum[i] = MAX(arr[i] + max_sum[i-2], max_sum[i-1])
*/
namespace MaxSumOfNonAdjacentElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 0, 3, 9, 2};
            int maxSum = MaxSumNAHelper(arr, arr.Length - 1);
            Console.WriteLine("Max sum of non adjacent elements is {0}", maxSum);
            Console.Read();
        }

        // Top down
        static int MaxSumNAHelper(int[] arr, int indx)
        {
            if (indx == 0)
            {
                return arr[0];
            }

            if (indx == 1)
            {
                return Math.Max(arr[0], arr[1]);
            }

            // Max(currElem + func(arr[i - 2]), func(arr[i-1]))
            return Math.Max(arr[indx] + MaxSumNAHelper(arr, indx - 2), MaxSumNAHelper(arr, indx - 1));
        }

        // Optimized using memoization
        static int MaxSumNAHelperDyn(int[] arr, int indx, int[] memo)
        {
            if (indx == 0)
            {
                return arr[0];
            }

            if (indx == 1)
            {
                return Math.Max(arr[0], arr[1]);
            }

            if (memo[indx] != -1)
            {
                return memo[indx];
            }

            memo[indx] = Math.Max(arr[indx] + MaxSumNAHelperDyn(arr, indx - 2, memo), MaxSumNAHelperDyn(arr, indx - 1, memo));
            return memo[indx];
        }

        static int MaxSumDynBottomUp(int[] arr)
        {
            int result = 0, prevOne = 0, prevTwo = 0;
            for (int indx = 0; indx < arr.Length; indx++)
            {
                if (indx == 0)
                {
                    result = arr[indx];
                }
                else if (indx == 1)
                {
                    result = Math.Max(arr[0], arr[1]);
                }
                else
                {
                    result = Math.Max(arr[indx] + prevTwo, prevOne);
                }

                prevTwo = prevOne;
                prevOne = result;
            }

            return result;
        }
    }
}
