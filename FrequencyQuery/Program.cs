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

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> ans = freqQuery(queries);

            Console.WriteLine(String.Join("\n", ans));

            Console.Clear();
        }
    }

}
