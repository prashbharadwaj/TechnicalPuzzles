using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void SolveSudoku(int[,] arr)
        {

        }

        static bool SolveSudokuHelper(int[,] arr, int i, int j)
        {
            if (i >= arr.GetLength(0))
            {
                i = 0;
                if (++j >= arr.GetLength(1))
                {
                    return true;
                }
            }

            if (arr[i, j] != 0)
            {
                return SolveSudokuHelper(arr, i + 1, j);
            }

            for (int x = 0; x < arr.GetLength(0); x++)
            {
                if (!IsValidValue(arr, i, j, x))
                {
                    i += 1;
                    continue;
                }

                arr[i, j] = x;
                return SolveSudokuHelper(arr, i + 1, j + 1);
            }

            arr[i, j] = 0;
            return false;
        }

        public static bool IsValidValue(int[,] arr, int i, int j, int val)
        {
            for (int x = 0; x < arr.GetLength(0); x++)
            {
                if (arr[i, x] == val)
                {
                    return false;
                }
            }

            for (int x = 0; x < arr.GetLength(0); x++)
            {
                if (arr[x, j] == val)
                {
                    return false;
                }
            }

            int regionSize = (int)Math.Sqrt(arr.GetLength(0));
            int I = i / regionSize;
            int J = j / regionSize;

            for (int a = 0; a < regionSize; a++)
            {
                for (int b = 0; b < regionSize; j++)
                {
                    if (val == arr[regionSize * I + a, regionSize * J + b])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
