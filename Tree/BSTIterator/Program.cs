using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(4);
            root.left.left = new TreeNode(1);

            BSTIterator iterator = new BSTIterator(root);
            while (iterator.HasNext())
            {
                int val = iterator.Next();
                Console.WriteLine(val);
            }

            Console.Read();
        }
    }

    /*
     * Definition for binary tree
     */
       public class TreeNode {
           public int val;
           public TreeNode left;
           public TreeNode right;
           public TreeNode(int x) { val = x; }
       }

    // Accepted code on LeetCode
    public class BSTIterator
    {
        Stack<TreeNode> iteratorStack;
        TreeNode currentVal;

        public BSTIterator(TreeNode root)
        {
            iteratorStack = new Stack<TreeNode>();
            if (root != null)
            {
                this.iteratorStack.Push(root);
                this.currentVal = root;
            }
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            // Need to check for the case when the only remaining item is null
            return this.iteratorStack.Count == 1 && this.iteratorStack.Peek() != null || this.iteratorStack.Count > 1;
        }

        /** @return the next smallest number */
        public int Next()
        {
            // Push all the left nodes onto the stack
            while (this.currentVal != null && this.currentVal.left != null)
            {
                this.iteratorStack.Push(this.currentVal.left);
                this.currentVal = this.currentVal.left;
            }

            // If the curent value is null, to handle right node being null, pop it 
            if (this.currentVal == null)
            {
                // Popping it here is ok as we check the stack has enough elements in the HasNext()
                this.iteratorStack.Pop();
            }

            // Get the current value to return while pushing the right node onto the stack even if it is null
            int returnVal = -1;
            this.currentVal = this.iteratorStack.Pop();
            if (this.currentVal != null)
            {
                returnVal = this.currentVal.val;
                this.iteratorStack.Push(this.currentVal.right);
                this.currentVal = this.currentVal.right;
            }

            return returnVal;
        }
    }

    /**
     * Your BSTIterator will be called like this:
     * BSTIterator i = new BSTIterator(root);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}
