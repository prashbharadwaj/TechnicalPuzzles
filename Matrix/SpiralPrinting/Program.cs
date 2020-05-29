using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] inMatrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }};
            var list = SpiralOrder(inMatrix);
            Console.ReadKey();
        }

        public static IList<int> SpiralOrder(int[,] matrix)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);
            if (M == 0 && N == 0)
            {
                return new List<int>();
            }

            int left = 0;
            int right = N - 1;
            int top = 0;
            int bottom = M - 1;
            IList<int> result = new List<int>();
            while (true)
            {
                if (left > right)
                {
                    break;
                }

                int i = 0;

                // top
                for (i = left; i <= right; i++)
                {
                    result.Add(matrix[top, i]);
                }
                top++;

                if (top > bottom)
                {
                    break;
                }

                // right
                for (i = top; i <= bottom; i++)
                {
                    result.Add(matrix[i, right]);
                }
                right--;

                if (left > right)
                {
                    break;
                }

                // bottom
                for (i = right; i >= left; i--)
                {
                    result.Add(matrix[bottom, i]);
                }
                bottom--;

                if (top > bottom)
                {
                    break;
                }

                // left
                for (i = bottom; i >= top; i--)
                {
                    result.Add(matrix[i, left]);
                }
                left++;
            }

            return result;
        }
    }
}
