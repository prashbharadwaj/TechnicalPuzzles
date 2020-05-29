using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boggle
{
    class Program
    {
        const int M = 3;
        const int N = 3;

        // Create a static dictionary
        static HashSet<string> DictionaryWords = new HashSet<string>() { "GEEKS", "FOR", "QUIZ", "GO" };
        static bool IsWord(string word)
        {
            return DictionaryWords.Contains(word);
        }

        static void Main(string[] args)
        {
            char[,] boggle = new char[M,N] {
                                { 'G', 'I', 'Z'},
                                { 'U', 'E', 'K'},
                                { 'Q', 'S', 'E'}
                              };

            bool[,] isVisited = new bool[M, N]
            {
                {false, false, false },
                {false, false, false },
                {false, false, false }
            };

            StringBuilder gameString = new StringBuilder(M * N);
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    boggleHelper(boggle, isVisited, i, j, gameString);
                }
            }

            Console.ReadLine();
        }

        static bool IsValidMove(int i, int j, bool[,] isVisited)
        {
            if (i < 0 || j < 0 || i >= M || j >= N)
            {
                return false;
            }

            if (isVisited[i, j])
            {
                return false;
            }

            return true;
        }

        static void boggleHelper(char[,] boggle, bool[,] isVisited, int i, int j, StringBuilder gameString)
        {
            if (i >= M || j >= N)
                return;

            char ch = boggle[i, j];
            gameString.Append(ch);
            isVisited[i, j] = true;
            if (IsWord(gameString.ToString()))
            {
                Console.WriteLine("{0}", gameString.ToString());
            }

            // Make next moves
            for (int x = i -1; x <= i+1; x++)
            {
                for (int y = j-1; y <= j+1; y++)
                {
                    if (IsValidMove(x, y, isVisited))
                    {
                        boggleHelper(boggle, isVisited, x, y, gameString);
                    }
                }
            }

            // back track
            isVisited[i, j] = false;
            gameString.Remove(gameString.Length - 1, 1);
        }
    }
}
