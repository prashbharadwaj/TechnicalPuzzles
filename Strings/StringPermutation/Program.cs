using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] permutationArray = GetStringPermutations("abcd");
            foreach(string str in permutationArray)
            {
                Console.WriteLine(str);
            }

            Console.Read();
        }

        // All permutations of a non-repeating string
        internal static string[] GetStringPermutations(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return new string[] { "" };
            }

            // Get first character string
            string firstCharString = s.Substring(0, 1);

            // Permute the rest of the string characters
            string[] remainingPermutations = GetStringPermutations(s.Substring(1));

            List<string> result = new List<string>();

            // Insert the first character at different positions in the permutation strings
            foreach (string str in remainingPermutations)
            {
                List<string> combinedPerms = AddCharacterAtEveryPosition(firstCharString, str);
                result.AddRange(combinedPerms);
            }

            return result.ToArray();
        }

        static List<string> AddCharacterAtEveryPosition(string firstCharString, string str)
        {
            List<String> result = new List<string>();

            // Note that <= is important to catch the terminating condition for recursion (which is an empty string array)
            for (int i = 0; i <= str.Length; i++)
            {
                string firstPart = str.Substring(str.Length - i);
                string lastPart = str.Substring(i);
                result.Add(firstPart + firstCharString + lastPart);
            }

            return result;
        }
    }
}
