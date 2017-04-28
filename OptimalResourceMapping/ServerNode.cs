using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalResourceMapping
{
    public class ServerNodeComparer : IEqualityComparer<ServerNode>
    {
        public bool Equals(ServerNode x, ServerNode y)
        {
            if (x == null && y == null)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(ServerNode obj)
        {
            return obj.Name.GetHashCode() * 17;
        }
    }

    public class ServerNode
    {
        private List<DatabaseObject> dbList = new List<DatabaseObject>();
        public static ServerNodeComparer NodeComparer = new ServerNodeComparer();
        public string Name
        {
            get;
            set;
        }

        public List<DatabaseObject> DbList
        {       
            get
            {
                return this.dbList;
            }
        }

        public ServerNode(string name)
        {
            this.Name = name;
        }

        public void AssignDatabase(DatabaseObject db)
        {
            this.dbList.Add(db);
            db.AddAssignedServer(this);
        }
    }
}
