using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveZerosToEnd
{
    /*
        Modify the array by moving all the zeros to the end (right side). The order of other elements doesn’t matter.
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] src = new int[] { 6, 0, 8, 0, 0};
            // int[] src = new int[] { 1, 2, 0, 3, 0, 1, 2 };
            PrintArray(src);
            // MoveZerosToEnd(src);
            MoveZerosToEnd2(src);
            PrintArray(src);
            Console.Read();
        }

        static void PrintArray(int[] arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(string.Format("{0},", arr[i]));
            }

            Console.Write("]");
        }

        static void MoveZerosToEnd(int[] srcArr)
        {
            int start = 0;
            int end = srcArr.Length - 1;

            while (start < end)
            {
                while (srcArr[end] == 0 && end > start)
                {
                    end--;
                }

                if (srcArr[start] == 0)
                {
                    int tmp = srcArr[end];
                    srcArr[end] = srcArr[start];
                    srcArr[start] = tmp;
                    end--;
                }

                start++;
            }
        }

        static void MoveZerosToEnd2(int[] arr)
        {
            int src = 0;
            int dest = 0;

            do
            {
                if (arr[src] != 0)
                {
                    arr[dest++] = arr[src];
                }
            } while (++src < arr.Length);

            while (dest < src)
            {
                arr[dest++] = 0;
            }
        }
    }
}
