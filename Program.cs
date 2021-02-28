using System;
using System.Collections.Generic;


namespace CodeInterview
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("***********OutPut***********");

            int[] v = {6};//{ 5, 7, 1, 2, 8, 4, 3 };
            int[] test = {1,5,3,3,3};//{ 3, 20, 1, 2, 7 };
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

        }

        private static bool FindSumOfTwo(int[] test, int v)
        { 
            List<int> result = new List<int>();
            int cnt = 0;
            foreach(int a in test)
            {
                if(result.Contains(v - a))
                {
                    cnt++;
                    //return true;
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
            for(int i=0; i<x.GetLength(0); i++) //row
            {
                for(int j=0; j< x.GetLength(1); j++) //column
                {
                    string a = x[i,j].ToString();
                    if (j !=  x.GetLength(1) -1)
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
                    if(val == 0 && !colList.Contains(j))
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
        private static void ZeroOutRow(int row,int[,] x)
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

        
    }
}
