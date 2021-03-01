using System;
using System.Collections.Generic;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] result = SortArray(new int[] { 1, 5, 7, 1 });
            bool splitable = IsSplitable(result);
            Console.WriteLine(splitable);

            int[,] t = new int[,]{
                { 5, 8, 9 }, {5, 9, 8 }, {9, 5, 8 }, {9, 8, 5 }, {8, 9, 5 }, {8, 5, 9}
            };
            Console.WriteLine("Unique Triangles: " + CointingTriangles(t));

        }

        private static int[] SortArray(int[] arr)
        {
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }

        private static bool IsSplitable(int[] arr)
        {
            int l = 0;
            int r = arr.Length - 1;
            int lc = arr[l], rc = arr[r];
            while(l <= r)
            {
               
                if (lc == rc)
                {
                    //l is the split index
                    return true;
                }
                else if (lc < rc)
                {
                    l++;
                    lc = lc + arr[l];
                }
                else if (lc > rc)
                {
                    r--;
                    rc = rc + arr[r];
                }
                
            }
            return false;
        }



        private static int CointingTriangles(int[,] t)
        {
       
            int total = 0;
            int[] sums = new int[t.GetLength(0)];

            for(int i = 0; i< t.GetLength(0); i++)
            {
                total = 0;
                for(int j=0; j< t.GetLength(1); j++)
                {
                    total = total + t[i,j];
                }
                sums[i] = total;
            }


            return checkuniqueT(sums);
        }

        private static int checkuniqueT(int[] sums)
        {
            int length = sums.Length;
            int cnt = 0;
            for (int i = 0; i < sums.Length; i++)
            {
                for (int j = i + 1; j < sums.Length; j++)
                {
                   if(sums[i] == sums[j])
                    {
                        cnt++;
                        break;
                    }
                }
            }
            return (length - cnt);
        }
        private static int checkuniqueT1(int[] sums)
        {
            int length = sums.Length;
            int cnt = 0;
            List<int> tl = new List<int>();
            for (int i = 0; i < sums.Length; i++)
            {
                if (tl.Contains(sums[i]))
                {
                    cnt++;
                }
                else
                {
                    tl.Add(sums[i]);
                }
            }
            return (length - cnt);
        }


    }
}
