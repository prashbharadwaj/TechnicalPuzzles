using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This is a modification of permutation of a string
/// Permuation of an array can be achieved by inserting a given value(a) at all possible locations of permutations of the a(n-1)
/// Eg. if {2, 3} and {3, 2} are two permutations, we get {1, 2, 3}, {2, 1, 3}, {2, 3, 1} by inserting '1' in all possible locations in {2, 3} and 
/// similarly {1, 3, 2}, {3, 1, 2}, {3, 2, 1} by inserting '1' in all possible locations for {3, 2}
/// </summary>
namespace ArrayPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[] nums = { 1, 2, 3 };
            IList<IList<int>> permutedLists = sol.Permute(nums);
            Console.ReadKey();
        }

        public class Solution
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                return PermuteHelper(nums);
            }

            public IList<IList<int>> PermuteHelper(int[] nums)
            {
                if (nums == null || nums.Length == 0)
                {
                    return (IList<IList<int>>)new List<IList<int>>();
                }

                int val = nums[0];
                int[] numSubArr = new int[nums.Length - 1];
                Array.Copy(nums, 1, numSubArr, 0, nums.Length - 1);
                var permuteLists = PermuteHelper(numSubArr);
                if (permuteLists.Count == 0)
                {
                    permuteLists.Add(new List<int>() { val });
                }
                else
                {
                    IList<IList<int>> llist = new List<IList<int>>();
                    for (int listIndx = 0; listIndx < permuteLists.Count; listIndx++)
                    {
                        var list = permuteLists[listIndx];
                        for (int i = 0; i <= list.Count; i++)
                        {
                            var rList = InsertAt(list, i, val);
                            llist.Add(rList);
                        }
                    }

                    permuteLists = llist;
                }

                return permuteLists;
            }

            public List<int> InsertAt(IList<int> list, int index, int val)
            {
                List<int> newList = new List<int>();
                for (int i = 0; i < index; i++)
                {
                    newList.Add(list[i]);
                }

                newList.Add(val);

                for (int i = index; i < list.Count; i++)
                {
                    newList.Add(list[i]);
                }

                return newList;
            }
        }
    }
}
