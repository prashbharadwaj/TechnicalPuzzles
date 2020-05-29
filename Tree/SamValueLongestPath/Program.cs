using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
   Find longest path in a tree between nodes that have the same value
   - Source Glassdoor for Google interview questions
*/
namespace SamValueLongestPath
{
    class TreeNode
    {
        public int Data { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
    }

    class ResultWrapper
    {
        private Dictionary<int, int> nodeMap;
        public int MaxPath { get; set; }
        public ResultWrapper(int maxPath)
        {
            this.MaxPath = maxPath;
            nodeMap = new Dictionary<int, int>();
        }

        public Dictionary<int, int> NodeMap
        {
            get { return this.nodeMap; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Sample unit test to test this

        }

        static ResultWrapper GetMaxPath(TreeNode node, int level)
        {
            if (node == null)
            {
                return new ResultWrapper(-1);
            }

            // Similar to Post order traversal - DFS traversal of the tree
            ResultWrapper leftRes = GetMaxPath(node.Left, level + 1);
            ResultWrapper rightRes = GetMaxPath(node.Right, level + 1);

            int maxPath = leftRes.MaxPath;
            foreach(var key in leftRes.NodeMap.Keys)
            {
                if (rightRes.NodeMap.ContainsKey(key))
                {
                    maxPath = Math.Max(maxPath, leftRes.NodeMap[key] + rightRes.NodeMap[key] - 2 * level);
                }
            }

            // Check if the current root is in the left or right results
            if (leftRes.NodeMap.ContainsKey(node.Data))
            {
                maxPath = Math.Max(maxPath, leftRes.NodeMap[node.Data] - level);
            }

            if (rightRes.NodeMap.ContainsKey(node.Data))
            {
                maxPath = Math.Max(maxPath, rightRes.NodeMap[node.Data] - level);
            }

            // Create a deduped result wrapper including the current root node
            ResultWrapper res = new ResultWrapper(maxPath);
            foreach (KeyValuePair<int, int> kvp in leftRes.NodeMap)
            {
                res.NodeMap.Add(kvp.Key, kvp.Value);
            }

            // Add to result from right resultMap if it is not present or 
            // if the left side is smaller than the right side (as we need to longest path)
            foreach(int key in rightRes.NodeMap.Keys)
            {
                if (!res.NodeMap.ContainsKey(key))
                {
                    res.NodeMap.Add(key, rightRes.NodeMap[key]);
                }
                else if (res.NodeMap[key] < rightRes.NodeMap[key])
                {
                    res.NodeMap[key] = rightRes.NodeMap[key];
                }
            }

            // Add root data if it is not present
            if (!res.NodeMap.ContainsKey(node.Data))
                res.NodeMap.Add(node.Data, level);

            return res;
        }
    }
}
