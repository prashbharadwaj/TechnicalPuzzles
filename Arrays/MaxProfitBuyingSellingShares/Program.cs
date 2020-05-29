using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProfitBuyingSellingShares
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rate = { 1, 5, 2, 3, 7, 6, 4, 5};
            int profit = MaxProfit(rate);
            Console.WriteLine("Max profit is {0}", profit);
            Console.ReadKey();
        }

        static int MaxProfit(int[] arr)
        {
            int len = arr.Length;
            int profit = 0;

            // Set index of min to '0'
            int min = 0;
            for (int i = 1; i < len; i++)
            {
                if (arr[i-1] > arr[i])
                {
                    min = i;
                }

                if ((arr[i-1] < arr[i] && i+1 == len) || arr[i] > arr[i+1])
                {
                    profit += arr[i] - arr[min];
                    Console.WriteLine("Profit: {0} Bought on {1} and sold on {2}", profit, min + 1, i + 1);
                }
            }

            return profit;
        }
    }
}
