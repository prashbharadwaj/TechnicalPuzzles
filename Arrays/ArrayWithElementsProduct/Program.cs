
// Given an array of integers, replace each element of the array with product of every other element in the array without using division operator
// For example:
//    Input : {1, 2, 3, 4, 5 }
//    Output: {120, 60, 40, 30, 24 }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayWithElementsProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            FindProduct(arr, arr.Length);
            PrintArray(arr);
            Console.ReadLine();
        }

        static void PrintArray(int [] arr)
        {
            for (int indx = 0; indx < arr.Length; indx++)
            {
                Console.Write("{0}, ", arr[indx]);
            }
        }

        static void FindProduct(int[] arr, int n)
        {
            int[] leftArr = new int[n];

            // Left array should contain product of 0 to i-1 indices
            leftArr[0] = 1;
            for (int i = 1; i < n; i++)
            {
                leftArr[i] = arr[i - 1] * leftArr[i - 1];
            }

            int[] rightArr = new int[n];

            // Right array should contain product of i+1 to n-1 indices
            rightArr[n - 1] = 1;
            for (int j = n-2; j >= 0; j--)
            {
                rightArr[j] = arr[j+1] * rightArr[j + 1];
            }

            // Multiply the two to contain the final expected array
            for (int k = 0; k < n; k++)
            {
                arr[k] = leftArr[k] * rightArr[k];
            }
        }
    }
}
