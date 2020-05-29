using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTraversals
{
    internal class Tree
    {
        public int Data { get; set; }
        public Tree Left { get; set; }
        public Tree Right { get; set; }

        public Tree(int val)
        {
            this.Data = val;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree root = new Tree(1);
            root.Left = new Tree(2);
            root.Left.Left = new Tree(4);

            Tree r1 = new Tree(3);
            Tree r2 = new Tree(5);

            r2.Left = new Tree(7);
            r2.Right = new Tree(8);

            r1.Left = r2;
            r1.Right = new Tree(6);
            root.Right = r1;

            PostOrderTraversalIterative(root);
            PostOrderIterativeWithOneStack(root);
            Console.ReadLine();
        }

        static void PostOrderTraversalIterative(Tree root)
        {
            Stack<Tree> traversalStack = new Stack<Tree>();
            Stack<int> outStack = new Stack<int>();
            traversalStack.Push(root);
            while (traversalStack.Count != 0)
            {
                Tree curr = traversalStack.Pop();
                outStack.Push(curr.Data);
                if (curr.Left != null)
                {
                    traversalStack.Push(curr.Left);
                }

                if (curr.Right != null)
                {
                    traversalStack.Push(curr.Right);
                }
            }

            // Print the output stack till empty
            while (outStack.Count != 0)
            {
                Console.WriteLine("{0}", outStack.Pop());
            }
        }

        // Adapted from GeeksForGeeks.org
        // http://www.geeksforgeeks.org/iterative-postorder-traversal-using-stack/
        static void PostOrderIterativeWithOneStack(Tree root)
        {
            Stack<Tree> stk = new Stack<Tree>();
            Tree prev = null;
            List<int> preOrderList = new List<int>();
            stk.Push(root);

            while (stk.Count != 0)
            {
                Tree curr = stk.Peek();
                
                // if we are going down left or right side
                if (prev == null || prev.Left == curr || prev.Right == curr)
                {
                    if (curr.Left != null)
                    {
                        stk.Push(curr.Left);
                    }
                    else if (curr.Right != null)
                    {
                        stk.Push(curr.Right);
                    }
                    else
                    {
                        curr = stk.Pop();
                        preOrderList.Add(curr.Data);
                    }
                    // We are going up from left
                }
                else if (curr.Left == prev)
                {
                    // If there is a right node, push it onto the stack
                    if (curr.Right != null)
                    {
                        stk.Push(curr.Right);
                    }
                    else
                    {
                        curr = stk.Pop();
                        preOrderList.Add(curr.Data);
                    }
                    // We are going up from right
                }
                else if (curr.Right == prev)
                {
                    // All done with the right branch
                    curr = stk.Pop();
                    preOrderList.Add(curr.Data);
                }

                prev = curr;
            }

            // Go over the preOrder list and print it
            foreach(int val in preOrderList)
            {
                Console.Write("{0}, ", val);
            }
        }
    }
}
