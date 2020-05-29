using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Amazon coding challenge
Excited Scooby
Scooby and all of his friends have gathered for a party. There are N friends present. Scooby is really happy to see all of his friends in one place and is excited to greet them. 
All N friends are seated in a circle, and are numbered from 0 to N-1. Scooby is initially sitting beside the Ath friend. After greeting one friend, he goes clockwise to the Bth next friend, sits next to him and greets him. He repeats this till he returns to the Ath friend. 
In his excitement, it is possible that Scooby misses out on greeting some friends. Your job is to find the number of friends (including A) that Scooby will have greeted before reaching back to A.
Input:
The first line contains T, the number of test cases.
Each of the next T lines contain three space-separated integers, the values of A, B and N for that test case.
Output:
For each test case, output the number of friends that Scooby will have greeted before reaching back to A.
Constraints:
1 ≤ T ≤ 100000
1 ≤ N ≤ 1015
0 ≤ B ≤ 1015
0 ≤ A < N
SAMPLE INPUT
  

1
1 1 5
*/

namespace CountScoobyGreetedFriends
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // Sample code to perform I/O:

            name = Console.ReadLine();                  // Reading input from STDIN
            Console.WriteLine("Hi, {0}.", name);        // Writing output to STDOUT

            // Warning: Printing unwanted or ill-formatted data to output will cause the test cases to fail
            */

            // Write your code here
            string input = Console.ReadLine();
            int tests = Int32.Parse(input);
            long upperLimit = (long)Math.Pow(10, 15);
            while (tests > 0)
            {

                input = Console.ReadLine();
                string[] values = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length == 3)
                {
                    int startIndex = Int32.Parse(values[0]);
                    int increment = Int32.Parse(values[1]);
                    int numFriends = Int32.Parse(values[2]);
                    if (numFriends < 0 || numFriends > upperLimit)
                    {
                        tests--;
                        continue;
                    }

                    if (increment < 0 || increment > upperLimit)
                    {
                        continue;
                    }

                    if (startIndex >= 0 && startIndex < numFriends)
                    {
                        int greetedFriends = 1;
                        int nextFriend = (startIndex + increment) % numFriends;
                        while (nextFriend != startIndex)
                        {
                            greetedFriends++;
                            nextFriend = (nextFriend + increment) % numFriends;
                        }

                        Console.WriteLine("{0}", greetedFriends);
                    }
                }

                tests--;
            }

            Console.Read();
        }
    }
}
