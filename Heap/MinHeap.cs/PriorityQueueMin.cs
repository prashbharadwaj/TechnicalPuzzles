using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalPuzzles
{   
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

        public void Insert(T value)
        {
            CheckCapacity();
            data[currentIndex++] = value;
            SwimUp();
        }

        public T RemoveMin()
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

        public bool IsEmpty()
        {
            return this.currentIndex == 1;
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
            else if (currentIndex <= data.Length/4)
            {
                newData = new T[data.Length/2];
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
            while (n > 1)
            {
                if (data[n/2].CompareTo(data[n]) > 0)
                {
                    Swap(n / 2, n);
                }

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
