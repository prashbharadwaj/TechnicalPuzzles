using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAncestor
{
    class TreeWithParent
    {
        public int Data
        {
            get;
            set;
        }

        public TreeWithParent Left
        {
            get;
            set;
        }

        public TreeWithParent Right
        {
            get;
            set;
        }

        public TreeWithParent Parent
        {
            get;
            set;
        }
    }

    class Tree
    {
        public int Data
        {
            get;
            set;
        }

        public Tree Left
        {
            get;
            set;
        }

        public Tree Right
        {
            get;
            set;
        }
    }

    class Result
    {
        public bool IsAncestor;
        public Tree Node; 
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeWithParent root = new TreeWithParent();
            root.Data = 20;

            TreeWithParent A = new TreeWithParent();
            A.Data = 10;
            root.Left = A;
            A.Parent = root;

            TreeWithParent B = new TreeWithParent();
            B.Data = 30;
            root.Right = B;
            B.Parent = root;

            TreeWithParent C = new TreeWithParent();
            C.Data = 15;
            A.Right = C;
            C.Parent = A;

            TreeWithParent D = new TreeWithParent();
            D.Data = 17;
            C.Right = D;
            D.Parent = C;

            TreeWithParent E = new TreeWithParent();
            E.Data = 5;
            A.Left = E;
            E.Parent = A;

            TreeWithParent F = new TreeWithParent();
            F.Data = 7;
            E.Right = F;
            F.Parent = E;

            TreeWithParent G = new TreeWithParent();
            G.Data = 3;
            E.Left = G;
            G.Parent = E;

            var commonAncestor = FindCommonAncestor(root, E, B);

            Console.WriteLine("The common ancestor for {0} and {1} is {2}", F.Data, D.Data, commonAncestor.Data);

            // Find Common ancestor
            Tree rootT = new Tree();
            root.Data = 1;

            Tree At = new Tree();
            At.Data = 5;
            rootT.Left = At;

            Tree Bt = new Tree();
            Bt.Data = 13;
            At.Right = Bt;

            Tree Ct = new Tree();
            Ct.Data = 10;
            rootT.Right = Ct;

            Tree Dt = new Tree();
            Dt.Data = 25;
            Ct.Left = Dt;

            Tree Et = new Tree();
            Et.Data = 32;
            Ct.Right = Et;

            Tree Ft = new Tree();
            Ft.Data = 11;
            Et.Left = Ft;

            Tree outsideNode = new Tree { Data = 25 };
            // var CA = FindCommonAncestor(rootT, Dt, outsideNode);
            var CA = FindCommonAncestor(rootT, Dt, Et);
            if (CA.IsAncestor)
            {
                Console.WriteLine("The common ancestor for {0} and {1} is {2}", Dt.Data, Ft.Data, CA.Node.Data);
            }
            else
            {
                Console.WriteLine("There is no common ancestor for {0} and {1}", Dt.Data, outsideNode.Data);
            }

            Console.ReadLine();
        }

        static TreeWithParent FindCommonAncestor(TreeWithParent root, TreeWithParent p, TreeWithParent q)
        {
            if (root == null)
            {
                return null;
            }

            if (!Covers(root, p) || !Covers(root, q))
            {
                return null;
            }

            var parent = p.Parent;
            var sibling = GetSibling(p);
            while (parent != null)
            {
                if (Covers(sibling, q))
                {
                    return parent;
                }

                sibling = GetSibling(parent);
                parent = parent.Parent;
            }

            return null;
        }

        static TreeWithParent GetSibling(TreeWithParent node)
        {
            var parent = node.Parent;
            if (parent == null) return null;
            return parent.Left == node ? parent.Right : parent.Left;
        }

        static bool Covers(TreeWithParent root, TreeWithParent x)
        {
            if (root == null)
            {
                return false;
            }

            if (root == x)
            {
                return true;
            }

            return Covers(root.Left, x) || Covers(root.Right, x);
        }

        static Result FindCommonAncestor(Tree root, Tree p, Tree q)
        {
            if (root == null)
            {
                return new Result { IsAncestor = false, Node = null };
            }

            if (root == p && root == q)
            {
                return new Result { IsAncestor = true, Node = root };
            }

            var rx = FindCommonAncestor(root.Left, p, q);
            if (rx.IsAncestor)
            {
                return rx;
            }

            var ry = FindCommonAncestor(root.Right, p, q);
            if (ry.IsAncestor)
            {
                return ry;
            }

            if ((rx.Node != null) && (ry.Node != null))
            {
                Result r = new Result { IsAncestor = true, Node = root };
                return r;
            }
            else if (root == p || root == q)
            {
                // root is p or q. If the other one is present in the subtree, then root is the common ancestor
                var isAncestor = rx.Node != null || ry.Node != null;
                return new Result { IsAncestor = isAncestor, Node = root };
            }
            else
            {
                var node = rx.Node != null ? rx.Node : ry.Node;
                return new Result { IsAncestor = false, Node = node };
            }
        }
    }
}
