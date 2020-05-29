using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Implement atoi to convert a string to an integer.
Hint: Carefully consider all possible input cases. If you want a challenge, please do not see below and ask yourself what are the possible input cases.
Notes: It is intended for this problem to be specified vaguely (ie, no given input specs). You are responsible to gather all the input requirements up front. 
Update (2015-02-10):
The signature of the C++ function had been updated. If you still see your function signature accepts a const char * argument, please click the reload button  to reset your code definition. 
spoilers alert... click to show requirements for atoi.
Requirements for atoi: 
The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.
The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.
If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.
If no valid conversion could be performed, a zero value is returned. If the correct value is out of the range of representable values, INT_MAX (2147483647) or INT_MIN (-2147483648) is returned. 
*/

namespace atoi
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "      -11919730356x";
            int result = new Solution().MyAtoi(input);
            Console.Read();
        }

        public class Solution
        {
            public int MyAtoi(string str)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return 0;
                }

                str = str.Trim();
                int result = 0;
                char[] chArr = str.ToCharArray();

                // This needs to be of type long so that we can catch the point where result 
                // crosses Int32.MaxValue or Int32.MinValue
                long tempResult = 0;
                int sign = 1;
                for (int i = 0; i < chArr.Length; i++)
                {
                    if (i == 0 && (chArr[i] == '-' || chArr[i] == '+'))
                    {
                        sign = chArr[i] == '-' ? -1 : 1;
                        continue;
                    }

                    if (IsValidNumber(chArr[i]))
                    {
                        tempResult = tempResult * 10 + chArr[i] - '0';
                        var finalResult = tempResult * sign;
                        if (finalResult >= Int32.MaxValue || finalResult <= Int32.MinValue)
                        {
                            result = sign == -1 ? Int32.MinValue : Int32.MaxValue;
                            return result;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                result = (int)tempResult * sign;
                return result;
            }

            public bool IsValidNumber(char ch)
            {
                return ch >= '0' && ch <= '9';
            }
        }
    }
}
