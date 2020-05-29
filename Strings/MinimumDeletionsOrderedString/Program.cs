using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumDeletionsOrderedString
{
    /*
        Given a dictionary and a word, find the minimum number of deletions needed on the word in order to make it a valid word.
        Asked in Google recently

        Constraint: One fact is that if a longer string can be transformed to a shorter one by deleting characters, 
        the longer string must contain all the characters of the smaller one in order. If you have noticed this fact, 
        then you should know that we only need to traverse the two strings once in order to get the deletion number.

        If this constraint is not present, then the solution will differ
    */
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> map = new HashSet<string>();
            map.Add("cat");
            map.Add("dog");
            map.Add("lion");

            int minDeletions = FindMinimumDeletionsOrderedString(map, "calion");
            Console.WriteLine("Minimum deletions are {0}", minDeletions);
            Console.Read();
        }

        // O(MN) solution where M is the number of entries in the dictionary and N is length of string
        // If M is small this is a good solution
        // If M is large, it is a good idea to go through removal of each character from 's' and figuring out if it 
        // exists in map
        // http://blog.gainlo.co/index.php/2016/04/29/minimum-number-of-deletions-of-a-string/
        static int FindMinimumDeletionsOrderedString(HashSet<string> stringMap, string s)
        {
            int minDeletions = s.Length;
            char[] longerStringArr = s.ToCharArray();

            // Go through each word in dictionary
            foreach(string word in stringMap)
            {
                // Look at words that are smaller than or equal to the given string
                if (word.Length <= s.Length)
                {
                    char[] shorterStringArr = word.ToCharArray();

                    int shortIndex = 0;
                    int longIndex = 0;
                    while (shortIndex < shorterStringArr.Length)
                    {
                        if (shorterStringArr[shortIndex] == longerStringArr[longIndex])
                        {
                            shortIndex++;
                            longIndex++;
                        }
                        else
                        {
                            longIndex++;
                        }

                        // Exit if the longer string is fully traversed
                        if (longIndex == longerStringArr.Length)
                            break;
                    }

                    if (shortIndex == shorterStringArr.Length)
                    {
                        minDeletions = Math.Min(minDeletions, longerStringArr.Length - shorterStringArr.Length);
                    }
                }
            }

            return minDeletions;
        }
    }
}
