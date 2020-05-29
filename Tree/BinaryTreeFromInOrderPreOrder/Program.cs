using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeFromInOrderPreOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] preOrder = new int[] { 1, 2 };
            int[] inOrder = new int[] { 2, 1 };
            TreeNode node = new Solution().BuildTree(preOrder, inOrder);
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

    // This works correctly but Leet Code is not accepting for some reason
    public class Solution
    {
        private static int preIndex = 0;
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0 || inorder == null || inorder.Length == 0)
            {
                return null;
            }

            return BuildTreeHelper(preorder, inorder, 0, inorder.Length - 1);
        }

        public TreeNode BuildTreeHelper(int[] preorder, int[] inorder, int sIndex, int eIndex)
        {
            if (preIndex >= preorder.Length || sIndex > eIndex)
            {
                return null;
            }

            int nodeval = preorder[preIndex++];
            TreeNode node = new TreeNode(nodeval);
            if (sIndex == eIndex)
                return node;
            int endIndex = FindValInInorderArray(inorder, nodeval);
            node.left = BuildTreeHelper(preorder, inorder, sIndex, endIndex - 1);
            node.right = BuildTreeHelper(preorder, inorder, endIndex + 1, eIndex);
            return node;
        }

        public int FindValInInorderArray(int[] inorder, int val)
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                if (val == inorder[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
