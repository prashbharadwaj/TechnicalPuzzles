using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfN
{
    class Program
    {
        static void Main(string[] args)
        {
            double pow = Power(5, 3);
            Console.WriteLine("Power value is {0}", pow);
            Console.Read();
        }

        static double Power(double val, int n)
        {
            if (n == 0)
                return 1;
            if (n == 1)
                return val;

            return PowerHelper(val, n);
        }

        static double PowerHelper(double val, int n)
        {
            if (n == 0)
                return 1;

            double res = 1;
            int exp = n;
            bool oddVal = false;
            if (n % 2 != 0)
            {
                exp = n - 1;
                oddVal = true;
            }

            res = PowerHelper(val, exp / 2);
            res *= res;
            if (oddVal)
            {
                res *= val;
            }

            return res;
        }
    }
}
