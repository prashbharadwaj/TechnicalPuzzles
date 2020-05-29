using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubstringWithoutRepeatingCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "abccdefgh";
            string ls = LongestSubstringWithoutRepeatingCharacters(s);
            Console.WriteLine("Longest substring without non repeating characters is {0}", ls);
            Console.Read();

        }

        static string LongestSubstringWithoutRepeatingCharacters(string s)
        {
            char[] chArr = s.ToCharArray();
            HashSet<char> charSet = new HashSet<char>();
            int startIndx = 0;
            int endIndx = 0;
            int maxStartIndex = 0;
            int maxEndIndex = 0;
            charSet.Add(chArr[0]);

            for (int i = 1; i < chArr.Length; i++)
            {
                if (charSet.Contains(chArr[i]))
                {
                    // Means a repeating character
                    // Reset window and get max
                    if ((endIndx - startIndx + 1) > (maxEndIndex - maxStartIndex + 1))
                    {
                        maxEndIndex = endIndx;
                        maxStartIndex = startIndx;
                    }

                    char currChar = chArr[i];
                    charSet.Clear();
                    charSet.Add(currChar);
                    startIndx = i;
                }
                else
                {
                    charSet.Add(chArr[i]);
                }

                endIndx++;
            }

            if ((endIndx - startIndx + 1) > (maxEndIndex - maxStartIndex + 1))
            {
                maxEndIndex = endIndx;
                maxStartIndex = startIndx;
            }

            return GetSubstringFromArray(chArr, maxStartIndex, maxEndIndex);
        }

        public static string GetSubstringFromArray(char[] chArr, int start, int end)
        {
            char[] subStringArr = new char[end - start + 1];
            int resultIndx = 0;
            for (int i = start; i <= end; i++)
            {
                subStringArr[resultIndx++] = chArr[i];
            }

            return new string(subStringArr);
        }
    }
}
