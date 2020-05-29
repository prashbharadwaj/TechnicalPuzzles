using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeightedRandomNumbers
{
    /*
        Uber interview question
        Given n numbers, each with some frequency of occurrence. Return a random number with probability proportional to
        its frequency of occurrence.
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 5, 7 };
            int[] freq = new int[] { 1, 2, 7 };

            Dictionary<int, int> randNumMap = new Dictionary<int, int>();
            
            for (int i = 0; i < 1000; i++)
            {
                int randWtNum = GenerateRandomWeightedNumber(arr, freq);
                if (randNumMap.ContainsKey(randWtNum))
                {
                    randNumMap[randWtNum] += 1;
                }
                else
                {
                    randNumMap.Add(randWtNum, 1);
                }

                Thread.Sleep(1);
            }

            foreach (var key in randNumMap.Keys)
            {
                Console.WriteLine("Count of number {0} : {1}", key, randNumMap[key]);
            }
            
            Console.Read();
        }

        // Generate a prefix array that contains cumulative frequency or weight
        // Generate a random number upto the maximum frequency or weight and using binary search,
        // find the ceil index for that random number in the prefix array
        // Eg. Arr [10, 20, 30], Freq [2, 3, 1], PrefixArr [ 2, 5, 6]
        // Generate random numbers between 1 to 6 and get the ceil of index in prefix array,
        // If random number is 3, then ceil is 5, whose index is 1 in prefixArr and that will be element '20' in the element array
        // Explanation - http://www.geeksforgeeks.org/random-number-generator-in-arbitrary-probability-distribution-fashion/
        // http://blog.gainlo.co/index.php/2016/11/11/uber-interview-question-weighted-random-numbers/
        static int GenerateRandomWeightedNumber(int[] arr, int[] freq)
        {
            int[] prefixArr = new int[freq.Length];

            // Prefix array will contain summation of frequencies or weights at each index.
            // This will give us range of numbers between each frequency. 
            prefixArr[0] = freq[0];

            for (int i = 1; i < freq.Length; i++)
            {
                prefixArr[i] = prefixArr[i - 1] + freq[i];
            }

            int maxWeight = prefixArr[prefixArr.Length - 1];

            // Generate a random value between 1 and maxWeight
            Random rand = new Random();
            int randSeed = Math.Abs((int)DateTimeOffset.Now.Ticks);
            int randVal = rand.Next(randSeed) % maxWeight + 1;

            // Get the ceil of this randVal from the prefix array
            int indexC = GetCeilIndex2(prefixArr, randVal, 0, prefixArr.Length - 1);
            return arr[indexC];
        }

        static int GetCeilIndex(int[] arr, int val, int l, int h)
        {
            int ceil = 0;
            while (l < h)
            {
                int mid = l + (h - l) / 2;
                if (arr[mid] < val)
                {
                    l = mid + 1;
                }
                else
                {
                    ceil = mid;
                    h = mid;
                }
            }

            ceil = l > ceil ? l : ceil;
            return ceil;
        }

        // More cleaner version as understood from Techie Delight
        // http://www.techiedelight.com/find-floor-ceil-number-sorted-array/
        static int GetCeilIndex2(int[] arr, int val, int l, int h)
        {
            int ceil = 0;
            while (l <= h)
            {
                int mid = l + (h - l) / 2;
                if (arr[mid] == val)
                {
                    ceil = mid;
                    break;
                }
                else if (arr[mid] < val)
                {
                    l = mid + 1;
                }
                else
                {
                    ceil = mid;
                    h = mid - 1;
                }
            }

            return ceil;
        }
    }
}
