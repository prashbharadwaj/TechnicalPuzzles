using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeToLinkedList
{
    public class TreeNode
    {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            Solution sln = new Solution();
            sln.Flatten(root);
            Console.Read();
        }
    }

    // Accepted solution on Leet Code
    // Important aspect is that the left nodes have to be 'null'ed' out
    public class Solution
    {
        public void Flatten(TreeNode root)
        {
            FlattenHelper(root);
        }

        public TreeNode FlattenHelper(TreeNode t)
        {
            if (t == null)
                return null;

            TreeNode ln = FlattenHelper(t.left);
            TreeNode rn = FlattenHelper(t.right);

            t.right = ln == null ? rn : ln;
            t.left = null;
            AppendNodes(ln, rn);
            return t;
        }

        private void AppendNodes(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return;

            TreeNode node = left;
            while (node.right != null)
            {
                node = node.right;
            }

            node.right = right;
        }
    }
}
