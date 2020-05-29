using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParanthesisPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chArr = new char[8];
            PrintParanthesisPermutation(chArr, 4, 4);
            Console.ReadKey();
        }

        static void PrintParanthesisPermutation(char[] chArr, int l, int r)
        {
            if (l == 0 && r == 0)
            {
                PrintString(chArr);
                return;
            }

            int pos = chArr.Length - l - r;
            if (l > 0)
            {
                chArr[pos] = '(';
                PrintParanthesisPermutation(chArr, l - 1, r);
            }

            if (l < r)
            {
                chArr[pos] = ')';
                PrintParanthesisPermutation(chArr, l, r - 1);
            }
        }

        static void PrintString(char[] chArr)
        {
            Console.WriteLine(new string(chArr));
        }
    }
}
