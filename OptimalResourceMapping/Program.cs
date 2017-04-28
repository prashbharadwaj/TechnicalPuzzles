using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalResourceMapping
{
    class Program
    {                        
        static void Main(string[] args)
        {
            List<ServerNode> nodes = new List<ServerNode>();
            ServerNode nodeA = new ServerNode("ServerA");
            DatabaseObject db1 = new DatabaseObject("db1");
            DatabaseObject db2 = new DatabaseObject("db2");
            DatabaseObject db3 = new DatabaseObject("db3");
            nodeA.AssignDatabase(db1);
            nodeA.AssignDatabase(db2);
            nodeA.AssignDatabase(db3);

            ServerNode nodeB = new ServerNode("ServerB");
            DatabaseObject db4 = new DatabaseObject("db4");
            nodeB.AssignDatabase(db4);

            ServerNode nodeC = new ServerNode("ServerC");
            nodeC.AssignDatabase(db2);

            ServerNode nodeD = new ServerNode("ServerD");
            nodeD.AssignDatabase(db2);
            nodeD.AssignDatabase(db3);

            ServerNode nodeE = new ServerNode("ServerE");
            DatabaseObject db5 = new DatabaseObject("db5");
            nodeE.AssignDatabase(db4);
            nodeE.AssignDatabase(db5);

            var serverDbMap = GetServerDbMap(new List<ServerNode> { nodeA, nodeB, nodeC, nodeD, nodeE });
            PrintServerDbMap(serverDbMap);
            Console.ReadLine();
        }

        static Dictionary<ServerNode, DatabaseObject> GetServerDbMap(List<ServerNode> nodes)
        {
            Dictionary<ServerNode, DatabaseObject> result = new Dictionary<ServerNode, DatabaseObject>();
            foreach (var node in nodes)
            {
                var db = FindMostSuitableDb(node.DbList);
                result.Add(node, db);
                RemoveDbFromNodeList(db.Nodes, db);
            }

            return result;
        }

        static void RemoveDbFromNodeList(HashSet<ServerNode> serverNodes, DatabaseObject db)
        {
            foreach (var node in serverNodes)
            {
                node.DbList.Remove(db);
            }
        }

        static DatabaseObject FindMostSuitableDb(List<DatabaseObject> dbList)
        {
            DatabaseObject mostSuitedDb = null;
            int leastNodeCount = Int32.MaxValue;
            foreach (var db in dbList)
            {
                if (leastNodeCount > db.Nodes.Count)
                {
                    leastNodeCount = db.Nodes.Count;
                    mostSuitedDb = db;
                }
            }

            return mostSuitedDb;
        }

        static void PrintServerDbMap(Dictionary<ServerNode, DatabaseObject> serverDbMap)
        {
            foreach (var key in serverDbMap.Keys)
            {
                Console.WriteLine("{0} : {1}", key.Name, serverDbMap[key].Name);
            }
        }
    }
}
