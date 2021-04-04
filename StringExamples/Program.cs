using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace StringExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Matching pairs: " + matchingPairs("mno", "mno"));

            Console.WriteLine(minLengthSubstring("dcbefebce", "fd"));

            string epass = "34Ah*ck0rr0nk";
            Console.WriteLine($"Encrypted Pass: {epass}");
            Console.WriteLine($"Decrypted Pass: {decryptPassword(epass)}");


            //countFre("ababcd");
            //countFrequency("ababcd");


            //Console.Write("Enter rotation number:");
            //int ip = int.Parse(Console.ReadLine());
            //Console.WriteLine(rotationalCipher("nirav-649", ip));


            //Console.WriteLine(ReverseWords("Nirav Patel"));

            Longestsubstring("abcdabcdabcdefg");

            Console.WriteLine(checkBrackets("{[(jhgjh)]}a+b(())"));

            sherlockAndAnagrams("ifailuhkqq");
            //a,b,b,a abba
            //ab,bb,ba
            //a,b,b
            //b,b,a

            Console.WriteLine(AnagramPairs("ifailuhkqq"));

            string[] source = new string[]
            {
                "/*Test program */",
                "int main()",
                "{ ",
                "  // variable declaration ",
                "int a, b, c;",
                "/* This is a test",
                "   multiline  ",
                "   comment for ",
                "   testing */",
                "a = b + c;", "}"
            };
            source = new string[] { "a/*comment", "line", "more_comment*/b" };
            var result = RemoveComments(source);

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
            ; bool rec = false;
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
                if (ABCD.Contains(str[i]) && abcd.Contains(str[i + 1]))
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

        private static void Longestsubstring(string str)
        {
            // abcdedkiuytreml
            string temp = string.Empty;
            Dictionary<string, int> strlookup = new Dictionary<string, int>();
            foreach (var c in str.ToCharArray())
            {

                if (!temp.Contains(c))
                {
                    temp += c;
                }
                else
                {
                    if (!strlookup.ContainsKey(temp))
                    {
                        strlookup.Add(temp, temp.Length);
                    }
                    temp = string.Empty;
                    temp += c;
                }

            }
            if (!strlookup.ContainsKey(temp))
            {
                strlookup.Add(temp, temp.Length);
            }
            string substr = strlookup.Keys.Max();
            Console.WriteLine($"Longest substring {substr}");

        }

        private static string rotationalCipher(String input, int rotationFactor)
        {

            string abcd = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "0123456789";
            int index;
            string result = "";

            foreach (char c in input.ToLower())
            {
                index = -1;
                if (abcd.Contains(c))
                {
                    index = abcd.IndexOf(c);
                    index = index + rotationFactor;
                    if (index > 25)
                    {
                        index = index - 25 - 1;
                    }
                    result = result + abcd[index];

                }
                else if (numbers.Contains(c))
                {
                    index = numbers.IndexOf(c);
                    index = index + rotationFactor;
                    if (index > 9)
                    {
                        index = index - 9 - 1;
                    }
                    result = result + numbers[index];

                }
                if (index == -1)
                {
                    result = result + c;
                }

            }
            return result;
        }

        private static string ReverseWords(string s)
        {
            string op = "";


            string[] words = s.Split(" ");
            foreach (string w in words)
            {
                for (int i = w.Length - 1; i >= 0; i--)
                {
                    op = op + w[i];
                }
                op = op + " ";
            }

            return op;
        }

        static bool checkBrackets(string str)
        {

            if (str.Length == 0)
                return true;


            Dictionary<char, char> brackets = new Dictionary<char, char>();
            brackets.Add(')', '(');
            brackets.Add('}', '{');
            brackets.Add(']', '[');

            string symbols = "{[(";

            Stack<char> stk = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (stk.Count == 0 && brackets.ContainsKey(str[i]))
                {
                    return false;
                }

                if (brackets.ContainsKey(str[i]))
                {
                    if (stk.Peek() != brackets[str[i]])
                        return false;
                    else
                    {
                        stk.Pop();
                    }
                }
                else
                {
                    if (symbols.Contains(str[i]))
                    {
                        stk.Push(str[i]);
                    }
                }

            }

            return stk.Count == 0;
        }

        public static int AnagramPairs(string s)
        {
            int cnt = 0;
            //abba
            Dictionary<int, int> Frequencetable = new Dictionary<int, int>();
            int index = -1;
            for (int k = s.Length; k >= 1; k--)
            {
                index++;
                for (int i = 1; i <= k; i++)
                {
                    string temp = "";
                    int jj = index;
                    for (int j = 0; j < i; j++)
                    {
                        temp += s[jj];
                        jj++;
                    }
                    int key = GetKey(temp);
                    if (Frequencetable.ContainsKey(key))
                    {
                        Frequencetable[key]++;
                    }
                    else
                    {
                        Frequencetable.Add(key, 1);
                    }
                }
            }
            cnt = Frequencetable.Where(f => f.Value > 1).Count();
            return cnt;
        }
        public static int GetKey(string s)
        {
            int total = 0;
            char[] ca = s.ToCharArray();
            foreach (char c in ca)
            {
                total += (int)(c - 'a') + 1;
            }
            return total;
        }


        public static int AnagramPairsII(string s)
        {
            int cnt = 0;
            //abba
            Dictionary<int, int> Frequencetable = new Dictionary<int, int>();
            int index = -1;
            for (int k = s.Length; k >= 1; k--)
            {
                index++;
                for (int i = 1; i <= k; i++)
                {
                    string temp = "";
                    int jj = index;
                    for (int j = 0; j < i; j++)
                    {
                        temp += s[jj];
                        jj++;
                    }
                    int key = GetKey(temp);
                    if (Frequencetable.ContainsKey(key))
                    {
                        Frequencetable[key]++;
                    }
                    else
                    {
                        Frequencetable.Add(key, 1);
                    }
                }
            }
            cnt = Frequencetable.Where(f => f.Value > 1).Count();
            return cnt;
        }
        // Complete the sherlockAndAnagrams function below.
        static int sherlockAndAnagrams(string s)
        {
            Dictionary<char, int> Frequencytable = new Dictionary<char, int>();
            Dictionary<int, int> TotalFrequency = new Dictionary<int, int>();
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < s.Length; i++)
            {

                for (int j = 0; j <= s.Length - i; j++)
                {

                    Frequencytable.Clear();

                    for (int k = j; k < j + i; k++)
                    {

                        if (Frequencytable.ContainsKey(s[k]))
                        {
                            Frequencytable[s[k]] += 1;
                        }
                        else
                        {
                            Frequencytable.Add(s[k], 1);
                        }

                    }

                    sb.Clear();
                    foreach (var item in Frequencytable.OrderBy(o => o.Key))
                    {
                        sb.Append(item.Key + item.Value.ToString());
                    }
                    var key = sb.ToString().GetHashCode();
                    if (TotalFrequency.ContainsKey(key))
                    {
                        TotalFrequency[key] += 1;
                    }
                    else
                    {
                        TotalFrequency.Add(key, 1);
                    }
                }
            }
            long result = 0;
            foreach (var item in TotalFrequency)
            {
                result = result + (item.Value * (item.Value - 1) / 2);
            }
            return (int)result;
        }

        public static IList<string> RemoveComments(string[] source)
        {

            Dictionary<string, int> frequencymap = new Dictionary<string, int>();
            frequencymap.Add("/*", 0);
            List<string> result = new List<string>();

            bool allow = false;

            bool blockc = false;
            bool linec = false;
            int blocki = -1;
            int linei = -1;

            for (int i = 0; i < source.Length; i++)
            {


                string line = source[i];
                //allow = true;
                blockc = false;
                linec = false;
                blocki = -1;
                linei = -1;


                if (line.Contains("//"))
                {
                    linec = true;
                    linei = line.IndexOf("//");
                }
                if (line.Contains("/*"))
                {
                    blockc = true;
                    blocki = line.IndexOf("/*");
                }
                //------------------------

                if (linec && frequencymap["/*"] == 0)
                {

                    if (linei == 0)
                    {
                        allow = false;
                    }
                    if (blockc && blocki == 0)
                    {
                        //do nothing
                    }
                    if (blockc && linei < blocki)
                    {
                        allow = false;
                    }
                    if (linei > 0)
                    {
                        allow = true;
                        line = line.Substring(0, linei);
                    }


                }

                if (blockc)
                {


                    // /*
                    if (blocki == 0)
                    {
                        allow = false;
                        frequencymap["/*"]++;
                    } // int b; // /* hi iam
                    if (blocki > 0 && (linec && linei < blocki))
                    {

                        allow = true;
                        line = line.Substring(0, line.IndexOf("//"));

                    } // int b; /*
                    else if (blocki > 0 && frequencymap["/*"] == 0)
                    {

                        frequencymap["/*"]++;
                        allow = true;
                        line = line.Substring(0, line.IndexOf("/*"));

                    }

                }
                if (line.Contains("*/"))
                {

                    // */ int a // OR */ // int a;
                    if (linec && linei > line.IndexOf("*/"))
                    {

                        frequencymap["/*"]--;
                        if (frequencymap["/*"] == 0)
                        {
                            allow = true;
                            line = line.Substring(line.IndexOf("/*") + 2, linei);
                        }

                    }// int a; // /*
                    if (linec && linei < line.IndexOf("*/"))
                    {
                        if (frequencymap["/*"] == 0)
                        {
                            allow = true;
                            line = line.Substring(0, linei);
                        }
                    } // */ int a;
                    if (!linec && line.IndexOf("*/") == 0)
                    {
                        frequencymap["/*"]--;
                        if (frequencymap["/*"] == 0) { allow = true; }
                        if (line.Length > 2)
                        {
                            line = line.Substring(line.IndexOf("*/") + 2, line.Length - 2);
                        }
                        else
                        {
                            line = string.Empty;
                        }
                    } // /* skhfksdfh */
                    if (!linec && line.IndexOf("*/") > 0)
                    {

                        frequencymap["/*"]--;
                        if (frequencymap["/*"] == 0) { allow = true; }

                        if (line.Length - 1 > line.IndexOf("*/") + 1)
                        {

                            line = line.Substring(line.IndexOf("*/") + 2, (line.Length - line.IndexOf("*/") - 2));

                        }
                        else
                        {
                            line = string.Empty;
                        }


                    }

                }


                if (allow && !string.IsNullOrEmpty(line))
                {
                    result.Add(line);
                    allow = false;
                }

            }
            return result;

        }
    }
}
