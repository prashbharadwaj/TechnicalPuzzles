using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache cache = new LRUCache(5);
            cache.Write("Prashant", 1);
            cache.Write("Smitha", 2);
            cache.Write("Samaksh", 4);
            cache.Write("Amma", 3);
            cache.Write("Smera", 5);
            cache.Write("Prasanna", 6);

            cache.Print();
            Console.ReadLine();
        }
    }


    //Design a Least Recently Used (LRU) cache of size N. 
    //On Write - When the cache reached its capacity, it should invalidate the least recently used item before inserting a new item.  The new item should now be the most recently used item.
    //On Read - If the value exists then return the value and mark it as the most recently used item. If the value doesn’t exists in cache then return null. 

    public class Node
    {
        public string Key { get; set; }
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(string key, int value)
        {
            this.Data = value;
            this.Key = key;
        }
    }

    class LRUCache
    {
        public Dictionary<string, Node> map;
        public int CacheSize { get; set; }
        public CacheList cacheList;
        public ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();

        public LRUCache(int size)
        {
            this.CacheSize = size;
            this.map = new Dictionary<string, Node>();
            cacheList = new CacheList();
        }

        public void Print()
        {
            this.cacheList.Print();
        }

        public int Read(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(key);
            }

            if (!map.ContainsKey(key))
            {
                throw new KeyNotFoundException("Key not found");
            }

            Node node = map[key];
            this.cacheList.MoveToHead(node);
            return node.Data;
        }

        public void Write(string key, int value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(key);
            }

            if (map.ContainsKey(key))
            {
                Node node = map[key];
                this.cacheList.MoveToHead(node);
                node.Data = value;
            }
            else
            {
                Node node = new Node(key, value);
                map.Add(key, node);
                if (this.cacheList.Size >= this.CacheSize)
                {
                    Node prevTailNode = this.cacheList.RemoveFromLast();
                    if (prevTailNode != null)
                    {
                        this.map.Remove(prevTailNode.Key);
                    }
                }

                this.cacheList.MoveToHead(node);
            }
        }
    }

    public class CacheList
    {
        public Node Head;
        public Node Tail;

        public int Size { get; private set; }

        public void MoveToHead(Node node)
        {
            if (node == Head && Head == Tail)
            {
                return;
            }

            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            if (Tail == node)
            {
                Tail = Tail.Prev;
            }



            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }

            node.Prev = null;
            node.Next = null;

            Head.Prev = node;
            node.Next = Head;
            Head = node;
        }

        public Node RemoveFromLast()
        {
            if (Tail == null)
                return null;

            Node nodeToRemove = Tail;
            Tail = nodeToRemove.Prev;
            if (Tail != null)
            {
                Tail.Next = null;
                nodeToRemove.Prev = null;
            }

            return nodeToRemove;
        }

        public void Print()
        {
            Node start = Head;
            while (start != Tail)
            {
                Console.WriteLine("Node key = {0}, Value {1}", start.Key, start.Data);
                start = start.Next;
            }

            Console.WriteLine("Node key = {0}, Value {1}", Tail.Key, Tail.Data);
        }
    }
}
