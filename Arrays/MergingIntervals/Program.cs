using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergingIntervals
{
    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }
        private static IntervalComparer intervalComparer = new IntervalComparer();
        public static IntervalComparer IntervalComparer
        {
            get
            {
                return intervalComparer;
            }
        }

        public override string ToString()
        {
            return string.Format("{{{0}, {1}}}", Start, End);
        }
    }

    public class IntervalComparer : IComparer<Interval>
    {
        int IComparer<Interval>.Compare(Interval x, Interval y)
        {
            return x.Start > y.Start ? 1 : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Interval int1 =  new Interval { Start = 1, End =  3 };
            Interval int2 = new Interval { Start = 2, End = 4 };
            Interval int3 = new Interval { Start = 5, End = 7 };
            Interval int4 = new Interval { Start = 6, End = 8 };

            Interval[] arr = new Interval[] { int1, int2, int3, int4 };
            MergeOverlappingIntervals(arr);

            // Insert into sorted interval
            int1 = new Interval { Start = 1, End = 2 };
            int2 = new Interval { Start = 3, End = 5 };
            int3 = new Interval { Start = 6, End =7 };
            int4 = new Interval { Start = 8, End = 10 };
            Interval int5 = new Interval { Start = 12, End = 16 };

            Interval i = new Interval { Start = 4, End = 9 };
            List<Interval> si = new List<Interval>() { int1, int2, int3, int4, int5 };
            List<Interval> mergedIntervals = InsertIntoSortedInterval(si, i);
            PrintIntervals(mergedIntervals);

            // Another sample
            int1 = new Interval { Start = 1, End = 3 };
            int2 = new Interval { Start = 6, End = 9 };
            si = new List<Interval>() { int1, int2 };
            i = new Interval { Start = 2, End = 5 };
            mergedIntervals = InsertIntoSortedInterval(si, i);
            PrintIntervals(mergedIntervals);

            Console.ReadKey();
        }

        static void PrintIntervals(List<Interval> intervals)
        {
            foreach (var i in intervals)
            {
                Console.Write(i);
                Console.Write(",");
            }

            Console.WriteLine();
        }

        static void MergeOverlappingIntervals(Interval[] iArr)
        {
            Array.Sort(iArr, Interval.IntervalComparer);
            Stack<Interval> resultStack = new Stack<Interval>();
            foreach(var i in iArr)
            {
                if (resultStack.Count == 0 || resultStack.Peek().End < i.Start)
                {
                    resultStack.Push(i);
                }
                else if (resultStack.Peek().End < i.End)
                {
                    var val = resultStack.Pop();
                    val.End = i.End;
                    resultStack.Push(val);
                }
            }

            while (resultStack.Count != 0)
            {
                Console.Write(resultStack.Pop());
                Console.Write(",");
            }

            Console.WriteLine();
        }

        static List<Interval> InsertIntoSortedInterval(List<Interval> si, Interval i)
        {
            // Binary search the interval in the list
            int low = 0;
            int high = si.Count - 1;
            int mid = 0;
            while (low < high)
            {
                mid = low + (high - low) / 2;
                if (si[mid].Start < i.Start)
                {
                    low = mid + 1;
                }
                else if (si[mid].Start > i.Start)
                {
                    high = mid - 1;
                }
                else
                {
                    break;
                }
            }

            // Find start and end points to merge
            int start = mid == 0 ? mid : mid - 1;
            Interval ib = si[start];
            if (ib.End < i.Start)
                start++;
            int end = start;
            for (int indx = start; indx < si.Count; indx++)
            {
                if (si[indx].End > i.End)
                {
                    // Handle the case where the last interval is not overlapping
                    if (si[indx].Start < i.End)
                    {
                        end = indx;
                    }

                    break;
                }

                end = indx;
            }

            // Create a merged interval
            Interval mi = new Interval();
            mi.Start = i.Start < si[start].Start ? i.Start : si[start].Start;
            mi.End = i.End > si[end].End ? i.End : si[end].End;

            // Remove and add appropriate ranges
            si.RemoveRange(start, end - start + 1);
            si.Insert(start, mi);

            return si;
        }
    }
}
