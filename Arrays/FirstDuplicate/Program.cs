using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given numbers from range 1 .. N and an array of size N + 1, find the first duplicate
// There can be 1 or more duplicates in this array
namespace FirstDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 8, 4, 6, 2, 6, 4, 7, 9, 5, 8 };
            // int[] arr = { 2, 4, 6, 2, 6, 4, 7, 9, 5, 8 };
            int[] arr = { 3, 2, 1, 3, 4 };
            var pgm = new Program();
            var firstDupe = pgm.firstDuplicate3(arr);
            Console.WriteLine("First duplicate is {0}", firstDupe);
            ReturnArrayToOriginal(arr);
            var dupeByBinSearch = pgm.FindDuplicateUsingBinarySearch(arr);
            Console.WriteLine("First duplicate using binary search is {0}", dupeByBinSearch);
            Console.ReadKey();
        }

        private static void ReturnArrayToOriginal(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = Math.Abs(arr[i]);
                }
            }
        }

        int firstDuplicate(int[] a)
        {
            int i = 0;
            while (i < a.Length)
            {
                if (a[i] == i + 1)
                    i++;
                else if (a[a[i] - 1] != a[i])
                    swap(a, i, a[i] - 1);
                else
                    return a[i];
            }

            return -1;
        }

        void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        int firstDuplicate2(int[] a)
        {
            int i = 0;
            HashSet<int> hs = new HashSet<int>();
            while (i < a.Length)
            {
                if (hs.Contains(a[i]))
                    return a[i];
                else
                    hs.Add(a[i++]);
            }

            return -1;
        }

        /* BEST ANSWER */
        /// <summary>
        /// Logic here is to mark the array with a negative of a value at a given index
        /// This way we preserve the value at that index and also mark that given index as visited
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        int firstDuplicate3(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[Math.Abs(a[i]) - 1] >= 0)
                    a[Math.Abs(a[i]) - 1] = -a[Math.Abs(a[i]) - 1];
                else
                    return Math.Abs(a[i]);
            }
            return -1;
        }

        // In place finding of duplicate with O(nlogn) time and O(1) space
        // Idea is to reduce the range to be searched by half each time and going to the
        // side that will have duplicate
        // We begin with searchable range of ! .. N
        // We divide this 1 .. mid and mid + 1 ... N and figure out which half the duplicate lies
        // We keep dividing this interval in half each time till we get the duplicate
        int FindDuplicateUsingBinarySearch(int[] a)
        {
            // Goal is to halve the range of numbers that we need to search through the array
            // We start with the range 1 ... N
            int low = 1;
            int high = a.Length - 1;

            while (low < high)
            {
                int rangeCount = 0;
                int mid = low + (high - low) / 2;

                // Find elements that lie between 1 .. mid
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] >= low && a[i] <= mid)
                    {
                        rangeCount++;
                    }
                }

                // If rangecount is > expected count in the range of low ... mid then duplicate is in that half
                if (rangeCount > mid - low + 1)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return low;
        }
    }
}
