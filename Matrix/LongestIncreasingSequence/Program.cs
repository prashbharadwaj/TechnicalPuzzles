using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat = new int[,] { { 9, 9, 4 }, { 6, 6, 8 }, { 2, 1, 1 } };
            int result = LongestIncreasingPath(mat);
            Console.ReadKey();
        }

        static public int LongestIncreasingPath(int[,] matrix)
        {
            int M = matrix.GetLength(0);
            int N = matrix.GetLength(1);
            int longestPath = Int32.MinValue;
            List<int> longestList;
            List<int>[,] memo = new List<int>[M, N];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    List<int> longIncreasingPath = GetLongPath(matrix, i, j, memo);
                    if (longIncreasingPath != null && longIncreasingPath.Count > longestPath)
                    {
                        longestPath = longIncreasingPath.Count;
                        longestList = longIncreasingPath;
                    }
                }
            }

            return longestPath == Int32.MinValue ? 0 : longestPath;
        }

        public static bool IsValid(int lenX, int lenY, int i, int j)
        {
            return i >= 0 && i < lenX && j >= 0 && j < lenY;
        }

        public static List<int> GetLongerList(List<int> list1, List<int> list2)
        {
            if (list1 == null && list2 == null)
            {
                return null;
            }

            if (list1 == null || list2 == null)
            {
                return list1 != null ? list1 : list2;
            }

            List<int> longerList = list1;
            if (list2.Count > longerList.Count)
            {
                longerList = list2;
            }

            return longerList;
        }

        public static List<int> GetLongPath(int[,] matrix, int i, int j, List<int>[,] memo)
        {
            if (!IsValid(matrix.GetLength(0), matrix.GetLength(1), i, j))
            {
                return null;
            }

            // If path exists in cache, use it
            if (memo[i, j] != null)
            {
                return memo[i, j];
            }

            List<int> longPathList = null;
            List<int> longPathListTmp = null;
            // Top
            if (i > 0 && matrix[i - 1, j] > matrix[i, j])
            {
                longPathList = GetLongPath(matrix, i - 1, j, memo);
            }

            // Right
            if (j + 1 < matrix.GetLength(1) && matrix[i, j + 1] > matrix[i, j])
            {
                longPathListTmp = GetLongPath(matrix, i, j + 1, memo);
            }

            longPathList = GetLongerList(longPathList, longPathListTmp);

            // Bottom
            if (i + 1 < matrix.GetLength(0) && matrix[i + 1, j] > matrix[i, j])
            {
                longPathListTmp = GetLongPath(matrix, i + 1, j, memo);
            }

            longPathList = GetLongerList(longPathList, longPathListTmp);

            // Left
            if (j > 0 && matrix[i, j - 1] > matrix[i, j])
            {
                longPathListTmp = GetLongPath(matrix, i, j - 1, memo);
            }

            longPathList = GetLongerList(longPathList, longPathListTmp);
            if (longPathList == null)
            {
                longPathList = new List<int>();
                longPathList.Add(matrix[i, j]);
            }
            else
            {
                longPathList = longPathList.Select(v => v).ToList();
                longPathList.Insert(0, matrix[i, j]);
            }

            // Set the path in the memo cache
            memo[i, j] = longPathList;
            return longPathList;
        }
}
}
