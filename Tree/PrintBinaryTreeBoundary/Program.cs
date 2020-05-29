using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintBinaryTreeBoundary
{
    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        static void PrintBoundary(TreeNode tree)
        {
            if (tree == null)
                return;

            Console.WriteLine("{0} ", tree.Data);

            // Print left
            PrintLeftTree(tree.Left);

            // Print left leaf nodes
            PrintLeafNodes(tree.Left);

            // Print right leaf nodes
            PrintLeafNodes(tree.Right);

            // Print right tree
            PrintRightTree(tree.Right);
        }

        static void PrintLeftTree(TreeNode tree)
        {
            if (tree == null)
                return;

            if (tree.Left != null)
            {
                Console.WriteLine("{0} ", tree.Data);
                PrintLeftTree(tree.Left);
            }
            else
            {
                Console.WriteLine("{0} ", tree.Data);
                PrintLeftTree(tree.Right);
            }

            // Do not print leaf nodes
        }

        static void PrintRightTree(TreeNode tree)
        {
            if (tree == null)
                return;

            if (tree.Right != null)
            {
                PrintRightTree(tree.Right);
                Console.WriteLine("{0} ", tree.Data);
            }
            else if (tree.Left != null)
            {
                PrintRightTree(tree.Left);
                Console.WriteLine("{0} ", tree.Data);
            }

            // Do not print leaf nodes
        }

        static void PrintLeafNodes(TreeNode tree)
        {
            if (tree == null)
                return;

            if (tree.Left != null)
            {
                PrintLeafNodes(tree.Left);
            }
            else if (tree.Right != null)
            {
                PrintLeafNodes(tree.Right);
            }
            else
            {
                // Print leaf nodes
                Console.WriteLine("{0} ", tree.Data);
            }
        }
    }
}
