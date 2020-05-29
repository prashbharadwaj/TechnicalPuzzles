using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var soln = new Solution();
            IList<string> list = soln.LetterCombinations("4258026165");
            Console.ReadKey();
        }
    }

    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrEmpty(digits))
            {
                return new List<string>();
            }
            char[] digitArray = digits.ToCharArray();
            StringBuilder sb = new StringBuilder(digits.Length);
            IList<string> result = new List<string>();
            GetTelephoneWords(digitArray, 0, sb, result);
            return result;
        }

        static Dictionary<char, char[]> phoneNumberMapping = new Dictionary<char, char[]> { {'2', new char[]{'a', 'b', 'c'}},
                                                                                      {'3', new char[]{'d', 'e', 'f'}},
                                                                                      {'4', new char[]{'g', 'h', 'i'}},
                                                                                      {'5', new char[]{'j', 'k', 'l'}},
                                                                                      {'6', new char[]{'m', 'n', 'o'}},
                                                                                      {'7', new char[]{'p', 'q', 'r', 's'}},
                                                                                      {'8', new char[]{'t', 'u', 'v'}},
                                                                                      {'9', new char[]{'w', 'x', 'y', 'z'}}
                                                                                    };

        public void GetTelephoneWords(char[] digits, int index, StringBuilder outStr, IList<string> output)
        {
            if (index == digits.Length)
            {
                output.Add(outStr.ToString());
                return;
            }

            int loopCnt = GetLetterCount(digits[index]);
            for (int i = 0; i < loopCnt; i++)
            {
                char val = GetLetterForDigit(digits[index], i);
                outStr.Insert(index, val);
                GetTelephoneWords(digits, index + 1, outStr, output);
                outStr.Remove(index, 1);
            }
        }

        public char GetLetterForDigit(char digit, int index)
        {
            if (digit == '0' || digit == '1')
            {
                return digit;
            }

            char[] letterSet = phoneNumberMapping[digit];
            return letterSet[index];
        }

        public int GetLetterCount(char digit)
        {
            if (digit == '0' || digit == '1')
            {
                return 1;
            }

            return phoneNumberMapping[digit].Length;
        }
    }
}
