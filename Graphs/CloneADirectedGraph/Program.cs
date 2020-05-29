using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloneADirectedGraph
{
    internal class GraphNode
    {
        private List<GraphNode> neighbours;
        internal string Name
        {
            get;
            set;
        }

        internal int Data
        {
            get;
            set;
        }

        internal IReadOnlyList<GraphNode> Neighbours
        {
            get { return neighbours.AsReadOnly(); }
        }

        internal GraphNode(string name, int data)
        {
            this.Name = name;
            this.Data = data;
            this.neighbours = new List<GraphNode>();
        }

        internal void AddNeighbour(GraphNode node)
        {
            this.neighbours.Add(node);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        // Recursive cloning of directed graph
        static GraphNode CloneDirectedGraph(GraphNode gn, Dictionary<string, GraphNode> gMap)
        {
            GraphNode clone = new GraphNode(gn.Name, gn.Data);
            gMap.Add(gn.Name, clone);

            foreach (GraphNode n in gn.Neighbours)
            {
                if (gMap.ContainsKey(n.Name))
                {
                    clone.AddNeighbour(gMap[n.Name]);
                }
                else
                {
                    clone.AddNeighbour(CloneDirectedGraph(n, gMap));
                }
            }

            return clone;
        }

        static GraphNode CloneDirectedGraphNR(GraphNode n)
        {
            GraphNode clone = null;
            Dictionary<string, GraphNode> gMap = new Dictionary<string, GraphNode>();
            Queue<Tuple<GraphNode, GraphNode>> q = new Queue<Tuple<GraphNode, GraphNode>>();
            q.Enqueue(new Tuple<GraphNode, GraphNode>(null, n));

            while(q.Count != 0)
            {
                var t = q.Dequeue();
                var p = t.Item1;
                var node = t.Item2;
                GraphNode cn = new GraphNode(node.Name, node.Data);
                gMap.Add(cn.Name, cn);
                if (p != null)
                {
                    p.AddNeighbour(cn);
                }

                foreach(var neighbor in node.Neighbours)
                {
                    if (gMap.ContainsKey(neighbor.Name))
                    {
                        // Add the already existing cloned neighbor
                        cn.AddNeighbour(gMap[neighbor.Name]);
                    }
                    else
                    {
                        // Queue the neighbor along with parent
                        q.Enqueue(new Tuple<GraphNode, GraphNode>(cn, neighbor));
                    }
                }
            }

            return clone;
        }
    }
}
