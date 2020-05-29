using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            int[] emptyResult = new int[] { -1, -1 };
            if (nums == null || nums.Length == 0)
            {
                return emptyResult;
            }

            Dictionary<int, int> sumMap = new Dictionary<int, int>();
            for (int idx = 0; idx < nums.Length; idx++)
            {
                int val = nums[idx];
                if (sumMap.ContainsKey(target - val))
                {
                    return new int[] { sumMap[target - val], idx };
                }
                else
                {
                    if (!sumMap.ContainsKey(val))
                    {
                        sumMap.Add(val, idx);
                    }
                }
            }

            return emptyResult;
        }
    }
}
