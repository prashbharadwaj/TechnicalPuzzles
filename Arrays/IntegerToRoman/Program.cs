using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToRoman
{
    class Program
    {
        static int[] divArray = { 1000, 500, 100, 50, 10, 5, 1 };
        static Dictionary<int, int> divRangeMap =
            new Dictionary<int, int>
            {
                {1000, 100 },
                {500, 100 },
                {100, 10 },
                {50, 10 },
                {10, 1 },
                {5, 1 },
                {1, 0 }
            };
        static Dictionary<int, char> romanSymbolMap =
            new Dictionary<int, char>
            {
                { 1, 'I' },
                { 5, 'V' },
                { 10, 'X' },
                { 50, 'L' },
                { 100, 'C' },
                { 500, 'D' },
                { 1000, 'M' }
            };

        static void Main(string[] args)
        {
            int input = 88;
            string romanNumber = IntegerToRoman(input);
            Console.WriteLine("Roman number for input {0} is {1}", input, romanNumber);
            Console.Read();
        }

        /*
           Accepted solution on Leetcode. Fastest solution in the solutions submitted so far 
        */
        static string IntegerToRoman(int input)
        {
            if (input < 0)
                return string.Empty;

            StringBuilder resultSb = new StringBuilder();
            int divIndex = 0;
            int rem = input;

            while (rem > 0)
            {
                int divVal = divArray[divIndex];
                int range = divRangeMap[divVal];

                // If the value is within a known symbol and range
                if (rem < divVal && rem >= divVal - range)
                {
                    resultSb.Append(romanSymbolMap[range]);
                    resultSb.Append(romanSymbolMap[divVal]);
                    // Update divVal
                    divVal = divVal - range;
                    divIndex++;
                }
                else if (rem < divVal)
                {
                    // If the value is lesser than divVal and out of the range for this particular index
                    // then there is no point in testing for this index with the current divVal. It is optimal
                    // to progress further
                    divIndex++;
                }
                else
                {
                    int rValCount = rem / divVal;
                    for (int indx = 0; indx < rValCount; indx++)
                    {
                        resultSb.Append(romanSymbolMap[divVal]);
                    }
                }

                rem = rem % divVal;
            }

            return resultSb.ToString();
        }
    }
}
