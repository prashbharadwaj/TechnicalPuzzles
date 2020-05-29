using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerHopper
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tower = new int[] { 4, 0, 1, 2, 0 };
            bool possible = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000000; i++)
            {
                possible = TowerHopper(tower);
            }
            sw.Stop();
            Console.WriteLine(
                "The time taken to run tower hopper without memo is {0} milliseconds", 
                sw.ElapsedMilliseconds);

            string res = possible ? "possible" : "not possible";
            Console.WriteLine("It is {0} to hop across the towers", res);

            // With memo
            tower = new int[] { 4, 0, 1, 2, 0 };
            Dictionary<int, bool> hopMap = new Dictionary<int, bool>(tower.Length);
            sw.Reset();
            sw.Start();

            for (int i = 0; i < 100000000; i++)
            {
                possible = TowerHopperHelperWithMemo(tower, 0, hopMap);
            }

            sw.Stop();
            Console.WriteLine(
               "The time taken to run tower hopper with memo is {0} milliseconds",
               sw.ElapsedMilliseconds);
            res = possible ? "possible" : "not possible";
            Console.WriteLine("It is {0} to hop across the towers with memo", res);
            Console.Read();
        }

        // Another approach is to create a graph and search if it is possible to 
        // reach the end of the graph

        /*
           Use the array to figure out if end of an array can be reached.
           The max that one can hop in the array is the value at the index.
           Each index in the array is like the height of a tower at that index 
         */
        static bool TowerHopper(int[] tower)
        {
            // Dynamic programming version with and without memo
            return TowerHopperHelper(tower, 0);
        }

        static bool TowerHopperHelper(int[] tower, int index)
        {
            int maxHopValue = tower[index];
            if (maxHopValue == 0)
                return false;

            if (index + maxHopValue >= tower.Length)
                return true;

            for (int i = 1; i <= maxHopValue; i++)
            {
                if (TowerHopperHelper(tower, index + i))
                    return true;
            }

            return false;
        }

        static bool TowerHopperHelperWithMemo(int[] tower, int index, Dictionary<int, bool> hopMap)
        {
            if (hopMap.ContainsKey(index))
                return hopMap[index];

            int maxHopValue = tower[index];
            if (maxHopValue == 0)
            {
                hopMap[index] = false;
                return false;
            }

            if (index + maxHopValue >= tower.Length)
            {
                hopMap[index] = true;
                return true;
            }

            for (int i = 1; i <= maxHopValue; i++)
            {
                if (TowerHopperHelper(tower, index + i))
                {
                    hopMap[index] = true;
                    return true;
                }
            }

            hopMap[index] = false;
            return false;
        }
    }
}
