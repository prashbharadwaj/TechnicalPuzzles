using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZagPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            //var soln = new Solution();
            //string zzString = soln.Convert("ABC", 2);
            var soln = new Solution2();
            string zzString = soln.Convert("ABC", 2);
            Console.WriteLine("Converted string is {0}", zzString);
            Console.ReadKey();
        }
    }

    public class Solution2
    {
        // Best solution to follow
        public string Convert(string s, int numRows)
        {
            // Create and initialize string builders for each row
            StringBuilder[] sbArray = new StringBuilder[numRows];
            int indx = 0;
            for (; indx < numRows; indx++)
            {
                sbArray[indx] = new StringBuilder();
            }

            char[] chArray = s.ToCharArray();
            int len = chArray.Length;

            int i = 0;
            while (i < len)
            {
                // Go down till number of rows
                for (indx = 0; indx < numRows && i < len; indx++)
                {
                    sbArray[indx].Append(chArray[i++]);
                }

                // Go up from lastrow - 1 to toprow -1
                for (indx = numRows - 2; indx >= 1 && i < len; indx--)
                {
                    sbArray[indx].Append(chArray[i++]);
                }
            }

            // Consolidate everything into row 0 string builder
            for (indx = 1; indx < numRows; indx++)
            {
                sbArray[0].Append(sbArray[indx]);
            }

            return sbArray[0].ToString();
        }
    }
    public class Solution
    {
        public string Convert(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s) || numRows == 0)
            {
                return string.Empty;
            }

            char[] chArray = s.ToCharArray();
            int numColumns = 0;
            int maxElementIndex = s.Length - 1;
            bool rowC = true;
            if (numRows <= 2)
            {
                numColumns = s.Length / numRows + 1;
            }
            else
            {
                for (int idx = 0; idx < maxElementIndex;)
                {
                    if (rowC)
                    {
                        numColumns++;
                        idx += (maxElementIndex - idx) > numRows ? numRows : maxElementIndex - idx;
                        rowC = false;
                    }
                    else
                    {
                        int incr = (maxElementIndex - idx) > (numRows - 2) ? (numRows - 2) : maxElementIndex - idx;
                        numColumns += incr;
                        idx += incr;
                        rowC = true;
                    }
                }
            }

            char[,] zigZagArray = new char[numRows,numColumns];

            int j = 0;
            int currIndex = 0;
            while (j < numColumns && currIndex < chArray.Length)
            {
                int i = 0;
                for (; i < numRows && currIndex < chArray.Length; i++)
                {
                    zigZagArray[i, j] = chArray[currIndex++];
                }

                i -= 1;
                
                while (i > 1 && j < numColumns-1 && currIndex < chArray.Length)
                {
                    zigZagArray[--i, ++j] = chArray[currIndex++];
                }

                j += 1;
            }

            int chIndx = 0;
            for (int r = 0; r < numRows; r++)
            {
                for (int col = 0; col < numColumns; col++)
                {
                    if (zigZagArray[r, col] != '\0')
                    {
                        chArray[chIndx++] = zigZagArray[r, col];
                    }
                }
            }

            return new string(chArray);
        }
    }
}
