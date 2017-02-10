using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayToSort = new int[] { 1000, 99, 120, 1, 2 };
            int inversions = CountInversions(arrayToSort);
            Console.WriteLine("Number of inversions : {0}", inversions);

            Console.ReadLine();
        }

        public static int CountInversions(int[] inArr)
        {
            if (inArr.Length == 0 || inArr.Length == 1)
            {
                return 0;
            }

            int mid = inArr.Length / 2;
            int[] firstArray = new int[mid];
            int[] secondArray = new int[inArr.Length - mid];
            Array.Copy(inArr, 0, firstArray, 0, mid);
            Array.Copy(inArr, mid, secondArray, 0, inArr.Length - mid);
            int x = CountInversions(firstArray);
            int y = CountInversions(secondArray);
            int z = MergeAndCountInversion(firstArray, secondArray, inArr);

            // Total inversions
            return x + y + z;
        }

        internal static int MergeAndCountInversion(int[] array1, int[] array2, int[] mergedArray)
        {
            int x = 0, i = 0, j = 0;
            int inversions = 0;
            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] < array2[j])
                {
                    mergedArray[x++] = array1[i++];
                }
                else
                {
                    mergedArray[x++] = array2[j++];

                    // All elements after the current element are inverted since both arrays are sorted
                    inversions += array1.Length - i;
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

            return inversions;
        }
    }
}
