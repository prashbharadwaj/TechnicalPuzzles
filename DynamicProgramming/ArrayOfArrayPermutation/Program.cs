using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfArrayPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> arrays = new List<int[]>();
            arrays.Add(new int[] { 1, 2, 3 });
            arrays.Add(new int[] { 4 });
            arrays.Add(new int[] { 5, 6 });
            PrintResult(arrays);

            var result = PermuteArrayOfArrays(arrays);
            PrintResult(result);
            Console.ReadKey();
        }

        static void PrintResult(List<int[]> arr)
        {
            Console.Write("{");
            foreach (var subArr in arr)
            {
                Console.Write("[");
                foreach (var item in subArr)
                {
                    Console.Write("{0},", item);
                }
                Console.Write("]");
            }
            Console.Write("}");

            Console.WriteLine();
        }

        static List<int[]> PermuteArrayOfArrays(List<int[]> arrays)
        {
            return PermuteHelper(arrays, 0);
        }

        static List<int[]> PermuteHelper(List<int[]> arrays, int len)
        {
            if (len == arrays.Count)
            {
                return new List<int[]>();
            }

            var res_arr = PermuteHelper(arrays, len + 1);
            var currArr = arrays[len];

            List<int[]> result = new List<int[]>();
            foreach (var item in currArr)
            {
                if (res_arr.Count == 0)
                {
                    int[] partialResult = new int[1];
                    partialResult[0] = item;
                    result.Add(partialResult);
                }
                else
                {
                    foreach (var res in res_arr)
                    {
                        int[] partialResult = new int[res.Length + 1];
                        partialResult[0] = item;
                        Array.Copy(res, 0, partialResult, 1, res.Length);
                        result.Add(partialResult);
                    }
                }
            }

            return result;
        }
    }
}
