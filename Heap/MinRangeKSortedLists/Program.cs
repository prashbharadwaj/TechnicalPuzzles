using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalPuzzles;

namespace MinRangeKSortedLists
{
    public class MinHeapNode : IComparable
    {
        public int Element { get; set; }

        public int ListIndex { get; set; }

        public int NextElementIndex { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            MinHeapNode otherNode = obj as MinHeapNode;
            if (otherNode == null)
                return 1;

            if (otherNode.Element > this.Element)
                return -1;
            else if (otherNode.Element == this.Element)
                return 0;
            else
                return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        static int GetMinRange(int[][] sortedArrays, int k)
        {
            int minRange = Int32.MaxValue;
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            PriorityQueueMin<MinHeapNode> pq = new PriorityQueueMin<MinHeapNode>(k);

            // Add value at index 0 for all the 'k' sorted arrays
            for (int i = 0; i < k; i++)
            {
                MinHeapNode node = 
                    new MinHeapNode
                    {
                        Element = sortedArrays[i][0],
                        ListIndex = i,
                        NextElementIndex = 1
                    };

                pq.Insert(node);
                max = Math.Max(max, node.Element);
            }

            while (!pq.IsEmpty())
            {
                // Get minimum and update min range
                MinHeapNode currVal = pq.RemoveMin();
                min = currVal.Element;
                int currMinRange = max - min + 1;
                if (currMinRange < minRange)
                {
                    minRange = currMinRange;
                }

                // Check if next element index is within bounds
                if (currVal.NextElementIndex < sortedArrays[currVal.ListIndex].Length)
                {
                    int elem = sortedArrays[currVal.ListIndex][currVal.NextElementIndex];

                    // Update current node value and add it back into priority queue
                    currVal.Element = elem;
                    currVal.NextElementIndex += 1;
                    pq.Insert(currVal);

                    // Update max if required
                    max = Math.Max(max, elem);
                }
            }

            return minRange;
        }
    }
}
