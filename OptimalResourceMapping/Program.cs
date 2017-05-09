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

            //Second test
            nodes = new List<ServerNode>();
            nodeA = new ServerNode("ServerA");
            db1 = new DatabaseObject("db1");
            db2 = new DatabaseObject("db2");
            db3 = new DatabaseObject("db3");
            nodeA.AssignDatabase(db1);
            nodeA.AssignDatabase(db2);            

            nodeB = new ServerNode("ServerB");
            db4 = new DatabaseObject("db4");
            nodeB.AssignDatabase(db2);
            nodeB.AssignDatabase(db3);
            nodeB.AssignDatabase(db4);

            nodeC = new ServerNode("ServerC");
            db5 = new DatabaseObject("db5");
            nodeC.AssignDatabase(db4);
            nodeC.AssignDatabase(db5);

            nodeD = new ServerNode("ServerD");
            nodeD.AssignDatabase(db5);

            nodeE = new ServerNode("ServerE");
            DatabaseObject db6 = new DatabaseObject("db6");
            nodeE.AssignDatabase(db6);
            nodeE.AssignDatabase(db2);
            nodeE.AssignDatabase(db1);
            


            Console.ReadLine();
        }

        static Dictionary<ServerNode, DatabaseObject> GetServerDbMap(List<ServerNode> nodes)
        {
            Dictionary<ServerNode, DatabaseObject> result = new Dictionary<ServerNode, DatabaseObject>();

            // Make a first pass and map single node mapping first
            for(int i = 0; i < nodes.Count; i++)
            {
                var n = nodes[i];
                if (n.DbList.Count == 1)
                {
                    MapNodeToDb(n, n.DbList[0], result);
                    nodes[i] = null;
                }
            }

            foreach (var node in nodes)
            {
                if (node != null)
                {
                    var db = FindMostSuitableDb(node.DbList);
                    MapNodeToDb(node, db, result);
                }
            }

            return result;
        }
        
        static void MapNodeToDb(ServerNode node, DatabaseObject db, Dictionary<ServerNode, DatabaseObject> map)
        {
            map.Add(node, db);
            RemoveDbFromNodeList(db.Nodes, db);
            RemoveNodeFromDbList(node.DbList, node);
        }

        static void RemoveNodeFromDbList(List<DatabaseObject> dbList, ServerNode node)
        {
            foreach (var db in dbList)
            {
                db.Nodes.Remove(node);
            }
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
