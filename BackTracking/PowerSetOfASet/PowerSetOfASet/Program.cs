using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerSetOfASet
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "abc";

            // Use method 1
            PowerSet1(input.ToCharArray(), -1, "".ToCharArray());

            // Use method 2
            PowerSet2(input.ToCharArray(), 0, "".ToCharArray());

            Console.Read();
        }

        // Method 1 to compute all power sets of a given set
        // This technique fixes the first set element and goes through the remaining elements
        // eg. 123 -> {}, {1}, {12}, {123}, {13}, {2}, {23}, {3}
        internal static void PowerSet1(char[] set, int index, char[] currSet)
        {
            if (index == set.Length)
                return;

            Console.WriteLine("{0}", new string(currSet));

            for (int i = index; i < set.Length - 1; i++)
            {
                string currString = new string(currSet) + set[i + 1];
                PowerSet1(set, i + 1, currString.ToCharArray());

                // No need to backtrack here as incoming currSet is not modified
            }
        }

        // Method2 to compute powerset
        // We include the current element and recurse and then we do not include current element and recurse
        internal static void PowerSet2(char[] set, int index, char[] currSet)
        {
            if (index == set.Length)
            {
                Console.WriteLine("{0}", new string(currSet));
                return;
            }

            PowerSet2(set, index + 1, (new string(currSet) + set[index]).ToCharArray());
            PowerSet2(set, index + 1, currSet);
        }
    }
}
