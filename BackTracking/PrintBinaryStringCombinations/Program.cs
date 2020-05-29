using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintBinaryStringCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "10$1$010$";
            PrintBinaryStringCombinations(input.ToCharArray(), 0);
            Console.ReadLine();
        }


        static void PrintBinaryStringCombinations(char[] inputChars, int index)
        {
            if (index >= inputChars.Length)
            {
                // Print the array and return
                Console.WriteLine("{0}", new string(inputChars));
                return;
            }

            if (inputChars[index] == '$')
            {
                for (int x = 0; x < 2; x++)
                {
                    inputChars[index] = x == 0 ? '0' : '1';
                    PrintBinaryStringCombinations(inputChars, index + 1);
                }

                // back track
                inputChars[index] = '$';
                return;
            }

            // No '$' symbol, don't do anything but continue exploring further
            PrintBinaryStringCombinations(inputChars, index + 1);
        }
    }
}
