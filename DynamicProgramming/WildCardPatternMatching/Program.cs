using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// STUDY TIP:
// - Make sure to have proper end conditions
// If pattern is '*' - matches one of more. Try with next character in the string array with same pattern OR 
//                     ignore character in string array and try with next pattern
namespace WildCardPatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            string val = "xbcdefxy";
            string pat = "x*********?y";

            if (StringPatternMatch(val.ToCharArray(), pat.ToCharArray(), 0, 0))
            {
                Console.WriteLine("MATCH");
            }
            else
            {
                Console.WriteLine("NO MATCH");
            }

            val = "aaa";
            pat = "a*a";
            if (IsMatch(val, pat))
            {
                Console.WriteLine("Its a match");
            }
            else
            {
                Console.WriteLine("No match");
            }

            Console.ReadLine();
        }

        // Pattern matching traversing both arrays from the end
        static bool StringPatternMatchBackwards(char[] inString, char[] pattern, int strIndex, int patternIndex)
        {
            bool isMatch = false;
            if (strIndex < 0 && patternIndex < 0)
            {
                return true;
            }

            if (patternIndex < 0)
            {
                return false;
            }

            // If inString is completely accounted for but not pattern. Check if pattern is just '*'
            if (strIndex < 0)
            {
                for (int i = 0; i <= patternIndex; i++)
                {
                    if (pattern[i] != '*')
                    {
                        return false;
                    }
                }

                return true;
            }

            // If pattern is a '*'
            if (pattern[patternIndex] == '*')
            {
                isMatch = StringPatternMatchBackwards(inString, pattern, strIndex - 1, patternIndex) || 
                    StringPatternMatchBackwards(inString, pattern, strIndex, patternIndex - 1);
            }
            else
            {
                if (pattern[patternIndex] == '?')
                    isMatch = StringPatternMatchBackwards(inString, pattern, strIndex - 1, patternIndex - 1);
                else
                {
                    if (inString[strIndex] == pattern[patternIndex])
                    {
                        isMatch = StringPatternMatchBackwards(inString, pattern, strIndex - 1, patternIndex - 1);
                    }
                    else
                    {
                        isMatch = false;
                    }
                }
            }

            return isMatch;
        }

    // Pattern matching going forward from index 0 for both arrays
    // Both this and above function work as expected
    static bool StringPatternMatch(char[] inString, char[] pattern, int strIndex, int patternIndex)
        {
            bool isMatch = false;
            if (inString.Length == strIndex  &&  pattern.Length == patternIndex)
            {
                return true;
            }

            if (pattern.Length == patternIndex)
            {
                return false;
            }

            // If inString is completely accounted for but not pattern. Check if pattern is just '*'
            if (inString.Length == strIndex)
            {
                for (int i = patternIndex; i < pattern.Length; i++)
                {
                    if (pattern[i] != '*')
                    {
                        return false;
                    }
                }

                return true;
            }

            // Added for debugging and understanding
            Console.WriteLine("Matching char {0} with pattern {1}", inString[strIndex], pattern[patternIndex]);

            // If pattern is a '*'
            if (pattern[patternIndex] == '*')
            {
                isMatch = StringPatternMatch(inString, pattern, strIndex + 1, patternIndex) ||
                          StringPatternMatch(inString, pattern, strIndex, patternIndex + 1);
            }
            else 
            {
                if (pattern[patternIndex] == '?')
                    isMatch = StringPatternMatch(inString, pattern, strIndex + 1, patternIndex + 1);
                else
                {
                    if (inString[strIndex] == pattern[patternIndex])
                    {
                        isMatch = StringPatternMatch(inString, pattern, strIndex + 1, patternIndex + 1);
                    }
                    else
                    {
                        isMatch = false;
                    }
                }
            }

            return isMatch;
        }

        public static bool IsMatch(string s, string p)
        {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(p))
                return true;

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p))
                return false;

            return IsMatchHelper(s.ToCharArray(), p.ToCharArray(), 0, 0);
        }

        public static bool IsMatchHelper(char[] sArr, char[] pArr, int sIndex, int pIndex)
        {
            if (sArr.Length == sIndex && pArr.Length == pIndex)
                return true;

            if (pArr.Length >= pIndex)
                return false;

            if (sArr.Length >= sIndex)
            {
                // Check if the rest of pattern array is only '*"
                for (int indx = pIndex; indx < pArr.Length; indx++)
                {
                    if (pArr[indx] != '*')
                        return false;
                }

                return true;
            }

            if (pArr[pIndex] == '*')
            {
                if (pIndex > 0)
                {
                    char prevCh = pArr[pIndex - 1];
                    int cnt = 0;
                    while (sIndex + cnt  < sArr.Length && sArr[sIndex + cnt] == prevCh)
                    {
                        cnt++;
                    }
                }

                return IsMatchHelper(sArr, pArr, sIndex, pIndex + 1) || IsMatchHelper(sArr, pArr, sIndex + 1, pIndex + 1);
            }
            else
            {
                if (pArr[pIndex] == '.')
                {
                    return IsMatchHelper(sArr, pArr, sIndex + 1, pIndex + 1);
                }
                else if (pArr[pIndex] == sArr[sIndex])
                {
                    return IsMatchHelper(sArr, pArr, sIndex + 1, pIndex + 1);
                }
                else
                {
                    return IsMatchHelper(sArr, pArr, sIndex, pIndex + 1);
                }
            }
        }
    }
}