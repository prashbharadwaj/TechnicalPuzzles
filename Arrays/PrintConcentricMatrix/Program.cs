using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintConcentricMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] result = GenerateConcentricMatrix(10);
            PrintMatrix(result);

            //  Using List<list<int>>
            List<List<int>> result2 = prettyPrint(4);

            Console.ReadKey();
        }

        static void PrintMatrix(int[,] mat)
        {
            Console.WriteLine("[");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write("{0},", mat[i, j]);
                }

                Console.WriteLine("");
            }

            Console.WriteLine("]");
        }

        static List<List<int>> prettyPrint(int A)
        {
            // Calculate number of rows/columns
            int M = A * 2 - 1;
            int rmin = 0;
            int rmax = M;
            int cmin = 0;
            int cmax = M;
            int i = 0;
            List<List<int>> resultMatrix = new List<List<int>>();
            for (int indx = 0; indx < M; indx++)
            {
                resultMatrix.Add(new List<int>(M));
                for (int j = 0; j < M; j++)
                {
                    resultMatrix[indx].Add(0);
                }
            }

            while (rmin < rmax || cmin < cmax || A > 0)
            {
                // row forward
                for (i = cmin; i < cmax; i++)
                {
                    resultMatrix[rmin][i] = A;
                }

                rmin++;

                // col down
                for (i = rmin; i < rmax; i++)
                {
                    resultMatrix[i][cmax-1] = A;
                }

                cmax--;

                if (cmin < cmax)
                {
                    // row backwards
                    for (i = cmax - 1; i >= cmin; i--)
                    {
                        resultMatrix[rmax - 1][i] = A;
                    }

                    rmax--;
                }

                if (rmin < rmax)
                {
                    // col upwards
                    for (i = rmax - 1; i >= rmin; i--)
                    {
                        resultMatrix[i][cmin] = A;
                    }

                    cmin++;
                }

                A--;
            }

            return resultMatrix;
        }

        static int[,] GenerateConcentricMatrix(int numConcentric)
        {
            // Calculate number of rows/columns
            int M = numConcentric * 2 - 1;
            int rmin = 0;
            int rmax = M;
            int cmin = 0;
            int cmax = M;
            int i = 0;
            int[,] resultMatrix = new int[M, M];
            while (rmin < rmax || cmin < cmax || numConcentric > 0)
            {
                // row forward
                for (i = cmin; i < cmax; i++)
                {
                    resultMatrix[rmin, i] = numConcentric;
                }

                rmin++;

                // col down
                for (i = rmin; i < rmax; i++)
                {
                    resultMatrix[i, cmax - 1] = numConcentric;
                }

                cmax--;

                if (cmin < cmax)
                {
                    // row backwards
                    for (i = cmax -1; i >= cmin; i--)
                    {
                        resultMatrix[rmax - 1, i] = numConcentric;
                    }

                    rmax--;
                }

                if (rmin < rmax)
                {
                    // col upwards
                    for (i = rmax-1; i >= rmin; i--)
                    {
                        resultMatrix[i, cmin] = numConcentric;
                    }

                    cmin++;
                }

                numConcentric--;
            }

            return resultMatrix;
        }
    }
}
