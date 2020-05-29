using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringWithKUniqueCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "aabbccdd";
            int k = 1;
            var res = LongestUniqueSubstring(str, k);
            Console.WriteLine("Longest unique substring with {0} character(s) is {1}", k, res);
            Console.ReadKey();
        }

        static string LongestUniqueSubstring(string s, int k)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            HashSet<char> map = new HashSet<char>();

            char[] chArr = s.ToCharArray();
            
            // Go over the character array and figure out how many unique characters are present
            foreach (char c in chArr)
            {
                if (!map.Contains(c))
                    map.Add(c);
            }

            if (map.Count < k)
            {
                throw new Exception(string.Format("Unique characters less than {0}", k));
            }

            // Clear the hashset
            map.Clear();
            int startIndx = 0;
            int endIndx = 0;
            int uniqueCount = 1;
            int maxStartIndx = 0;
            int maxEndIndx = 0;

            // Add the first element to the hashset
            map.Add(chArr[0]);

            for (int indx = 1; indx < chArr.Length; indx++)
            {
                char ch = chArr[indx];
                if (!map.Contains(ch))
                {
                    map.Add(ch);
                    uniqueCount++;
                    if (uniqueCount > k)
                    {
                        if (endIndx - startIndx + 1 > maxEndIndx - maxStartIndx + 1)
                        {
                            // Update
                            maxStartIndx = startIndx;
                            maxEndIndx = endIndx;
                        }

                        // Go past the previous unique character
                        char uChar = chArr[startIndx];
                        while (startIndx < chArr.Length)
                        {
                            if (chArr[startIndx] != uChar)
                            {
                                map.Remove(uChar);
                                uniqueCount--;
                                break;
                            }
                                
                            startIndx += 1;                            
                        }
                    }
                }

                endIndx++;
            }

            return GetSubstring(chArr, maxStartIndx, maxEndIndx);
        }

        static string GetSubstring(char[] chArr, int start, int end)
        {
            char[] resultArr = new char[end - start + 1];
            int resultIndx = 0;
            for (int indx = start; indx <= end && resultIndx < resultArr.Length; indx++)
            {
                resultArr[resultIndx++] = chArr[indx];
            }

            return new string(resultArr);
        }
    }
}
