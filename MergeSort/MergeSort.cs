using System;
using System.Diagnostics;

namespace DivideAndConquer
{
    class MergeSort
    {
        static void Main(string[] args)
        {
            int[] arrayToSort = new int[] { 1000, 99, 120, 1, 2 };
            Console.WriteLine("Trying to sort array:");
            PrintArray(arrayToSort);
            Console.WriteLine();
            Sort(arrayToSort);
            Console.WriteLine("After merge sort");
            PrintArray(arrayToSort);
            Console.WriteLine();

            // Sort a million items
            Random rand = new Random(1387);
            Console.WriteLine("Creating a big array of 1000000 items");
            int[] bigArray = new int[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                bigArray[i] = rand.Next(1000000);
            }

            Console.WriteLine("Sorting big array");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Sort(bigArray);
            sw.Stop();

            Console.WriteLine("Sorting big array took {0} milliseconds", sw.Elapsed.Milliseconds);
            PrintFirstAndLastPartArray(bigArray, 100, 999900);

            // Iterative merge sort
            arrayToSort = new int[] { 1000, 99, 120, 1, 2 };
            PrintArray(arrayToSort);
            int[] temp = new int[arrayToSort.Length];
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                temp[i] = arrayToSort[i];
            }

            SortIterative(arrayToSort, temp, 0, arrayToSort.Length - 1);
            Console.WriteLine("Completed iterative merge sort");
            PrintArray(arrayToSort);
            Console.ReadLine();
        }

        internal static void PrintFirstAndLastPartArray(int[] arr, int firstMax, int lastMin)
        {
            for (int indx = 0; indx < firstMax; indx++)
            {
                Console.Write(arr[indx]);
                if (indx != firstMax - 1)
                {
                    Console.Write(",");
                }
            }

            for (int indx = lastMin; indx < 1000000; indx++)
            {
                Console.Write(arr[indx]);
                if (indx != 1000000 - 1)
                {
                    Console.Write(",");
                }
            }
        }

        internal static void PrintArray(int[] arr)
        {
            for (int indx = 0; indx < arr.Length; indx++)
            {
                Console.Write(arr[indx]);
                if (indx != arr.Length - 1)
                {
                    Console.Write(",");
                }
            }
        }

        public static void Sort(int[] inArr)
        {
            if (inArr.Length == 0 || inArr.Length == 1)
            {
                return;
            }

            int mid = inArr.Length / 2;
            int[] firstArray = new int[mid];
            int[] secondArray = new int[inArr.Length - mid];
            Array.Copy(inArr, 0, firstArray, 0, mid);
            Array.Copy(inArr, mid, secondArray, 0, inArr.Length - mid);
            Sort(firstArray);
            Sort(secondArray);
            MergeSortedArrays(firstArray, secondArray, inArr);
        }

        internal static void MergeSortedArrays(int[] array1, int[] array2, int[] mergedArray)
        {
            int x = 0, i = 0, j = 0;
            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] < array2[j])
                {
                    mergedArray[x++] = array1[i++];
                }
                else
                {
                    mergedArray[x++] = array2[j++];
                }
            }

            while (i < array1.Length)
            {
                mergedArray[x++] = array1[i++];
            }

            while (j < array2.Length)
            {
                mergedArray[x++] = array2[j++];
            }
        }

        internal static void MergeIterative(int[] array, int[] temp, int from, int mid, int to)
        {
            int x = from;
            int i = from;
            int j = mid + 1;

            while ( i <= mid && j <= to)
            {
                if (array[i] < array[j])
                {
                    temp[x++] = array[i++];
                }
                else
                {
                    temp[x++] = array[j++];
                }
            }

            // Remaining elements in the lower half
            while (i <= mid)
            {
                temp[x++] = array[i++];
            }

            // No need to copy the other as it is already in place

            // Copy temp to array
            for (i = from; i <= to; i++)
            {
                array[i] = temp[i];
            }
        }

        internal static void SortIterative(int[] array, int[] temp, int low, int high)
        {
            for (int m = 1; m < high - low; m *= 2)
            {
                for (int i = low; i < high; i += 2 * m)
                {
                    int from = i;
                    int mid = i + m - 1;
                    int to = Math.Min(i + 2 * m - 1, high);

                    MergeIterative(array, temp, from, mid, to);
                }
            }
        }
    }
}
