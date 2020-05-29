using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(5);
            TreeNode n4 = new TreeNode(4);
            TreeNode n8 = new TreeNode(8);
            root.left = n4;
            root.right = n8;
            TreeNode n11 = new TreeNode(11);
            n4.left = n11;
            n11.left = new TreeNode(7);
            n11.right = new TreeNode(2);

            n8.left = new TreeNode(13);
            TreeNode n42 = new TreeNode(4);
            n8.right = n42;
            n42.left = new TreeNode(5);
            n42.right = new TreeNode(1);

            var result = new Solution().PathSum(root, 22);
            Console.Read();

        }
    }

    // Definition for a binary tree node.
   public class TreeNode {
       public int val;
       public TreeNode left;
       public TreeNode right;
      public TreeNode(int x) { val = x; }
   }

    // This solution was accepted on LeetCode
    public class Solution
    {
        IList<IList<int>> resultList;
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            resultList = new List<IList<int>>();
            if (root == null)
                return resultList;

            int currentSum = 0;
            List<int> currentList = new List<int>();
            PathSumHelper(root, sum, currentSum, currentList);
            return resultList;
        }

        private void PathSumHelper(TreeNode t, int sum, int currentSum, List<int> currentList)
        {
            if (t == null)
                return;

            currentSum += t.val;
            currentList.Add(t.val);
            if (IsLeaf(t))
            {
                if (currentSum == sum)
                    resultList.Add(currentList);

                return;
            }

            List<int> leftList = Clone(currentList);
            List<int> rightList = Clone(currentList);
            PathSumHelper(t.left, sum, currentSum, leftList);
            PathSumHelper(t.right, sum, currentSum, rightList);
        }

        private static bool IsLeaf(TreeNode t)
        {
            return t.left == null && t.right == null;
        }

        public static List<int> Clone(List<int> listToClone)
        {
            return listToClone.Select(item => item).ToList();
        }
    }
}
