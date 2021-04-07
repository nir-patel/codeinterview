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
            int total = 0;

            foreach (char c in s.ToCharArray())
            {
                total = total + (int)(c - 'a');
            }
            return (total % hashsize);
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

        // Complete the freqQuery function below.
        static List<int> freqQuery(List<List<int>> queries)
        {

            List<int> result = new List<int>();
            Dictionary<int, int> hastable = new Dictionary<int, int>();
            foreach (List<int> line in queries)
            {

                //Console.WriteLine($"{line[0]} - {line[1]}");
                int operation = line[0];
                int value = line[1];

                bool iscontain = hastable.ContainsKey(value);

                if (operation == 1)
                {
                    if (iscontain)
                    {
                        hastable[value] += 1;
                    }
                    else
                    {
                        hastable.Add(value, 1);
                    }
                }
                else if (operation == 2)
                {
                    if (iscontain)
                    {
                        int cnt = hastable[value];
                        if (cnt > 1)
                        {
                            hastable[value] = hastable[value] - 1;
                        }
                        else if (cnt == 1)
                        {
                            hastable.Remove(value);
                        }
                    }
                }
                else if (operation == 3)
                {
                    if (hastable.ContainsValue(value))
                    {
                        result.Add(1);
                    }
                    else
                    {
                        result.Add(0);
                    }
                }

            }
            return result;
        }

        public static void TestFun()
        {
            List<int> lstint = new List<int>() { 2,4,6,9,10};
            List<string> lststr = new List<string>();// { "sdf","fhhg", "ertert"};
            int[] arrint = new int[5];


            Dictionary<string, int> dicstr = new Dictionary<string, int>();
            Dictionary<int, int> dicint = new Dictionary<int, int>();

            int n = 3;
            string m = Convert.ToString(n, 2);

            lststr.Add("ADASDS");
            lststr.Add("ADASDS");
            lststr.Add("ADASDS12");
            lststr.Add("ADASDS23");

            foreach(var str in lststr)
            {
                if (dicstr.ContainsKey(str.ToLower()))
                {
                    dicstr[str.ToLower()] += 1;
                }
                else
                {
                    dicstr.Add(str.ToLower(), 1);
                }
            }



        }

        static void Main(string[] args)
        {

            TestFun();

            string[] magazine = { "give", "me", "one", "grand", "today", "night" };

            string[] note = { "give", "one", "grand", "today" };

            //checkMagazine(magazine, note);
            checkMagazine1(magazine, note);

            //List<int> ans = freqQuery(queries);
            //Console.WriteLine(String.Join("\n", ans));


            HashTable<string> hashTable = new HashTable<string>(5);
            hashTable.Add("nirav");
            hashTable.Add("shruti");
            hashTable.Add("ruhi");
            hashTable.Add("saurabh");
            var result = hashTable.Find("ruhi1");

        }

    }

    public class HashObject<T>
    {
        public HashObject(T k)
        {
            key = k;
            values = new List<T>();
            
        }
        public T key { get; set; }
        public List<T> values { get; set; }
        
    }


    public class HashTable<T>
    {
        private int _size;
        private HashObject<T>[] _hashTable;

        public HashTable(int size)
        {
            _size = size;
            _hashTable = new HashObject<T>[_size];
        }

        private int GetIndex(T key)
        {
            int index = 0;
            index = key.GetHashCode() % _size;
            return Math.Abs(index);
        }

        public void Add(T key, T value)
        {
            int index = GetIndex(key);
            if(_hashTable[index] == null)
            {
                var hashobject = new HashObject<T>(key);
                hashobject.values.Add(value);
                _hashTable[index] = hashobject;
            }
            else
            {
                var hashobject = _hashTable[index];
                hashobject.values.Add(value);
            }
        }

        public void Add(T value)
        {
            int index = GetIndex(value);
            if (_hashTable[index] == null)
            {
                var hashobject = new HashObject<T>(value);
                hashobject.values.Add(value);
                _hashTable[index] = hashobject;
            }
            else
            {
                var hashobject = _hashTable[index];
                hashobject.values.Add(value);
            }
        }

        public T Find(T value)
        {
            T result;
            int index = GetIndex(value);
            result = _hashTable[index].values.Find(v => v.Equals(value));
            return result;
        }

        public T Find(T key, T value)
        {
            T result;
            int index = GetIndex(key);
            result = _hashTable[index].values.Find(v=> v.Equals(value));
            return result;
        }


    }


}
