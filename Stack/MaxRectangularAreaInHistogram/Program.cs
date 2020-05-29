using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxRectangularAreaInHistogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] histo = new int[] { 2, 3, 1, 5, 3, 3, 2, 1 };
            int maxRectAreaInHistogram = GetMaxAreaInHistogram(histo);
            Console.WriteLine("Max rectangular area in histogram is {0}", maxRectAreaInHistogram);
            Console.Read();
        }

        static int GetMaxAreaInHistogram(int[] histo)
        {
            int maxArea = 0;
            Stack<int> heightS = new Stack<int>();
            Stack<int> indexS = new Stack<int>();

            for (int i = 0; i < histo.Length; i++)
            {
                int val = histo[i];
                if (i == 0 || val > heightS.Peek())
                {
                    heightS.Push(val);
                    indexS.Push(i + 1);
                }
                else if (val < heightS.Peek())
                {
                    // Pop previous height and update maxArea
                    int currMaxArea = PopAndComputeArea(val, heightS, indexS);
                    maxArea = Math.Max(maxArea, currMaxArea);
                    if (heightS.Count == 0)
                    {
                        heightS.Push(val);
                    }
                    else if (val == heightS.Peek())
                    {
                        indexS.Pop();
                    }
                    else if (val > heightS.Peek())
                    {
                        heightS.Push(val);
                    }

                    indexS.Push(i + 1);
                }
                else if ( val == heightS.Peek())
                {
                    indexS.Pop();
                    indexS.Push(i + 1);
                }
            }

            // Pop the stacks and get the max area
            while (heightS.Count > 0 && indexS.Count > 0)
            {
                // Stack should have elements in ascending order
                maxArea = ComputeArea(maxArea, heightS, indexS);
            }

            return maxArea;
        }

        private static int ComputeArea(int maxArea, Stack<int> heightS, Stack<int> indexS)
        {
            int currentVal = heightS.Pop();
            int currentIndxEnd = indexS.Pop();
            int currentIndxStart = indexS.Count == 0 ? 0 : indexS.Peek();
            maxArea = Math.Max(maxArea, currentVal * (currentIndxEnd - currentIndxStart));
            return maxArea;
        }

        static int PopAndComputeArea(int val, Stack<int> heightS, Stack<int> indexS)
        {
            int currMaxArea = 0;
            while (heightS.Count > 0 && indexS.Count > 0 && val < heightS.Peek())
            {
                int prevVal = heightS.Peek();
                int prevIndx = indexS.Peek();
                currMaxArea = ComputeArea(currMaxArea, heightS, indexS);

                // Handle the case where the next height is less than previously popped height but greater than current value
                // Eg. 2 3 1 ---> 2 spreads across 2 and 3 and the area is 4 and hence 2 index needs update
                //     1 5 3 ---> 1 index does not need an update as it will not be popped
                if (heightS.Count > 0 && indexS.Count > 0 && prevVal > heightS.Peek() && val < heightS.Peek())
                {
                    // Update indexS with eh current end index
                    indexS.Pop();
                    indexS.Push(prevIndx);
                }
            }

            return currMaxArea;
        }
    }
}
