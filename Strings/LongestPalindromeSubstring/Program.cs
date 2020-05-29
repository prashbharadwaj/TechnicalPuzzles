using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindromeSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "babad";
            string longestPalindrome = new Solution().LongestPalindrome(input);
            Console.WriteLine("Longest palindrome substring of {0} is {1}", input, longestPalindrome);
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            PalResult result = null;
            int currentLength;
            int maxLength = -1;
            char[] chArray = s.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                // Odd
                var currResult = Expand(chArray, i, i);
                currentLength = currResult.End - currResult.Start + 1;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    result = currResult;
                }

                // For even
                currResult = Expand(chArray, i, i + 1);
                currentLength = currResult.End - currResult.Start + 1;
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    result = currResult;
                }
            }

            // return the longest palindrome substring
            return s.Substring(result.Start, maxLength);
        }

        public static PalResult Expand(char[] s, int low, int high)
        {
            while (low >= 0 && high < s.Length && s[low] == s[high])
            {
                low--;
                high++;
            }

            return new PalResult { Start = low + 1, End = high - 1 };
        }

        public class PalResult
        {
            public int Start { get; set; }
            public int End { get; set; }
        }
    }
}
