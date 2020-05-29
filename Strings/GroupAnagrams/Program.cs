using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution soln = new Solution();
            // string[] strA = new string[] { "eat", "tea", "tan", "ate", "nat", "bat"};
            string[] strA = new string[] {"cab", "tin", "pew", "duh", "may", "ill", "buy", "bar", "max", "doc"};
            IList<IList<string>> gAna = soln.GroupAnagrams(strA);
            Console.Read();
        }
    }

    public class AnagramKey
    {
        Dictionary<char, int> charMap;
        public Dictionary<char, int> CharMap
        {
            get
            {
                return this.charMap;
            }
        }

        internal static AnagramKeyComparer keyComparer = new AnagramKeyComparer();
        public AnagramKey(Dictionary<char, int> map)
        {
            this.charMap = map;
        }
    }

    public class AnagramKeyComparer : IEqualityComparer<AnagramKey>
    {
        public bool Equals(AnagramKey x, AnagramKey y)
        {
            if (x == null && y == null)
                return true;

            if (x == null || y == null)
                return false;

            if (x.CharMap.Keys.Count == y.CharMap.Keys.Count)
            {
                foreach(char keyX in x.CharMap.Keys)
                {
                    if (!y.CharMap.ContainsKey(keyX))
                        return false;

                    if (y.CharMap[keyX] != x.CharMap[keyX])
                        return false;
                }

                return true;
            }

            return false;
        }

        public int GetHashCode(AnagramKey obj)
        {
            int hashCode = 37;
            if (obj != null)
            {
                foreach(char key in obj.CharMap.Keys)
                {
                    hashCode += (key - 'a') * 397;
                    hashCode += obj.CharMap[key] * 397;
                }
            }

            return hashCode;
        }
    }

    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            List<IList<string>> result = new List<IList<string>>();
            if (strs == null || strs.Length == 0)
            {
                return result;
            }

            Dictionary<AnagramKey, List<string>> map = new Dictionary<AnagramKey, List<string>>(AnagramKey.keyComparer);
            foreach (var str in strs)
            {
                // Get hash code of each string
                AnagramKey aKey = GetAnagramKey(str);
                List<string> anagrams;
                if (map.ContainsKey(aKey))
                {
                    anagrams = map[aKey];
                }
                else
                {
                    anagrams = new List<string>();
                    map.Add(aKey, anagrams);
                }

                anagrams.Add(str);
            }

            foreach (List<string> values in map.Values)
            {
                result.Add(values);
            }

            return result;
        }

        public AnagramKey GetAnagramKey(string str)
        {
            AnagramKey key;
            Dictionary<char, int> map = new Dictionary<char, int>();
            char[] chArr = str.ToCharArray();
            foreach (char ch in chArr)
            {
                if (map.ContainsKey(ch))
                {
                    map[ch] += 1;
                }
                else
                {
                    map.Add(ch, 1);
                }
            }

            key = new AnagramKey(map);
            return key;
        }
    }
}
