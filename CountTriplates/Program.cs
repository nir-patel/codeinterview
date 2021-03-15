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

namespace CountTriplates
{
    

class Solution
    {

        // Complete the countTriplets function below.
        static long countTriplets(List<long> arr, long r)
        {

            Dictionary<long, int> Totalcount = new Dictionary<long, int>();

            long total = 0;
            //for (int i = 0; i <= arr.Count - 2; i++)
            //{

            //    if (arr[i] < r || ((arr[i] % r) == 0 && ((arr[i + 1] % r) == 0 && arr[i + 1] > arr[i])))
            //    {
            //        total = arr[i] + arr[i + 1];

            //        for (int j = 0; j < arr.Count; j++)
            //        {
            //            long t2 = total;
            //            if (j != i && j != i + 1)
            //            {
            //                t2 += arr[j];
            //                if (Totalcount.ContainsKey(t2))
            //                {
            //                    Totalcount[t2] += 1;
            //                }
            //                else
            //                {
            //                    Totalcount.Add(t2, 1);
            //                }
            //            }
            //        }

            //    }
            //}
            for (int i = 0; i < arr.Count -1; i++)
            {

                //if (arr[i] < r || ((arr[i] % r) == 0 && ((arr[i + 1] % r) == 0 && arr[i + 1] > arr[i])))
                {
                    total = arr[i];

                    for (int j = 0; j < arr.Count-1; j++)
                    {
                        long t2 = total;

                        if(i != j && arr[i]  != arr[j] && arr[i] != arr[j+1])
                        {
                            t2 += arr[j] + arr[j + 1];
                            if (Totalcount.ContainsKey(t2))
                            {
                                Totalcount[t2] += 1;
                            }
                            else
                            {
                                Totalcount.Add(t2, 1);
                            }
                        }

                    }

                }
            }

            int cnt = 0;
            foreach(var item in Totalcount.Where(f => f.Value > 1))
            {
                cnt += item.Value;
            }
            return cnt;
        }

        static void Main(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            //string[] nr = Console.ReadLine().TrimEnd().Split(' ');

            //int n = Convert.ToInt32(nr[0]);

            //long r = Convert.ToInt64(nr[1]);

            List<long> arr = new List<long>() { 1, 5, 5, 25, 125 };//Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt64(arrTemp)).ToList();

            long ans = countTriplets(arr, 5);

            Console.WriteLine(ans);

            //textWriter.Flush();
            //textWriter.Close();
        }
    }
}
