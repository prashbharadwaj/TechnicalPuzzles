using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> mat = new List<List<int>>() { new List<int>() { 1, 2 } };
            var result = new Solution().spiralOrder(mat);
            Console.ReadKey();
        }
    }
    
    class Solution
    {
        public List<int> spiralOrder(List<List<int>> A)
        {
            if (A == null && A.Count == 0)
                return null;

            int rows = A.Count();
            int cols = A[0].Count();
            int minR = 0;
            int maxR = rows;
            int minC = 0;
            int maxC = cols;
            List<int> result = new List<int>(rows * cols);

            while (minC < maxC && minR < maxR)
            {
                // Move forward                
                for (int i = minC; i < maxC; i++)
                {
                    result.Add(A[minR][i]);
                }
                minR++;

                // Move down
                for (int j = minR; j < maxR; j++)
                {
                    result.Add(A[j][maxC - 1]);
                }
                maxC--;

                if (minR < maxR)
                {
                    // Move left
                    for (int i = maxC - 1; i >= minC; i--)
                    {
                        result.Add(A[maxR - 1][i]);
                    }

                    maxR--;
                }

                if (minC < maxC)
                {
                    // Move up
                    for (int j = maxR - 1; j >= minR; j--)
                    {
                        result.Add(A[j][minC]);
                    }

                    minC++;
                }
            }

            return result;
        }
    }
}
