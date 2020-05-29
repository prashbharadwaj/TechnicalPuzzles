using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxContainer
{
    /*
        Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). 
        n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines,
        which together with x-axis forms a container, such that the container contains the most water. 
        Note: You may not slant the container and n is at least 2. 
    */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Solution
        {
            // End ones are a candidate as they are wide
            // Discard the one with lower height and continue to keep track of the maximum
            // Continue discarding the minimum till the indices converge
            public int MaxArea(int[] height)
            {
                if (height == null || height.Length == 0)
                    return 0;

                int maxArea = 0;
                int i = 0;
                int j = height.Length - 1;

                while (i < j)
                {
                    maxArea = Math.Max(maxArea, (j - i) * Math.Min(height[i], height[j]));
                    if (height[i] < height[j])
                    {
                        i += 1;
                    }
                    else
                    {
                        j -= 1;
                    }
                }

                return maxArea;
            }
        }
    }
}
