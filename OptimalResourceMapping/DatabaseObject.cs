using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalResourceMapping
{
    public class DatabaseObject : IEquatable<DatabaseObject>
    {
        private HashSet<ServerNode> nodes;
        public string Name
        {
            get;
            set;
        }

        public HashSet<ServerNode> Nodes
        {
            get
            {
                return this.nodes;
            }
        }

        public DatabaseObject(string name)
        {
            this.Name = name;
            nodes = new HashSet<ServerNode>(ServerNode.NodeComparer);
        }

        public void AddAssignedServer(ServerNode node)
        {
            this.nodes.Add(node);
        }

        public bool Equals(DatabaseObject y)
        {
            if (y == null)
            {
                return false;
            }

            return Name.Equals(y.Name);
        }
    }
}
