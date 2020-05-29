using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianOfTwoSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 1, 5, 8, 9 };
            int[] array2 = new int[] { 2, 11, 13, 21 };
            decimal median = GetMedian(array1, array2);
            Console.WriteLine("Median is : {0}", median);
            Console.Read();
        }

        // TODO: Add description - Listen to YouTube video by Tushar Roy
        // Below is working except that the average is not returning a decimal -- need to debug
        static decimal GetMedian(int[] array1, int[] array2)
        {
            if (array2.Length < array1.Length)
                return GetMedian(array2, array1);

            int high1 = array1.Length;
            int high2 = array2.Length;

            int low1 = 0;

            while (low1 < high1)
            {
                int partitionX = (low1 + high1) / 2;
                int partitionY = (high1 + high2 + 1) / 2 - partitionX;

                int leftMaxX = (partitionX == 0) ? Int32.MinValue : array1[partitionX - 1];
                int rightMinX = (partitionX == high1) ? Int32.MaxValue : array1[partitionX];

                int leftMaxY = (partitionY == 0) ? Int32.MinValue : array2[partitionY - 1];
                int rightMinY = (partitionY == high2) ? Int32.MaxValue : array2[partitionY];

                if (leftMaxX <= rightMinY && leftMaxY <= rightMinX)
                {
                    // Both arrays are appropriately partitioned
                    int maxLeft = Math.Max(leftMaxX, leftMaxY);
                    if ((high1 + high2) % 2 == 0)
                    {
                        int minRight = Math.Min(rightMinX, rightMinY);

                        // return average of left and right
                        decimal median = (maxLeft + minRight) / 2;
                        return median;
                    }
                    else
                    {
                        return maxLeft;
                    }
                }
                else if (leftMaxX > rightMinY)
                {
                    high1 = partitionX - 1;
                }
                else
                {
                    low1 = partitionX + 1;
                }
            }

            throw new ArgumentException("Arrays are not sorted");
        }
    }
}
