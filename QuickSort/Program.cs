using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // todo : double check with pg. 187 in EPI
        // Dutch national flag partition - where equal elements are clustered in the middle
        // Gives a better partitioning for Quick sort to handle arrays that have a lot of equal elements
        static Tuple<int, int> DutchPartition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int mid = start;

            for (int i = 0; i < end; i++)
            {
                if (arr[i] > pivot)
                {
                    swap(arr, i, --end);
                }
                else if (arr[i] < pivot)
                {
                    swap(arr, i, start++);
                    mid++;
                }
                else
                {
                    mid++;
                }
            }

            return new Tuple<int, int>(start - 1, mid);
        }

        // Using Lomuto partitioning scheme
        // Handles moving pivot to its place. <= elements are before pivot
        // > elements are after pivot
        static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];
            int startIndex = start;

            for (int i = start; i < end; i++)
            {
                if (arr[i] <= pivot)
                {
                    swap(arr, startIndex++, i);
                }
            }

            swap(arr, startIndex, end);

            return startIndex;
        }

        static void swap(int[] arr, int firstIndex, int secondIndex)
        {
            int tmp = arr[firstIndex];
            arr[firstIndex] = arr[secondIndex];
            arr[secondIndex] = tmp;
        }
    }
}
