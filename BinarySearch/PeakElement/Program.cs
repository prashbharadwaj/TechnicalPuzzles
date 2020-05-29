using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3 };
            int peakIndex = new Solution().FindPeakElement(nums);
            Console.Read();
        }
    }

    // Accepted solution on Leet code
    public class Solution
    {
        public int FindPeakElement(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return -1;

            if (nums.Length == 1)
                return 0;

            if (nums.Length == 2)
                return nums[0] > nums[1] ? 0 : 1;

            return FindPeakIndex(nums, 0, nums.Length - 1);
        }

        public int FindPeakIndex(int[] nums, int start, int end)
        {
            if (start > end)
                return -1;

            // If we have come to this stage, this must be peak element
            if (start == end)
                return start;

            int mid = start + (end - start) / 2;
            int midValue = nums[mid];
            if (mid == start)
            {
                if (midValue > nums[mid + 1])
                    return mid;
                else
                {
                    return FindPeakIndex(nums, mid + 1, end);
                }
            }

            if (mid == end)
            {
                if (midValue > nums[mid - 1])
                     return mid;
                else
                {
                    return FindPeakIndex(nums, start, mid - 1);
                }
            }

            if (nums[mid - 1] < nums[mid] && nums[mid] < nums[mid + 1])
            {
                // Peak is in right half
                return FindPeakIndex(nums, mid + 1, end);
            }
            else if (nums[mid - 1] > nums[mid] && nums[mid] > nums[mid + 1])
            {
                // Peak is in left half
                return FindPeakIndex(nums, start, mid - 1);
            }
            else if (nums[mid - 1] > nums[mid] && nums[mid] < nums[mid + 1])
            {
                // Peak is on either side
                return FindPeakIndex(nums, mid + 1, end);
            }
            else
            {
                return mid;
            }
        }
    }
}
