using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDiameter
{
    internal class TreeNode
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

        static int TreeDiameter(TreeNode root)
        {
            int d = 0;
            TreeDiameterHelper(root, ref d);
            return d;
        }

        static int TreeDiameterHelper(TreeNode t, ref int d)
        {
            if (t == null)
            {
                return 0;
            }

            int leftH = TreeDiameterHelper(t.Left, ref d);
            int rightH = TreeDiameterHelper(t.Right, ref d);

            int newD = leftH + rightH + 1;
            d = Math.Max(d, newD);

            // return max height of the subtree rooted at the current node
            return Math.Max(leftH, rightH) + 1;
        }
    }
}
