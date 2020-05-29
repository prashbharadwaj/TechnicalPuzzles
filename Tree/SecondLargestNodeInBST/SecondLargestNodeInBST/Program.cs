using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLargestNodeInBST
{
    internal class BinarySearchTree
    {
        internal int Data { get; set; }
        internal BinarySearchTree Right { get; set; }
        internal BinarySearchTree Left { get; set; }
    }

    class Program
    {
        static BinarySearchTree GetLargestNode(BinarySearchTree root)
        {
            if (root == null)
            {
                throw new ArgumentNullException("root");
            }

            BinarySearchTree largestNode = root;
            while (largestNode.Right != null)
            {
                largestNode = largestNode.Right;
            }

            return largestNode;
        }

        static BinarySearchTree GetSecondLargestNode(BinarySearchTree root)
        {
            if (root == null || (root.Left == null && root.Right == null))
                throw new ArgumentException("Incoming argument is invalid");

            BinarySearchTree node = root;
            while (node.Right != null)
            {
                node = node.Right;
            }

            if (node.Left == null)
            {
                return node;
            }
            else
            {
                return GetLargestNode(node.Left);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
