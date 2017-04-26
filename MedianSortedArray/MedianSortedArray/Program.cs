using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] {1, 2};
            int[] arr2 = new int[] { 3, 4 };

            FindMedianSortedArrays2(arr1, arr2);
        }

        private static double FindMedianOfSingleArray(int[] arr)
        {
            double median = 0.0;
            if (arr.Length == 1)
            {
                return arr[0];
            }

            bool even = arr.Length % 2 == 0 ? true : false;
            int mid = arr.Length / 2;
            if (even)
            {
                int val1 = arr[mid - 1];
                int val2 = arr[mid];
                median = (double)(val1 + val2) / 2;
            }
            else
            {
                median = arr[mid];
            }

            return median;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1 == null || nums2 == null)
                return 0.0;
            if (nums1.Length == 0 && nums2.Length == 0)
            {
                return 0.0;
            }

            if (nums1.Length == 0 && nums2.Length == 1)
            {
                return nums2[0];
            }

            if (nums2.Length == 0 && nums1.Length == 1)
            {
                return nums1[0];
            }

            if (nums1.Length == 1 && nums2.Length == 1)
            {
                return nums1[0] + nums2[0] / 2;
            }

            int totalLength = nums1.Length + nums2.Length;
            int midCount = totalLength / 2;
            bool isEven = false;
            if (totalLength % 2 == 0)
            {
                isEven = true;
            }

            // Handle the case where only one array has values
            if (nums1.Length == 0 || nums2.Length == 0)
            {
                int[] arr = nums1.Length == 0 ? nums2 : nums1;
                return FindMedianOfSingleArray(arr);
            }

            double median = -1.0;
            int indx1 = 0;
            int indx2 = 0;
            int currCount = 1;

            // If the count is 3
            if (currCount == midCount)
            {
                if (nums1[indx1] > nums2[indx2] && indx1 < nums1.Length - 1)
                {
                    median = nums1[indx1];
                }
                else if (nums1[indx1] > nums2[indx2] && indx1 == nums1.Length - 1)
                {
                    median = nums2[indx2 + 1] < nums1[indx1] ? nums2[indx2 + 1] : nums1[indx1];
                }
                else if (nums2[indx2] > nums1[indx1] && indx2 < nums2.Length - 1)
                {
                    median = nums2[indx2];
                }
                else
                {
                    median = nums1[indx1 + 1] < nums2[indx2] ? nums1[indx1 + 1] : nums2[indx2];
                }

                return median;
            }

            if (currCount == midCount - 1 && !isEven)
            {
                median = nums1[indx1] > nums2[indx2] ? nums1[indx1] : nums2[indx2];
            }

            int iterVal = -1;
            while (indx1 < nums1.Length && indx2 < nums2.Length)
            {
                if (nums1[indx1] > nums2[indx2])
                {
                    indx2++;
                    if (indx2 >= nums2.Length)
                    {
                        continue;
                    }

                    iterVal = nums2[indx2];
                }
                else if (nums1[indx1] < nums2[indx2])
                {
                    indx1++;
                    if (indx1 >= nums1.Length)
                    {
                        continue;
                    }

                    iterVal = nums1[indx1];
                }
                else
                {
                    int indx1Val = -1;
                    int indx2Val = -1;

                    // they are equal - check the next ones
                    if ((indx1 + 1) < nums1.Length)
                    {
                        indx1Val = nums1[indx1 + 1];
                    }

                    if ((indx2 + 1) < nums2.Length)
                    {
                        indx2Val = nums2[indx2 + 1];
                    }

                    if (indx2Val > indx1Val && indx1Val != -1)
                    {
                        indx1++;
                        if (indx1 > nums1.Length)
                        {
                            continue;
                        }
                        iterVal = nums1[indx1];
                    }
                    else if (indx1Val == -1)
                    {
                        indx2++;
                        if (indx2 > nums2.Length)
                        {
                            continue;
                        }
                        iterVal = nums2[indx2];
                    }
                    else if (indx2Val < indx1Val && indx2Val != -1)
                    {
                        indx2++;
                        if (indx2 > nums2.Length)
                        {
                            continue;
                        }
                        iterVal = nums2[indx2];
                    }
                    else
                    {
                        indx1++;
                        if (indx1 > nums1.Length)
                        {
                            continue;
                        }

                        iterVal = nums1[indx1];
                    }
                }

                if (currCount == midCount - 1)
                {
                    median = iterVal;
                }
                else if (currCount == midCount)
                {
                    if (isEven)
                    {
                        median = (median + iterVal) / 2;
                    }
                    else
                    {
                        median = iterVal;
                    }

                    break;
                }

                currCount++;
            }

            if (median == -1.0 && (indx1 < nums1.Length || indx2 < nums2.Length))
            {
                while (indx1 < nums1.Length)
                {
                    if (currCount == midCount - 1)
                    {
                        median = nums1[indx1];
                    }
                    else if (currCount == midCount)
                    {
                        if (isEven)
                        {
                            median = (median + nums1[indx1]) / 2;
                        }
                        else
                        {
                            median = nums1[indx1];
                        }

                        break;
                    }

                    indx1++;
                    currCount++;
                }

                while (indx2 < nums2.Length)
                {              
                    if (currCount == midCount - 1)
                    {
                        median = nums2[indx2];
                    }
                    else if (currCount == midCount)
                    {
                        if (isEven)
                        {
                            median = (median + nums2[indx2]) / 2;
                        }
                        else
                        {
                            median = nums2[indx2];
                        }

                        break;
                    }

                    indx2++;
                    currCount++;
                }
            }

            return median;
        }

        public static double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            int total = nums1.Length + nums2.Length;
            if (total % 2 == 0)
            {
                return (findKth(total / 2 + 1, nums1, nums2, 0, 0) + findKth(total / 2, nums1, nums2, 0, 0)) / 2.0;
            }
            else {
                return findKth(total / 2 + 1, nums1, nums2, 0, 0);
            }
        }

        public static int findKth(int k, int[] nums1, int[] nums2, int s1, int s2)
        {
            if (s1 >= nums1.Length)
                return nums2[s2 + k - 1];

            if (s2 >= nums2.Length)
                return nums1[s1 + k - 1];

            if (k == 1)
                return Math.Min(nums1[s1], nums2[s2]);

            int m1 = s1 + k / 2 - 1;
            int m2 = s2 + k / 2 - 1;

            int mid1 = m1 < nums1.Length ? nums1[m1] : int.MaxValue;
            int mid2 = m2 < nums2.Length ? nums2[m2] : int.MaxValue;

            if (mid1 < mid2)
            {
                return findKth(k - k / 2, nums1, nums2, m1 + 1, s2);
            }
            else {
                return findKth(k - k / 2, nums1, nums2, s1, m2 + 1);
            }
        }

        public static double FindMedianSortedArrays3(int[] A, int[] B)
        {
            int m = A.Length;
            int n = B.Length;

            if ((m + n) % 2 != 0) // odd
                return (double)findKth(A, B, (m + n) / 2, 0, m - 1, 0, n - 1);
            else { // even
                return (findKth(A, B, (m + n) / 2, 0, m - 1, 0, n - 1)
                    + findKth(A, B, (m + n) / 2 - 1, 0, m - 1, 0, n - 1)) * 0.5;
            }
        }

        public static int findKth(int[] A, int[] B, int k,
            int aStart, int aEnd, int bStart, int bEnd)
        {

            int aLen = aEnd - aStart + 1;
            int bLen = bEnd - bStart + 1;

            // Handle special cases
            if (aLen == 0)
                return B[bStart + k];
            if (bLen == 0)
                return A[aStart + k];
            if (k == 0)
                return A[aStart] < B[bStart] ? A[aStart] : B[bStart];

            int aMid = aLen * k / (aLen + bLen); // a's middle count
            int bMid = k - aMid - 1; // b's middle count

            // make aMid and bMid to be array index
            aMid = aMid + aStart;
            bMid = bMid + bStart;

            if (A[aMid] > B[bMid])
            {
                k = k - (bMid - bStart + 1);
                aEnd = aMid;
                bStart = bMid + 1;
            }
            else {
                k = k - (aMid - aStart + 1);
                bEnd = bMid;
                aStart = aMid + 1;
            }

            return findKth(A, B, k, aStart, aEnd, bStart, bEnd);
        }

    }
}
