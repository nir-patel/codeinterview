using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace HashMap
{
    class Solution
    {

        // Complete the checkMagazine function below.
        static void checkMagazine(string[] magazine, string[] note)
        {
   
            int hashsize = magazine.Length + 1;
            string[] HashTable = new string[hashsize];
            int index = 0;

            string m = string.Empty;
            for (int i = 0; i < magazine.Length; i++)
            {
                m = magazine[i];
                index = HashFun(m, hashsize);
                while (HashTable[index] != null)// || HashTable[index] != string.Empty)
                {
                    index = (index + 1) % hashsize;
                }
                HashTable[index] = m;
            }

            bool result = true;
            string n = string.Empty;
            for (int i = 0; i < note.Length; i++)
            {
                n = note[i];
                index = HashFun(n, hashsize);
                while(HashTable[index] != n && HashTable[index] != null)
                {
                    index = (index + 1) % hashsize;
                }
                if(HashTable[index] != n)
                {
                    result = false;
                    break;
                }
                
            }
            if (result)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static int HashFun(string s, int hashsize)
        {
            //int hashsize = HashTable.Length;
            int index = 0;
            int total = 0;
            char[] cArray = s.ToCharArray();

            foreach (char c in cArray)
            {
                total = total + (int)(c - 'a');
            }
            index = total % hashsize;
            
            return index;
        }


        public static int AnagramPairs(string s)
        {
            int cnt = 0;
            //abba
            Dictionary<int, int> Frequencetable = new Dictionary<int, int>();
            int index = -1;
            for(int k = s.Length; k>=1; k--)
            {
                index++;
                for (int i = 1; i<= k; i++)
                {
                    string temp = "";
                    int jj = index;
                    for(int j=0; j < i; j++)
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
            foreach(char c in ca)
            {
                total += (int)(c - 'a') + 1;
            }
            return total ;
        }


        static void checkMagazine1(string[] magazine, string[] note)
        {
            var cntMag = GetDictionary(magazine);
            var cntNote = GetDictionary(note);
            bool result = true;
            foreach (var kvp in cntNote)
            {
                //cntMag.TryGetValue(kvp.Key,out int count);
                if (!cntMag.ContainsKey(kvp.Key))
                {
                    result = false;
                    break;
                }
                int mc = cntMag[kvp.Key];
                if (mc < kvp.Value)
                {
                    result = false;
                    break;
                }
            }
            if (result)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static Dictionary<string, int> GetDictionary(string[] arr)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string s in arr)
            {
                if (dic.ContainsKey(s))
                {
                    dic[s] += 1;
                }
                else
                {
                    dic.Add(s, 0);
                }
            }
            return dic;
        }


        static void Main(string[] args)
        {
            //string[] mn = Console.ReadLine().Split(' ');

            //int m = Convert.ToInt32(mn[0]);

            //int n = Convert.ToInt32(mn[1]);

            Console.WriteLine(AnagramPairs("ifailuhkqq"));

            string[] magazine = { "give", "me", "one", "grand", "today", "night" };

            string[] note = { "give", "one", "grand", "today" };

            checkMagazine(magazine, note);
        }
    }
}
