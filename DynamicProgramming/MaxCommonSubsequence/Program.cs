using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxCommonSubsequence
{
    // Given two arrays, find the maximum common subsequence between them
    // Subsequence need not be contiguous
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[] { 1, 2, 3, 4, 5};
            int[] B = new int[] { 1, 7, 11, 3, 15, 4, 8, 9, 5 };
            int mcs = MaxCommonSubsequence(A, B, A.Length, B.Length);
            Console.WriteLine("Max common subsequence is {0}", mcs);

            int mcsBottomUp = MCSBottomUp(A, B, A.Length, B.Length);
            Console.WriteLine("Max common subsequence through bottom up is {0}", mcsBottomUp);

            // Longest Common Substring (LCS) is slightly different
            // The length is reset the moment a pattern match stops
            string string1 = "OldSite:MySiteOld.org";
            string string2 = "NewSite:MySiteNew.org";
            int lcsLength = LCSBottomup(string1, string2);
            Console.WriteLine("Longest Common Substring through bottom up is {0}", lcsLength);

            Console.Read();
        }

        // Optimal substructure
        /*
            if input sequences are A[0 ... m-1] and B[0 ... n-1], 
            then if LCS of these two sequences is defined as L(A[0..m-1], B[0..n-1]) and is given by:

               L(A[0..m-1], B[0..n-1]) = 1 + L(A[0..m-2], B[0..n-2]) when A[m-1] == B[n-1]
            else
               Max(L(A[0..m-1], B[0..n-2]), L(A[0..m-2], B[0..n-1]))
        */
        static int MaxCommonSubsequence(int[] A, int[] B, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;

            int ret = 0;
            if (A[m-1] == B[n-1])
            {
                ret = 1 + MaxCommonSubsequence(A, B, m - 1, n - 1);
            }
            else
            {
                int ret1 = MaxCommonSubsequence(A, B, m, n - 1);
                int ret2 = MaxCommonSubsequence(A, B, m - 1, n);
                ret = Math.Max(ret1, ret2);
            }

            return ret;
        }

        // Bottom up
        static int MCSBottomUp(int[] A, int[] B, int m, int n)
        {
            int[,] map = new int[m+1, n+1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        map[i, j] = 0;
                    }
                    else if (A[i-1] == B[j-1])
                    {
                        map[i, j] = 1 + map[i - 1, j - 1];
                    }
                    else
                    {
                        map[i, j] = Math.Max(map[i, j - 1], map[i - 1, j]);
                    }
                }
            }

            return map[m, n];
        }

        /*
         * LCSBottom up
         */
        static int LCSBottomup(string firstString, string secondString)
        {
            int[,] lcsMap = new int[firstString.Length + 1, secondString.Length + 1];
            int result = 0;
            char[] firstCharArray = firstString.ToCharArray();
            char[] secondCharArray = secondString.ToCharArray();
            for (int i = 0; i <= firstString.Length; i++)
            {
                for (int j = 0; j <= secondString.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        lcsMap[i, j] = 0;
                    }
                    else if (firstCharArray[i-1] == secondCharArray[j -1])
                    {
                        int len = 1 + lcsMap[i - 1, j - 1];
                        lcsMap[i, j] = len;
                        result = Math.Max(result, len);
                    }
                    else
                    {
                        lcsMap[i, j] = 0;
                    }
                }
            }

            return result;
        }
    }
}
