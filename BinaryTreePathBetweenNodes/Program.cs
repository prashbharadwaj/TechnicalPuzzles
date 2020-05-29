using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreePathBetweenNodes
{
    class TreeNode : ICloneable
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

        public object Clone()
        {
            TreeNode clone = new TreeNode();
            clone.Data = this.Data;
            clone.Left = this.Left;
            clone.Right = this.Right;

            return clone;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode { Data = 20 };
            var A = new TreeNode { Data = 90 };
            var B = new TreeNode { Data = 16 };
            root.Left = A;
            root.Right = B;

            var C = new TreeNode { Data = 101 };
            var D = new TreeNode { Data = 11 };

            A.Left = C;
            A.Right = D;

            LinkedList<TreeNode> srcPath = new LinkedList<TreeNode>();
            LinkedList<TreeNode> dstPath = new LinkedList<TreeNode>();
            var pathSrc = PathFromRoot(root, C, srcPath);
            var pathDst = PathFromRoot(root, D, dstPath);

            if (!pathSrc || !pathDst)
            {
                // No path to one of them from root. 
                // Element does not exist in the tree
                return;
            }

            int srcMeetingPt = -1;
            int dstMeetingPt = -1;
            for (int srcIndex = 0, dstIndex = 0; srcIndex < srcPath.Count && dstIndex < dstPath.Count; srcIndex++, dstIndex++)
            {
                var srcElem = srcPath.ElementAt(srcIndex);
                var dstElem = dstPath.ElementAt(dstIndex);

                if (srcElem != dstElem)
                {
                    // At least root is the meeting point and hence it is ok to subtract '1'
                    srcMeetingPt = srcIndex - 1;
                    dstMeetingPt = dstIndex - 1;
                    break;
                }
            }

            // Count one of the meeting nodes too for source
            int srcLength = srcPath.Count - srcMeetingPt;
            List<TreeNode> srcToDstPath = new List<TreeNode>(srcLength + dstPath.Count - dstMeetingPt - 1);
            int count = 0;
            // Reverse pathSrc
            foreach (var elem in srcPath.Reverse())
            {
                if (count++ == srcLength)
                {
                    break;
                }

                srcToDstPath.Add(elem);
            }

            // Start after the merge point for destination  
            for (int indx = dstMeetingPt+1; indx < dstPath.Count; indx++)
            {
                var dstVal = dstPath.ElementAt(indx);
                srcToDstPath.Add(dstVal);                
            }

            PrintPath(srcToDstPath);
            Console.ReadLine();
        }

        static void PrintPath(List<TreeNode> path)
        {
            foreach (var node in path)
            {
                Console.Write("{0} ->", node.Data);
            }

            Console.WriteLine("");
        }

        static bool PathFromRoot(TreeNode root, TreeNode dest, LinkedList<TreeNode> path)
        {
            if (root == null)
            {
                return false;
            }

            path.AddLast(root);

            if (root == dest)
            {      
                return true;
            }

            var found = PathFromRoot(root.Left, dest, path);
            if (!found)
            {                
                found = PathFromRoot(root.Right, dest, path);
                if (found)
                {
                    return found;
                }
            }
            else
            {
                return found;
            }

            path.RemoveLast();
            return false;
        }
    }
}
