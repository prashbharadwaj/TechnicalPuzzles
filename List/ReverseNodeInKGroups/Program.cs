using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNodeInKGroups
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }


    //  Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null)
                return null;

            int len = GetListLength(head);
            if (k > len)
                return head;

            int iter = len / k;
            ListNode prev = null;
            ListNode next = head;

            for (int i = 0; i < iter; i++)
            {
                ListNode bNode = next;
                next = TraversekNodes(bNode, k);
                ListNode s = null;
                ListNode e = null;
                ReversekNodes(bNode, ref s, ref e, k);
                if (prev == null)
                {
                    head = s;
                }
                else
                {
                    prev.next = s;
                }

                prev = e;
            }

            if (prev != null)
            {
                prev.next = next;
            }

            return head;
        }

        public ListNode TraversekNodes(ListNode startNode, int k)
        {
            ListNode node = startNode;
            int count = 0;
            while (node != null && count < k)
            {
                node = node.next;
                count++;
            }

            return node;
        }

        public void ReversekNodes(ListNode bNode, ref ListNode s, ref ListNode e, int k)
        {
            ListNode prev = null;
            ListNode curr = bNode;
            e = bNode;
            int count = 0;
            while (curr != null && count < k)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
                count++;
            }

            s = prev;
        }

        public int GetListLength(ListNode head)
        {
            int len = 0;
            ListNode node = head;

            while (node != null)
            {
                len++;
                node = node.next;
            }

            return len;
        }
    }
}