using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { -1, 0, 1, 2, -1, -4 };
            // int[] A = { -2, 0, 0, 2, 2 };
            ThreeSum(A);
            IList<IList<int>> result = ThreeSumList(A);

            // This was the accepted solution
            result = ThreeSumWithSort(A);
            Console.ReadKey();
        }

        public static void ThreeSum(int[] nums)
        {
            // Map of value to index
            Dictionary<int, int> sumMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!sumMap.ContainsKey(nums[i]))
                {
                    // If there is a duplicate, only first index is noted down
                    sumMap.Add(nums[i], i);
                }
            }

            for (int j = 0; j < nums.Length; j++)
            {
                for (int k = 0; k < nums.Length; k++)
                {
                    int valToLookup = (nums[j] + nums[k]) * -1;
                    if (sumMap.ContainsKey(valToLookup) && (j != k) && (k != sumMap[valToLookup]) && (j != sumMap[valToLookup]))
                    {
                        int iIndex = sumMap[valToLookup];
                        Console.WriteLine("Three sum is Zero for values i = {0}, j = {1} and k = {2}", iIndex, j, k);
                    }
                }
            }
        }

        public class Triplet
        {
            public static TripletComparator TripletValueComparer = new TripletComparator();
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }

        public class TripletComparator : IEqualityComparer<Triplet>
        {
            public bool Equals(Triplet x, Triplet y)
            {
                if (x == null && y == null)
                    return true;
                if (y == null || x == null)
                    return false;

                if (!x.Z.Equals(y.Z))
                {
                    return x.Z.Equals(y.Z);
                }
                else if (!x.Y.Equals(y.Y))
                {
                    return x.Y.Equals(y.Y);
                }
                else if (!x.X.Equals(x.X))
                {
                    return x.X.Equals(y.X);
                }
                else
                {
                    return true;
                }
            }

            public int GetHashCode(Triplet obj)
            {
                unchecked
                {
                    int result = 37; // prime

                    result *= 397; // also prime (see note)
                    result += obj.X.GetHashCode();
                    result *= 397;                    
                    result += obj.Y.GetHashCode();
                    result *= 397;                    
                    result += obj.Z.GetHashCode();
                    return result;
                }
            }
        }

        public static IList<IList<int>> ThreeSumList(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();

            // Map of value to index
            Dictionary<int, int> sumMap = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!sumMap.ContainsKey(nums[i]))
                {
                    // If there is a duplicate, only first index is noted down
                    sumMap.Add(nums[i], i);
                }
            }

            for (int j = 0; j < nums.Length; j++)
            {
                for (int k = 0; k < nums.Length; k++)
                {
                    int valToLookup = (nums[j] + nums[k]) * -1;
                    if (sumMap.ContainsKey(valToLookup) && (j != k) && (k != sumMap[valToLookup]) && (j != sumMap[valToLookup]))
                    {
                        int iIndex = sumMap[valToLookup];
                        List<int> indices = new List<int>() { nums[iIndex], nums[j], nums[k] };
                        
                        if (!result.Any(x => x.All(indices.Contains)))
                        {
                            result.Add(indices);
                        }
                    }
                }
            }

            return (IList<IList<int>>)result;
        }

        /// <summary>
        /// Three sum using sorting. This was the accepted solution on LeetCode for the problem below:
        /// Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
        /// Note: The solution set must not contain duplicate triplets.
        /// For example, given array S = [-1, 0, 1, 2, -1, -4],
        /// A solution set is:
        /// [
        ///  [-1, 0, 1],
        ///  [-1, -1, 2]
        ///   ]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> ThreeSumWithSort(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            HashSet<Triplet> set = new HashSet<Triplet>(Triplet.TripletValueComparer);
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            { 
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int currVal = nums[i] + nums[j] + nums[k];
                    if (currVal > 0)
                    {
                        k--;
                    }
                    else if (currVal < 0)
                    {
                        j++;
                    }
                    else
                    {
                        Triplet t = new Triplet { X = nums[i], Y = nums[j], Z = nums[k] };
                        if (!set.Contains(t))
                        {
                            result.Add(new List<int>() { nums[i], nums[j], nums[k] });
                            set.Add(t);
                        }

                        j++;
                        k--;
                    }
                }
            }

            return result;
        }

        public List<List<int>> threeSum(int[] num)
        {
            Array.Sort(num);
            List<List<int>> res = new LinkedList<>();
            for (int i = 0; i < num.length - 2; i++)
            {
                if (i == 0 || (i > 0 && num[i] != num[i - 1]))
                {
                    int lo = i + 1, hi = num.length - 1, sum = 0 - num[i];
                    while (lo < hi)
                    {
                        if (num[lo] + num[hi] == sum)
                        {
                            res.add(Array.AsList(num[i], num[lo], num[hi]));
                            while (lo < hi && num[lo] == num[lo + 1]) lo++;
                            while (lo < hi && num[hi] == num[hi - 1]) hi--;
                            lo++; hi--;
                        }
                        else if (num[lo] + num[hi] < sum) lo++;
                        else hi--;
                    }
                }
            }
            return res;
        }
    }
}
