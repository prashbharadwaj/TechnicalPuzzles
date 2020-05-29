using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalPuzzles;
namespace MaxHeapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueueMin<int> pq = new PriorityQueueMin<int>(10);
            pq.Insert(5);
            pq.Insert(10);
            pq.Insert(24);
            pq.Insert(6);
            pq.Insert(22);
            pq.Insert(31);
            int min = pq.RemoveMin();
            while (min != 0)
            {
                Console.WriteLine("Minimum element is {0}", min);

                min = pq.RemoveMin();
            }

            Console.ReadKey();
        }
    }
}
