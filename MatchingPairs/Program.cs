using System;
using System.Text;
using System.Collections.Generic;

namespace MatchingPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Matching pairs: " + matchingPairs("mno", "mno"));
            //Console.WriteLine(minLengthSubstring("dcbefebce", "fd"));

            string epass = "34Ah*ck0rr0nk";
            Console.WriteLine($"Encrypted Pass: {epass}");
            Console.WriteLine($"Decrypted Pass: {decryptPassword(epass)}");

            //countFre("ababcd");
            countFrequency("ababcd");
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


        public static string decryptPassword(string str)
        {
            //34Ah*ck0rr0nk
            string nums = "123456789";
            string ABCD = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string abcd = "abcdefghijklmnopqrstuvwxyz";
;           bool rec = false;
            List<char> temp = new List<char>(str.Length);
            for (int i = 0; i < str.Length; i++)
            {

                if (nums.Contains(str[i]) && str.Contains("0"))
                {
                    temp.Add(str[i]);
                    int index = str.IndexOf("0");
                    char[] ca = str.ToCharArray();
                    ca[index] = str[i];
                    str = new String(ca);
                    str = str.Substring(i + 1);
                    rec = true;
                    break;
                }
                if(ABCD.Contains(str[i]) && abcd.Contains(str[i + 1]))
                {
                    char[] ca = str.ToCharArray();
                    ca[i] = str[i + 1];
                    ca[i + 1] = str[i];
                    str = new string(ca);
                    i++;
                }
             
            }
            if (rec)
                str = decryptPassword(str);

            if (str.Contains("*"))
                str = str.Replace("*", "");

            return str;
        }


        public static void countFre(string S)
        {
             //S = "ababcd";

            for (char c = 'a'; c <= 'z'; c++)
            {
                int frequency = 0;
                for (int i = 0; i < S.Length; i++)
                    if (S[i] == c)
                        frequency++;

                Console.WriteLine($"{c} {frequency}");
                
            }
        }

        public static int hashFunc(char c)
        {
            return (c - 'a');
        }
        public static void countFrequency(string S)
        {
            int[] Frequency = new int[26];

            for (int i = 0; i < S.Length; ++i)
            {
                int index = hashFunc(S[i]);
                Frequency[index]++;
            }

            for (int i = 0; i < 26; ++i)
                Console.WriteLine($"{(char)(i + 'a')} {Frequency[i]}");
            
        }

    }
}
