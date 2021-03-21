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

namespace FrequencyQuery
{


    class Solution
    {

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

                if (linec && frequencymap["/*"] == 0 )
                {

                    if(linei == 0)
                    {
                        allow = false;
                    }
                    if(blockc && blocki == 0)
                    {
                        //do nothing
                    }
                    if(blockc && linei < blocki)
                    {
                        allow = false;
                    }
                    if(linei > 0)
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


        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //int q = Convert.ToInt32(Console.ReadLine().Trim());

            //List<List<int>> queries = new List<List<int>>();

            //for (int i = 0; i < q; i++)
            //{
            //    queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            //}

            //List<int> ans = freqQuery(queries);

            //Console.WriteLine(String.Join("\n", ans));



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

            Console.Clear();
        }
    }

}
