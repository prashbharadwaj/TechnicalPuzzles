using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInRotatedSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 4, 5, 6, 7, 8, 1, 2, 3 };
            var sln = new Solution();
            int result = sln.Search(nums, 8);
            Console.WriteLine("Result obtained is {0}", result);
            Console.Read();
        }
    }

    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            return Search(nums, 0, nums.Length - 1, target);
        }

        public int Search(int[] nums, int l, int r, int target)
        {
            if (r < l)
            {
                return -1;
            }

            int mid = l + (r - l) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }

            // Left side is ordered
            if (nums[l] < nums[mid])
            {
                // Target within the left range
                if (target >= nums[l] && target <  nums[mid])
                {
                    // Search left
                    return Search(nums, l, mid - 1, target);
                }
                else
                {
                    // Search right
                    return Search(nums, mid+1, r, target);
                }
            }
            // right is ordered
            else if (nums[l] > nums[mid])
            {
                // Check if target is within right range
                if (target > nums[mid] && target <= nums[r])
                {
                    // search right
                    return Search(nums, mid+1, r, target);
                }
                else
                {
                    // search left
                    return Search(nums, l, mid-1, target);
                }
            }
            // left is equal to mid, case where the entire left half contains equal elements
            else if (nums[mid] == nums[l])
            {
                // Check if right is larger than mid
                if (nums[r] > nums[mid])
                {
                    // Search right
                    return Search(nums, mid + 1, r, target);
                }
                else
                {
                    // Search both left and right
                    int result = Search(nums, l, mid - 1, target);
                    if (result == -1)
                    {
                        return Search(nums, mid + 1, r, target);
                    }
                }
            }

            return -1;
        }
    }
}
