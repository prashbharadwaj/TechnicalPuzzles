using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTFromPreOrderArray
{
    public class TreeNode
    {
        public int Data
        {
            get;
            set;
        }

        public TreeNode Left
        {
            get;
            set;
        }

        public TreeNode Right
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int [] pre = new int[] { 10, 5, 1, 7, 40, 50 };
            TreeNode node = BuildTreeFromPreOrder(pre);
            Console.ReadLine();
        }

        static TreeNode BuildTreeFromPreOrder(int[] arr)
        {
            int indx = 0;
            return BuildTreeFromPreOrderUtil(arr, Int32.MinValue, Int32.MaxValue, ref indx);
        }

        static TreeNode BuildTreeFromPreOrderUtil(int[] arr, int min, int max, ref int indx)
        {
            if (indx >= arr.Length)
            {
                return null;
            }

            int curr = arr[indx];
            if (curr < min || curr > max)
            {
                return null;
            }

            TreeNode node = new TreeNode();
            node.Data = curr;

            indx++;
            if (indx < arr.Length)
            {
                node.Left = BuildTreeFromPreOrderUtil(arr, min, curr, ref indx);
                node.Right = BuildTreeFromPreOrderUtil(arr, curr, max, ref indx);
            }

            return node;
        }
    }
}
