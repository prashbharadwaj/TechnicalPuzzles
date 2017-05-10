using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeReverseLevelOrderPrint
{
    class BinaryTree
    {
        public BinaryTree(int value)
        {
            this.NodeVal = value;
        }
        
        public int NodeVal
        {
            get;
            set;
        }
        public BinaryTree Left
        {
            get;
            set;
        }

        public BinaryTree Right
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree node = new BinaryTree(5);
            node.Left = new BinaryTree(7);
            node.Right = new BinaryTree(9);
            node.Left.Left = new BinaryTree(2);
            node.Right.Right = new BinaryTree(6);

            ReverseLevelOrderPrint(node);
            Console.ReadLine();
        }

        static void ReverseLevelOrderPrint(BinaryTree root)
        {
            Queue<BinaryTree> q = new Queue<BinaryTree>();
            Stack<int> levelCountS = new Stack<int>();
            Stack<BinaryTree> printStack = new Stack<BinaryTree>();
            q.Enqueue(root);
            printStack.Push(root);
            int currentLevelCount = 1;
            levelCountS.Push(currentLevelCount);
            BinaryTree current = null;
            int nextLevelCount = 0;
            while (q.Count != 0)
            {
                current = q.Dequeue();
                currentLevelCount--;
                if (current.Right != null)
                {
                    q.Enqueue(current.Right);
                    printStack.Push(current.Right);
                    nextLevelCount++;
                }

                if (current.Left != null)
                {
                    q.Enqueue(current.Left);
                    printStack.Push(current.Left);
                    nextLevelCount++;
                }

                if (currentLevelCount == 0)
                {
                    currentLevelCount = nextLevelCount;
                    levelCountS.Push(currentLevelCount);
                    nextLevelCount = 0;
                }
            }

            while (levelCountS.Count != 0)
            {
                int count = levelCountS.Pop();
                for (int i = 0; i < count; i++)
                {
                    BinaryTree node = printStack.Pop();
                    Console.Write("{0} ", node.NodeVal);
                }

                Console.WriteLine("\n");
            }
        }
    }
}
