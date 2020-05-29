// Inplace merge two sorted arrays

// Given two sorted arrays X[] and Y[] of size m and n each, merge elements of X[] with elements of array Y[] by maintaining
// the sorted order.i.e.fill X[] with first m smallest elements and fill Y[] with remaining elements.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeArraysInPlace
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void Merge(int[] X, int[] Y, int xSize, int ySize)
        {
            int i = 0;
            while (i < xSize)
            {
                if (X[i] < Y[0])
                {
                    Swap(X, Y, i, 0);
                    int first = Y[0];

                    // Move this value to the correct location in the second array
                    int j;
                    for (j = 1; Y[j] < first && j < ySize; j++)
                    {
                        Y[j - 1] = Y[j];
                    }

                    // last location that was swapped before we broke from the condition Y[j] < first or it could be the last element in the array
                    Y[j - 1] = first;
                }

                i++;
            }
        }

        static void Swap(int[] A, int[] B, int iA, int iB)
        {
            int temp = B[iB];
            B[iB] = A[iA];
            A[iA] = B[iB];
        }
    }
}