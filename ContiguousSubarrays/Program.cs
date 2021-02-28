using System;
using System.Collections.Generic;

namespace ContiguousSubarrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            int[] arr = { 3, 4, 1, 6, 2 };

            int[] outArr = countSubarrays(arr);
        }


        private static int[] countSubarrays(int[] arr)
        {

            int[] outarr = new int[arr.Length];
            List<int[]> csa = getSubarrays(arr);
            for(int i=0;i< arr.Length; i++)
            {
                outarr[i] = CheckCondition(arr[i], csa);
            }
            return outarr;
        }

        private static List<int[]> getSubarrays(int[] arr)
        {
            List<int[]> csa = new List<int[]>();
            int sIndex = -1;
            for (int k = arr.Length; k >= 1; k--)
            {
                sIndex++;
                int[] t;
                for (int i = 1; i <= k; i++)
                {
                    t = new int[i];
                    int jj = sIndex;
                    for (int j = 0; j < i; j++)
                    {
                        t[j] = arr[jj];
                        jj++;
                    }
                    csa.Add(t);
                }
            }

            //int[] t;
            //for (int i = 1; i <= arr.Length; i++)
            //{
            //    t = new int[i];

            //    for (int j = 0; j < i; j++)
            //    {
            //        t[j] = arr[j];
            //    }
            //    csa.Add(t);
            //}
            return csa;

        }

        private static int CheckCondition(int v, List<int[]> sa)
        {
            int count = 0;
            foreach(int[] a in sa)
            {
                
                if(v == a[0] || v == a[a.Length - 1])
                {
                    bool ismax = false;
                    for(int i=0; i< a.Length; i++)
                    {
                        if(v < a[i])
                        {
                            ismax = false;
                            break;
                        }
                        ismax = true;
                    }
                    if (ismax)
                    {
                        count++;
                    }
                }
            }
            return count;
        }





    }
}
