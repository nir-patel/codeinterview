﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayExample
{

    public class Crab
    {
        public virtual void Display()
        {
            Console.WriteLine( "Crab clap");
        }
    }

    public class CoCoCrab : Crab
    {
        public CoCoCrab(string name, int id)
        {

        }
        public override void Display()
        {
            Console.WriteLine("CoCoCrab CLAP");
        }

        public void CoCoCrabDisplay()
        {
            Console.WriteLine("CoCoCrab Display");
        }
    }

    public class CoCoCoCrab : CoCoCrab
    {
        
        public CoCoCoCrab(string name) :base(name,1)
        {

        }

        public void Display1()
        {
            Console.WriteLine("CoCoCoCrab CLAP");
        }
    }


    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("***********OutPut***********");

            Crab c = new Crab();
            c.Display();

            CoCoCrab cc = new CoCoCrab("name",1);
            cc.Display();
            

            //cc = (Crab)c; //base class can not use to cast derive class.
            //cc.Display();

            c = (CoCoCrab)cc;
            c.Display();
            

            CoCoCoCrab ccc = new CoCoCoCrab("name");
            ccc.Display();
            ccc.Display1();
            ccc.CoCoCrabDisplay();
            


            List<List<int>> arr = new List<List<int>>();
            arr.Add( new List<int>() {-10,-20,0,2,10 });
            arr.Add(new List<int>() { 1,2,5,1,3,4 });
            arr.Add(new List<int>() { -1, -5, 0,0,3,1 });
            
            minpositiveint(arr);

            Roadslength(new List<int>() {5,1,6,1,3 });
            int[] v = { 6 };//{ 5, 7, 1, 2, 8, 4, 3 };
            int[] test = { 1, 5, 3, 3, 3 };//{ 3, 20, 1, 2, 7 };
            for (int i = 0; i < v.Length; i++)
            {
                var result = FindSumOfTwo(test, v[i]);
                if (result)
                {
                    Console.WriteLine(v[i] + " is sum of two numbers is exist in test array");
                }
            }

            int[,] TwoDMatrix = new int[,] {
                {1, 5, 4, 9, 8},
                {6, 0, 2, 9, 8},
                {2, 4, 9, 3, 5},
                {0, 6, 8, 4, 1}
            };
            Print2DMatrix(TwoDMatrix);
            ZeroRowCol(TwoDMatrix);

            int[] result1 = MoveZeros(new int[] { 1, 10, 20, 0, 59, 63, 0, 88, 0 });
            PrintArry(result1);

            CricularArray(new int[]{0,1,2,3,4,5 },  2);
        }

        private static bool FindSumOfTwo(int[] test, int v)
        {
            List<int> result = new List<int>();
            int cnt = 0;
            foreach (int a in test)
            {
                if (result.Contains(v - a))
                {
                    cnt++;
                    return true;
                }
                else
                {
                    result.Add(a);
                }

            }
            return false;
        }

        private static void Print2DMatrix(int[,] x)
        {
            Console.WriteLine("Printing 2D Matrix");
            for (int i = 0; i < x.GetLength(0); i++) //row
            {
                for (int j = 0; j < x.GetLength(1); j++) //column
                {
                    string a = x[i, j].ToString();
                    if (j != x.GetLength(1) - 1)
                    {
                        a = a + ",";
                    }
                    Console.Write(a);
                }
                Console.WriteLine();
            }
        }
        private static void ZeroRowCol(int[,] x)
        {
            Console.WriteLine("Zero out Row and Col");
            List<int> colList = new List<int>();
            int matRow = x.GetLength(0);
            for (int i = 0; i < matRow; i++)
            {

                int matCol = x.GetLength(1);
                for (int j = 0; j < matCol; j++)
                {
                    int val = x[i, j];
                    if (val == 0 && !colList.Contains(j))
                    {
                        int rowIndex = i;
                        int colIndex = j;
                        colList.Add(colIndex);
                        ZeroOutRow(rowIndex, x);
                        ZeroOutCol(colIndex, x);
                        j = matCol;
                    }

                }
            }
            Print2DMatrix(x);
        }
        private static void ZeroOutRow(int row, int[,] x)
        {
            for (int i = 0; i < x.GetLength(1); i++)
            {
                x[row, i] = 0;
            }
        }
        private static void ZeroOutCol(int col, int[,] x)
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                x[i, col] = 0;
            }
        }


        private static int[] MoveZeros(int[] arr)
        {
            int[] result = new int[arr.Length];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    result[count] = arr[i];
                    count++;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    result[count] = arr[i];
                    count++;
                }
            }
            return result;
        }
        private static void PrintArry(int[] arr)
        {

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + ",");
            }
            Console.WriteLine();
        }

        private static void CricularArray(int[] arr, int rotate)
        {
            int maxindex = arr.Length - 1;
            int[] temp = new int[arr.Length];

            for(int i =0; i < arr.Length; i++)
            {
                if(rotate > arr.Length - 1)
                {
                    rotate = 0;
                }

                temp[i] = arr[rotate];
                rotate++;

            }
            PrintArry(temp);
        }

        public static int MaxProfit(int[] prices)
        {

            int min = -1;
            int max = -1;
            int maxprofit = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {

                if (prices[i] < prices[i + 1])
                {
                    if (min == -1)
                    {
                        min = prices[i];
                        max = prices[i + 1];
                        maxprofit = max - min;
                    }
                    if (min > prices[i])
                    {
                        min = prices[i];
                        max = -1;
                    }
                    if (max <= prices[i + 1])
                    {
                        max = prices[i + 1];
                        if (maxprofit < (max - min))
                        {
                            maxprofit = max - min;
                        }

                    }
                }

            }

            return maxprofit;


        }

        public int MaxProfitII(int[] prices)
        {

            
            int min = 0;
            int max = 0;

            int profit2 = 0;
            int total = 0;
            int j = 0;

            int profit1 = 0;

            int[] a = prices;

            for (int i = 0; i < prices.Length - 1; i++)
            {

                j = i + 1;
                if (a[i] < a[j])
                {

                    profit1 += a[j] - a[i];


                    if (profit2 == 0)
                    {
                        profit2 = a[j] - a[i];
                        total += profit2;
                        min = a[i];
                        max = a[j];
                    }
                    if (min > a[i])
                    {
                        min = a[i];
                        max = -1;
                    }
                    if (max <= a[j])
                    {

                        max = a[j];
                        if (profit2 < (max - min))
                        {
                            profit2 = max - min;
                        }

                    }

                }

            }

            return Math.Max(profit1, profit2);





        }


        public static void Roadslength(List<int> roads)
        {

            List<int> result = new List<int>();
            roads.Sort();
            //var temp = roads.ToHashSet();

            while (roads.Count > 0)
            {
                int minl = roads[0];
                
                result.Add(minl);
                roads = (from r in roads
                         where r != minl
                         select (r - minl)
                         ).ToList();

                

            }

            var query = from i in Enumerable.Range(0, 10)
                        select new { i, j = i + 1 };
            var resultSet = query.ToHashSet();


        }


        public static List<int> minpositiveint(List<List<int>> array)
        {
            List<int> result = new List<int>();



            foreach (var A in array)
            {

                A.Sort();
                HashSet<int> h = A.Where(i => i > 0).ToHashSet<int>();
                int min = 1;
                while (h.Contains(min))
                {
                    min++;
                }
                result.Add(min);

                //int temp = 0;
                //A.Sort();
                //int min = A[0];
                //for (int i = 1; i < A.Count; i++)
                //{

                //    if (A[i] < 0)
                //    {
                //        min = 0;
                //    }
                //    else
                //    {
                //        if (A[i] == min)
                //        {
                            
                //        }
                //        else if (A[i] != min + 1)
                //        {
                //            temp = min + 1;
                //        }
                //        else
                //        {
                //            min++;
                //        }
                //    }

                //}
                //if (temp == 0)
                //{
                //    temp = A[A.Count - 1] + 1;
                //}
                //result.Add(temp);
            }

            return result;

        }
    
}

}
