using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationSum
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] candidates = new int[] { 2, 3, 6, 7 }; Ans: for target 7 is {7, (3,2,2)}
            int[] candidates = new int[] { 10, 1, 2, 7, 6, 1, 5};
            Solution sln = new Solution();
            var results = sln.CombinationSum(candidates, 8);

            sln = new Solution();
            results = sln.CombinationSumNoDupes(candidates, 8);
            Console.Read();
        }
    }

    public class ComparableList
    {
        List<int> resultList;
        public ComparableList(List<int> list)
        {
            this.resultList = list;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            ComparableList otherList = (ComparableList)obj;
            if (this.resultList.Count != otherList.resultList.Count)
                return false;

            for (int i = 0; i < this.resultList.Count; i++)
            {
                if (this.resultList[i] != otherList.resultList[i])
                    return false;
            }

            return true;
        }

        // This needed to be implemented for it to be comparable
        public override int GetHashCode()
        {
            int hashCode = 37;
            hashCode *= 397;
            foreach (var val in this.resultList)
            {
                hashCode += val * 397;
            }

            return hashCode;
        }
    }

    // Accepted solution on LeetCode
    public class Solution
    {
        int[] sortedInput;
        List<IList<int>> resultLists;
        HashSet<ComparableList> resultSet;
        int target;
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            if (candidates == null || candidates.Length == 0)
            {
                return (IList<IList<int>>)new List<List<int>>();
            }

            resultLists = new List<IList<int>>();
            List<int> currentList = new List<int>();
            sortedInput = new int[candidates.Length];
            Array.Copy(candidates, sortedInput, candidates.Length);
            Array.Sort(sortedInput, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));
            this.target = target;
            this.CombinationHelper(0, currentList, 0);
            return (IList<IList<int>>)resultLists;
        }

        public IList<IList<int>> CombinationSumNoDupes(int[] candidates, int target)
        {
            if (candidates == null || candidates.Length == 0)
            {
                return (IList<IList<int>>)new List<List<int>>();
            }

            resultLists = new List<IList<int>>();
            resultSet = new HashSet<ComparableList>();
            List<int> currentList = new List<int>();
            sortedInput = new int[candidates.Length];
            Array.Copy(candidates, sortedInput, candidates.Length);
            Array.Sort(sortedInput, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));
            this.target = target;
            this.CombinationHelperNoDupes(0, currentList, 0);
            return (IList<IList<int>>)resultLists;
        }

        public void CombinationHelper(int sortedIndex, List<int> currentList, int currentSum)
        {
            if (sortedIndex >= this.sortedInput.Length)
                return;

            if (currentList.Count != 0)
            {
                currentSum += this.sortedInput[sortedIndex];
                if (currentSum >= this.target)
                {
                    if (currentSum == this.target)
                    {
                        List<int> list = this.CloneList(currentList);
                        this.resultLists.Add(list);
                    }

                    return;
                }
            }

            for (int i = sortedIndex; i < this.sortedInput.Length; i++)
            {
                currentList.Add(this.sortedInput[i]);
                CombinationHelper(i, currentList, currentSum);
                currentList.Remove(this.sortedInput[i]);
            }
        }

        public void CombinationHelperNoDupes(int sortedIndex, List<int> currentList, int currentSum)
        {
            if (sortedIndex >= this.sortedInput.Length)
                return;

            var currentVal = this.sortedInput[sortedIndex];
            currentSum += currentVal;
            if (currentSum >= this.target)
            {
                if (currentSum == this.target)
                {
                    List<int> list = currentList.Count == 0 ? 
                        new List<int>() { currentVal } : this.CloneList(currentList);
                    ComparableList cList = new ComparableList(list);
                    if (!this.resultSet.Contains(cList))
                    {
                        this.resultSet.Add(cList);
                        this.resultLists.Add(list);
                    }
                }

                if (currentList.Count != 0)
                {
                    return;
                }
                else
                {
                    // Nullify current sum in the first element matching target case
                    currentSum = 0;
                }
            }

            for (int i = sortedIndex + 1; i < this.sortedInput.Length; i++)
            {
                currentList.Add(this.sortedInput[i]);
                CombinationHelperNoDupes(i, currentList, currentSum);
                currentList.Remove(this.sortedInput[i]);
            }
        }

        private List<int> CloneList(List<int> inputList)
        {
            List<int> outputList = new List<int>(inputList.Count);

            foreach(int val in inputList)
            {
                outputList.Add(val);
            }

            return outputList;
        }
    }
}
