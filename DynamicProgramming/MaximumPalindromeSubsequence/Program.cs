using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromeSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "GEEKSFORGEEKS";
            int maxPal = LPS(s, true);
            Console.WriteLine("Longest Palindrome subsequence length is {0}", maxPal);
            Console.Read();
        }

        static int LPS(string s, bool debug = false)
        {
            int n = s.Length;

            // Bottom up map for dynamic programming
            // One dimension is distance from left and another is distance from right
            int[,] map = new int[n, n];

            // Initialize the map to set values having length one. 
            // A single element string is a palindrome of length 1
            for (int i = 0; i < n; i++)
            {
                map[i, i] = 1;
            }

            char[] chArr = s.ToCharArray();

            // start from a string containing a minimum of 2 elements
            for (int cl = 2; cl <= n; cl++)
            {
                for (int i = 0; i < n - cl + 1; i++)
                {
                    int j = i + cl - 1;

                    if (chArr[i] == chArr[j])
                    {
                        if (cl == 2)
                        {
                            map[i, j] = 2;
                        }
                        else
                        {
                            map[i, j] = 2 + map[i + 1, j - 1];
                        }
                    }
                    else
                    {
                        map[i, j] = Math.Max(map[i + 1, j], map[i, j - 1]);
                    }

                    if (debug)
                    {
                        string fmt = string.Format("i -> {0}, val[i] -> {1}, j -> {2}, val[j] -> {3}", i, chArr[i], j, chArr[j]);
                        Console.Write("{0}, Matrix ->", fmt);
                        DisplayMatrix(map);
                    }
                }
            }

            if (debug)
            {
                Console.WriteLine("Final matrix is: ");
                DisplayMatrix(map);
            }

            return map[0, n - 1];
        }

        static void DisplayMatrix(int[,] mat)
        {
            Console.WriteLine();
            Console.WriteLine("[");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write("{0},", mat[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine("]");
            Console.WriteLine();
        }
    }
}
