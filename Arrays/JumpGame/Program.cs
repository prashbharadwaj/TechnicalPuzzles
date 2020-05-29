using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution soln = new Solution();
            int[] arr = { 2, 5, 0, 0 };
            // int[] arr = { 3, 2, 1, 0, 4 };
            bool canJump = soln.CanJump(arr);
            Console.WriteLine("Can jump till end of array : {0}", canJump);

            canJump = soln.CanJump2(arr);
            Console.WriteLine("Can jump till end of array : {0}", canJump);

            Console.Read();
        }
    }

    public class Solution
    {
        // Working solution but time exceeded on Leet code. There is an O(n) solution using Greedy approach
        public bool CanJump(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return false;

            Dictionary<int, bool> memo = new Dictionary<int, bool>();
            return CanJumpHelper(nums, 0, memo);
        }

        public bool CanJumpHelper(int[] nums, int index, Dictionary<int, bool> memo)
        {
            if (memo.ContainsKey(index))
                return memo[index];

            int maxJumpCount = nums[index];
            if (index + maxJumpCount >= nums.Length - 1)
            {
                memo.Add(index + maxJumpCount, true);
                return true;
            }

            for (int i = maxJumpCount; i >= 1; i--)
            {
                if (CanJumpHelper(nums, index + i, memo))
                    return true;
                else
                {
                    if (!memo.ContainsKey(index + i))
                        memo.Add(index + i, false);
                }
            }

            memo.Add(index, false);
            return false;
        }

        // Accepted O(1) solution on Leet Code
        /*
        Approach #4 (Greedy) [Accepted]
        Once we have our code in the bottom-up state, we can make one final, important observation. From a given position, 
        when we try to see if we can jump to a GOOD position, we only ever use one - the first one (see the break statement). 
        In other words, the left-most one. If we keep track of this left-most GOOD position as a separate variable, we can avoid 
        searching for it in the array. Not only that, but we can stop using the array altogether.
               Iterating right-to-left, for each position we check if there is a potential jump that reaches a GOOD index 
        (currPosition + nums[currPosition] >= leftmostGoodIndex). If we can reach a GOOD index, then our position is itself GOOD. 
        Also, this new GOOD position will be the new leftmost GOOD index. Iteration continues until the beginning of the array. If 
        first position is a GOOD index then we can reach the last index from the first position.
        To illustrate this scenario, we will use the diagram below, for input array nums = [9, 4, 2, 1, 0, 2, 0].
        We write G for GOOD, B for BAD and U for UNKNOWN. Let's assume we have iterated all the way to position 0 and we need
        to decide if index 0 is GOOD. Since index 1 was determined to be GOOD, it is enough to jump there and then be sure we
        can eventually reach index 6. It does not matter that nums[0] is big enough to jump all the way to the last index. 
        All we need is one way.
               Index  0 1 2 3 4 5 6
               nums   9 4 2 1 0 2 0
               memo   U G B B B G G
 
        */
        public bool CanJump2(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return false;

            int lastPosition = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i + nums[i] >= lastPosition)
                {
                    lastPosition = i;
                }
            }

            return lastPosition == 0;
        }
    }
}
