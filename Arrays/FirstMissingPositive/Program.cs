using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMissingPositive
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // Goal is to put all the integers within bounds in their spot in the array
    //  Given an unsorted integer array, find the first missing positive integer.
    // For example,
    // Given[1, 2, 0] return 3,
    // and[3, 4, -1, 1] return 2. 
    // Your algorithm should run in O(n) time and uses constant space.
    public class Solution
    {
        public int FirstMissingPositive(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                // If number is in its place OR number is out of bounds
                if (nums[i] == i + 1 || nums[i] <= 0 || nums[i] >= nums.Length)
                {
                    i++;
                }
                else if (nums[nums[i] - 1] != nums[i])
                {
                    // Put the number in its place e.g nums[0] = 3 and it is not equal nums[nums[0] - 1] or nums[2], which is -1
                    // Swap will make nums[0] == -1 and nums[2] = 3
                    swap(nums, i, nums[i] - 1);
                }
                else
                {
                    i++;
                }
            }

            // Go over till everything is in place
            i = 0;
            while (i < nums.Length && nums[i] == i + 1)
            {
                i++;
            }

            // Print anything that is not in place
            return i + 1;
        }

        public void swap(int[] A, int i, int j)
        {
            int tmp = A[i];
            A[i] = A[j];
            A[j] = tmp;
        }
    }
}
