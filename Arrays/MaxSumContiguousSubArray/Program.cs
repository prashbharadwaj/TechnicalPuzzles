using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxSumContiguousSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = new List<int>() { -500 };
            int maxSum = maxSubArray(arr);

            List<int> arr2 = new List<int>() { -2, 1, -3, 4, -1, 2, 1, -5, 4};
            maxSubArrayWithMaxSum(arr2);

            Console.ReadKey();
        }

        // KADANE method to find the sum of a maximum contiguous subarray
        static int maxSubArray(List<int> A)
        {
            if (A == null || A.Count == 0)
            {
                return 0;
            }

            int max_ending_here = 0;
            int max_so_far = int.MinValue;
            for (int indx = 0; indx < A.Count; indx++)
            {
                max_ending_here += A[indx];

                // Find the max till here. If the current number is greater than the sum, use that as the max
                // The below methods work for a fully negative array
                max_ending_here = Math.Max(A[indx], max_ending_here);
                max_so_far = Math.Max(max_so_far, max_ending_here);
            }

            return max_so_far;
        }

        // KADANE method to find the sum of the maximum contiguous subarray
        static void maxSubArrayWithMaxSum(List<int> arr)
        {
            int max = int.MinValue;
            int currMax = 0;
            int s = 0;
            int start = 0;
            int end = 0;

            for(int indx = 0; indx < arr.Count; indx++)
            {
                currMax += arr[indx];
                
                // Mark the next start and end
                if (max < currMax)
                {
                    max = currMax;
                    start = s;
                    end = indx;
                }

                // Note down the next start
                if (currMax < 0)
                {
                    currMax = 0;
                    s = indx + 1;
                }
            }

            Console.WriteLine("Max contiguous sum is {0}", max);
            Console.WriteLine("Max contiguous subarray starts at {0} and ends at {1}", start, end);
        }
    }
}
