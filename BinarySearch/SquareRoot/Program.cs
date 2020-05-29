using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            int sqrt = SquareRoot(930675566);
            Console.WriteLine("Square root of {0} is {1}", 10, sqrt);
            Console.ReadLine();
        }

        static int SquareRoot(int x)
        {
            // Base cases
            if (x == 0 || x == 1)
                return x;

            // Do Binary Search for floor(sqrt(x))
            long start = 1, end = x/2, ans = 0;
            while (start <= end)
            {
                // Important to handle integer overflows by keeping all values as long
                long mid = start + (end - start) / 2;
                long square = mid * mid;
                // If x is a perfect square
                if (square == x)
                    return (int)mid;

                // Since we need floor, we update answer when mid*mid is 
                // smaller than x, and move closer to sqrt(x)
                if (square < x)
                {
                    start = mid + 1;
                    ans = mid;
                }
                else // If mid*mid is greater than x
                    end = mid - 1;
            }
            return (int)ans;
        }
    }
}
