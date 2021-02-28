using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] result = SortArray(new int[] { 1,5,7,1 });
            bool splitable = IsSplitable(result);
            Console.WriteLine(splitable);
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
                    //lc is the split index
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
    }
}
