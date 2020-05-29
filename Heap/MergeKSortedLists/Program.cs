using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeKSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /**
     * Definition for singly-linked list.
     */
     public class ListNode
    {
          public int val;
          public ListNode next;
          public ListNode(int x) { val = x; }
    }
     
    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            PriorityQueueMin<HeapElement> pq = new PriorityQueueMin<HeapElement>(lists.Length);
            for (int i = 0; i < lists.Length; i++)
            {
                ListNode n = lists[i];
                if (n != null)
                {
                    HeapElement he = new HeapElement { Node = n };
                    pq.Insert(he);
                }
            }

            ListNode resultHead = null;
            ListNode resultCurr = null;
            while (!pq.IsEmpty())
            {
                var val = pq.ExtractMin();
                if (resultHead == null)
                {
                    resultHead = val.Node;
                    resultCurr = resultHead;
                }
                else
                {
                    resultCurr.next = val.Node;
                    resultCurr = resultCurr.next;
                }

                if (val.Node.next != null)
                {
                    HeapElement heapElem = new HeapElement { Node = val.Node.next };
                    pq.Insert(heapElem);
                }
            }

            return resultHead;
        }
    }

    public class HeapElement : IComparable
    {
        public ListNode Node { get; set; }

        public int CompareTo(object other)
        {
            if (other == null)
                return -1;

            HeapElement hElem = other as HeapElement;
            if (this.Node.val > hElem.Node.val)
            {
                return 1;
            }
            else if (this.Node.val < hElem.Node.val)
            {
                return -1;
            }

            return 0;
        }
    }

    public class PriorityQueueMin<T> where T : IComparable
    {
        private T[] data;
        int currentIndex;

        public PriorityQueueMin(int capacity)
        {
            data = new T[capacity];

            // Start at index 1 to keep code simple
            currentIndex = 1;
        }

        public bool IsEmpty()
        {
            return currentIndex == 1;
        }

        public void Insert(T value)
        {
            CheckCapacity();
            data[currentIndex++] = value;
            SwimUp();
        }

        public T ExtractMin()
        {
            if (currentIndex == 1)
            {
                return default(T);
            }

            // Get the top item
            T min = data[1];
            data[1] = data[currentIndex - 1];
            data[currentIndex - 1] = default(T);
            currentIndex--;
            Heapify();
            return min;
        }

        private void CheckCapacity()
        {
            T[] newData = null;
            bool updated = false;
            if (currentIndex >= data.Length)
            {
                newData = new T[data.Length * 2];
                updated = true;
            }
            else if (currentIndex <= data.Length / 4)
            {
                newData = new T[data.Length / 2];
                updated = true;
            }

            if (updated)
            {
                for (int indx = 0; indx < currentIndex; indx++)
                {
                    newData[indx] = data[indx];
                }

                data = newData;
            }
        }

        /// <summary>
        /// Go down the heap till the element at top is in its correct position
        /// </summary>
        private void Heapify()
        {
            // Start at the top element that has been replaced
            int n = 1;

            // While the heap has atleast one child
            while (n * 2 < currentIndex)
            {
                int childIndx1 = n * 2;
                int childIndx2 = n * 2 + 1;
                int smallerIndx = childIndx1;

                // Check if second child is present
                if (childIndx2 < currentIndex)
                {
                    // Get the smaller index
                    smallerIndx = data[childIndx1].CompareTo(data[childIndx2]) < 0 ? childIndx1 : childIndx2;
                }

                // If element is greater than its smaller child, swap and go down
                if (data[n].CompareTo(data[smallerIndx]) > 0)
                {
                    Swap(n, smallerIndx);
                }
                else
                {
                    // Element is in its correct position
                    break;
                }

                n = smallerIndx;
            }
        }

        private void SwimUp()
        {
            int n = currentIndex - 1;

            // Move up till parent is greater than child
            // Element at n/2 is a parent of an element at n
            while (n > 1 && data[n / 2].CompareTo(data[n]) > 0)
            {
                Swap(n / 2, n);
                n = n / 2;
            }
        }

        private void Swap(int index1, int index2)
        {
            T tmp = data[index1];
            data[index1] = data[index2];
            data[index2] = tmp;
        }
    }
}
