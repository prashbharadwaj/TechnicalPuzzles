using System;

// Find predecessor node given a node in a binary search tree (BST).
internal class TreeNode
{
    public int data;
    public TreeNode left;
    public TreeNode right;
}

class Solution
{
    static void Main(string[] args)
    {
        TreeNode root = new TreeNode { data = 11 };
        TreeNode node9 = new TreeNode { data = 9 };
        TreeNode node17 = new TreeNode { data = 17 };
        TreeNode node6 = new TreeNode { data = 6 };
        TreeNode node10 = new TreeNode { data = 10 };
        TreeNode node13 = new TreeNode { data = 13 };
        TreeNode node29 = new TreeNode { data = 29 };
        TreeNode node21 = new TreeNode { data = 21 };
        TreeNode node26 = new TreeNode { data = 26 };

        root.left = node9;
        root.right = node17;

        node9.left = node6;
        node9.right = node10;

        node17.left = node13;
        node17.right = node29;

        node29.left = node21;

        node21.right = node26;

        //BST scenarios


        // Non-BST
        TreeNode predecessorNode = FindPredecessor(root, node29);
        PrintStatus(node29, predecessorNode);

        predecessorNode = FindPredecessor(root, node13);
        PrintStatus(node13, predecessorNode);

        predecessorNode = FindPredecessor(root, node26);
        PrintStatus(node26, predecessorNode);

        predecessorNode = FindPredecessor(root, node9);
        PrintStatus(node9, predecessorNode);

        predecessorNode = FindPredecessor(root, root);
        PrintStatus(root, predecessorNode);

        predecessorNode = FindPredecessor(root, node6);
        PrintStatus(node6, predecessorNode);
    }

    static void PrintStatus(TreeNode node, TreeNode predecessorNode)
    {
        if (node == null)
        {
            Console.WriteLine("Cannot find predecessor node for NULL node");
            return;
        }

        if (predecessorNode == null)
        {
            Console.WriteLine("Predecessor node for {0} does not exist", node.data);
        }
        else
        {
            Console.WriteLine("Predecessor node for {0} : {1}", node.data, predecessorNode.data);
        }
    }

    // Find predecessor using BST characteristics
    static TreeNode FindPredecessorBst(TreeNode root, TreeNode node)
    {
        TreeNode tree = root;
        TreeNode predecessor = null;
        while (tree != null)
        {
            if (node.data > tree.data)
            {
                predecessor = node;
                tree = tree.right;
            }
            else
            {
                tree = tree.left;
            }
        }

        return predecessor;
    }

    // Find successor using BST properties
    static TreeNode FindSucccessorBst(TreeNode root, TreeNode node)
    {
        TreeNode tree = root;
        TreeNode successor = null;
        while (tree != null)
        {
            if (node.data <= tree.data)
            {
                successor = node;
                tree = tree.left;
            }
            else
            {
                tree = tree.right;
            }
        }

        return successor;
    }

    static TreeNode FindPredecessor(TreeNode root, TreeNode node)
    {
        if (root == null || node == null)
        {
            return null;
        }

        // If left node is present
        if (node.left != null)
        {
            TreeNode leftNode = node.left;

            // Find right most child in the left subtree
            while (leftNode.right != null)
            {
                leftNode = leftNode.right;
            }

            return leftNode;
        }
        else
        {
            return FindPredecessorTopDown(root, node);
        }
    }

    static TreeNode FindPredecessorTopDown(TreeNode root, TreeNode node)
    {
        if (root == null)
        {
            return null;
        }

        if (FindSuccessor(root) == node)
        {
            return root;
        }

        TreeNode predecessorNode = FindPredecessorTopDown(root.left, node);
        if (predecessorNode == null)
        {
            predecessorNode = FindPredecessorTopDown(root.right, node);
        }

        return predecessorNode;
    }

    static TreeNode FindSuccessor(TreeNode node)
    {
        // left most element on the right side
        TreeNode rightNode = node.right;
        while (rightNode != null && rightNode.left != null)
        {
            rightNode = rightNode.left;
        }

        return rightNode;
    }

}
