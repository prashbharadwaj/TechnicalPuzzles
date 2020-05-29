using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloorAndCeiling
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
        
        static TreeNode NewNode(int key)
        {
            TreeNode node = new TreeNode();
            node.Data = key;
            node.Left = null;
            node.Right = null;
            return node;
        }

        static TreeNode Insert(TreeNode root, int key)
        {
            if (root == null)
            {
                return NewNode(key);
            }

            if (root.Data > key)
            {
                root.Left = Insert(root.Left, key);
            }
            else
            {
                // key is >= root
                root.Right = Insert(root.Right, key);
            }

            return root;
        }

        static void FloorAndCeil(TreeNode root, ref int floor, ref int ceil, int key)
        {
            if (root == null)
            {
                return;
            }

            if (root.Data > key)
            {
                ceil = root.Data;
                FloorAndCeil(root.Left, ref floor, ref ceil, key);
            }
            else if (root.Data < key)
            {
                floor = root.Data;
                FloorAndCeil(root.Right, ref floor, ref ceil, key);
            }
            else
            {
                ceil = floor = key;
            }
        }
    }
}
