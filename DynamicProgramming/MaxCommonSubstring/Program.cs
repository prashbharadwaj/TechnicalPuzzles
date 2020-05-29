using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxCommonSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string strA = "abcxyz";
            string strB = "efgcxyzhijabc";

            int mcs = MaxCommonSubstring(strA.ToCharArray(), strB.ToCharArray(), strA.Length, strB.Length);
            Console.WriteLine("Max common substring is of length {0}", mcs);
            Console.Read();
        }

        static int MaxCommonSubstring(char[] chA, char[] chB, int m, int n)
        {
            int maxCommonSubstring = 0;
            int[,] stringMap = new int[m + 1, n + 1];
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        stringMap[i, j] = 0;
                    }
                    else if (chA[i - 1] == chB[j - 1])
                    {
                        stringMap[i, j] = 1 + stringMap[i - 1, j - 1];
                        maxCommonSubstring = Math.Max(maxCommonSubstring, stringMap[i, j]);
                    }
                    else
                    {
                        stringMap[i, j] = 0;
                    }
                }
            }

            return maxCommonSubstring;
        }
    }
}
