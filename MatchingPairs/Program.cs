using System;
using System.Text;

namespace MatchingPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matching pairs: " + matchingPairs("mno", "mno"));
            //Console.WriteLine(minLengthSubstring("dcbefebce", "fd"));
        }

        private static int matchingPairs(string s, string t)
        {
            Console.WriteLine("s: " + s);
            Console.WriteLine("t: " + t);
            int count = 0;
            if (s == t)
            {
                return s.Length;
            }
            else
            {
                for (int i = 0; i < t.Length; i++)
                {
                    if (s.Length > i)
                    {
                        if (t[i] == s[i])
                        {
                            count++;
                        }
                        else
                        {
                            if (s.Contains(t[i]))
                            {
                                int j = s.IndexOf(t[i]);
                                char positionI = s[i];
                                char positionJ = s[j];

                                char[] c = s.ToCharArray();
                                c[i] = positionJ;
                                c[j] = positionI;

                                s = new String(c);
                                //s = s.Replace(positionI, '~').Replace(positionJ,positionI).Replace('~', positionJ);

                                count++;
                            }
                        }
                    }
                }
                Console.WriteLine("s after swapped: " + s);
            }
            return count;
        }


        private static int minLengthSubstring(String s, String t)
        {
          
            int maxIndex = 0;
            for (int i = 0; i < t.Length; i++)
            {
                if (s.Contains(t[i]))
                {
                    int tempIndex = s.IndexOf(t[i]);
                    if (maxIndex < tempIndex)
                    {
                        maxIndex = tempIndex;
                    }
                }
            }
            string subS = s.Substring(0, maxIndex + 1);
            Console.WriteLine("SubS: " + subS);

            Console.WriteLine("Matching pairs: " + matchingPairs(subS, t));


            


            return subS.Length;
        }
    }
}
