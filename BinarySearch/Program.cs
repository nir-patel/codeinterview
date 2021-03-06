﻿using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 4, 10, 40 };
            int n = arr.Length;
            int x = 10;

            int result = binarySearchR(arr, 0, n - 1, x);

            if (result == -1)
                Console.WriteLine("Element not present");
            else
                Console.WriteLine("Element found at index "
                                  + result);
        }

        static int binarySearchR(int[] arr, int l,int r, int x)
        {
            if (l <= r)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid] == x)
                    return mid;


                if (x < arr[mid])
                {
                    return binarySearchR(arr, l, mid - 1, x);
                }
                else if(x > arr[mid])
                {
                    return binarySearchR(arr, mid + 1, r, x);
                } 
            }
            return -1;
        }

        static int binarySearchI(int[] arr, int x)
        {
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                // Check if x is present at mid 
                if (arr[m] == x)
                    return m;

                // If x greater, ignore left half 
                if (arr[m] < x)
                    l = m + 1;

                // If x is smaller, ignore right half 
                else
                    r = m - 1;
            }

            // if we reach here, then element was 
            // not present 
            return -1;
        }






    }
}
