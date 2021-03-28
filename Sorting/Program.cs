using System;
using System.Linq;
using System.Collections.Generic;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            //int c = minimumSwaps(new int[] { 6, 5, 7, 1 });


            int[] result = bubbleSort(new int[] { 1, 5, 7, 1 }); //{ 1, 5, 7, 1 });
            bool splitable = IsSplitable(result);
            Console.WriteLine(splitable);

            int[,] t = new int[,]{
                { 5, 8, 9 }, {5, 9, 8 }, {9, 5, 8 }, {9, 8, 5 }, {8, 9, 5 }, {8, 5, 9}
            };
            Console.WriteLine("Unique Triangles: " + CointingTriangles(t));

            
            //-------------------------------------
            IsSum(new int[] { 1, 3, 1, 2, 15 }, 6);


            //------------------------------------
            int[,] prer = new int[,] {
                { 1, 0}, {2, 0 }, { 0, 5 },{5,6 }, { 3, 1 }, { 3, 2 }
            };
            Console.WriteLine("Graph: {{ 1, 0}, {2, 0 }, { 0, 5 },{5, 6}, { 3, 1 }, { 3, 2 }}");
            List<int>  dfs = MapDependencyDFS(prer, prer.GetLength(0));
            Console.WriteLine("Course Prerequisist order: ");
            foreach(int a in dfs)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            List<int> bfs = BFS(prer, 3);
            Console.WriteLine("Graph dependecy BFS: ");
            foreach (int a in bfs)
            {
                Console.Write(a + " ");
            }
            //-----------------------------------------

        }

        private static int[] SortArray(int[] arr)
        {
            int temp = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
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

        static int[] bubbleSort(int[] arr)
        {
            int cnt = 0;
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i] 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        cnt++;
                    }
                }
            }
            return arr;
        }
        public static int minimumSwaps(int[] arr)
        {
            //4 3 1 2
            //2 3 1 4 cnt =1
            //3 2 1 4 cnt = 2
            //1 2 3 4 cnt = 3
            int count = 0;
            int i = 0;
            while (i < arr.Length)
            {
                if (arr[i] != i + 1)
                {
                    while (arr[i] != i + 1)
                    {
                        int temp = 0;
                        temp = arr[arr[i] - 1]; //temp = 1
                        arr[arr[i] - 1] = arr[i]; //arr[2] = 3
                        arr[i] = temp; //arr[0] = 1
                        count++;
                    }
                }
                i++;
            }
            return count;
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

        public static bool IsSum(int[] arr, int x)
        {
            int cnt = 0;
            int total = 0;
            for(int i =0; i< arr.Length; i++)
            {
                total = total + arr[i];
                if(total == x)
                {
                    return true;
                }
                else if(total > x)
                {
                    while(total > x)
                    {
                        total = total - arr[cnt];
                        cnt++;
                    }
                    if(total == x)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //[[1,0],[2,0],[0,5],[5,6],[3,1],[3,2]]
        public static List<int> MapDependencyDFS(int[,] prer, int ncourses)
        {
            //int[] cOrder = new int[prer.GetLength(0)];
            List<int> cOrder = new List<int>(prer.GetLength(0));
            for (int i=0;i< prer.GetLength(0); i++)
            {
                int second = prer[i,0];
                int first = prer[i,1];
                Stack<int> dependency = new Stack<int>();
                //dependency = checkDependency(i + 1, first, prer, ncourses);
                checkDependencyRec(i + 1, first, prer, ncourses,dependency);
                foreach (int a in dependency)
                {
                    if(!cOrder.Contains(a))
                        cOrder.Add(a);
                }
                if (!cOrder.Contains(first))
                    cOrder.Add(first);
                if (!cOrder.Contains(second))
                    cOrder.Add(second);
            }
            Console.WriteLine(cOrder.Count == ncourses ? true : false);
            return cOrder;
        }
        
        //[[1,0],[2,0],[0,5],[5,6],[3,1],[3,2]]
        private static Stack<int> checkDependency(int index, int depe,int[,] prer, int n)
        {
            int result = -1;
            Stack<int> dependency = new Stack<int>();
            while (index <= n - 1)
            {
                if (prer[index, 0] == depe)
                {
                    result = prer[index, 1];
                    dependency.Push(result);
                    depe = result;
                    index += 1; 
                }
                else
                {
                    index += 1;
                }
            }
            return dependency;
        }

        //[[1,0],[2,0],[0,5],[5,6],[3,1],[3,2]]
        private static void checkDependencyRec(int index, int depe, int[,] prer, int n, Stack<int> dependency)
        {
            int result = -1;
            if (index <= n - 1)
            {
                if (prer[index, 0] == depe)
                {
                    result = prer[index, 1];
                    dependency.Push(result);
                    depe = result;
                    index += 1;
                    checkDependencyRec(index,depe,prer,n,dependency);
                }
                else
                {
                    index += 1;
                    checkDependencyRec(index, depe, prer, n, dependency);
                }
            }
            
        }


        //[[1,0],[2,0],[0,5],[5,6],[3,1],[3,2]]
        public static List<int> BFS(int[,] graph, int start)
        {
            bool[] visited = new bool[graph.GetLength(0)];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            List<int> cOrder = new List<int>(graph.GetLength(0));
            cOrder.Add(start);
            ProcessBFS(graph, new List<int>() { start }, cOrder,visited) ;
            return cOrder;
        }
        private static void ProcessBFS(int[,] graph, List<int> edges,List<int> bfs, bool[] visited)
        {
            List<int> newedges = new List<int>();
            
            foreach(int i in edges)
            {
                for(int j = 0; j < graph.GetLength(0); j++)
                {
                    if (!visited[j])
                    {
                        if (graph[j, 0] == i)
                        {
                            visited[j] = true;
                            if (!bfs.Contains(graph[j, 1]))
                            {
                                bfs.Add(graph[j, 1]);
                                newedges.Add(graph[j, 1]);
                            }
                        }
                    }
                }
            }

            if (newedges.Count > 0)
            {
                ProcessBFS(graph, newedges, bfs,visited);
            }

        }

        //[[1,0],[2,0],[0,5],[5,6],[6,6],[3,1],[3,2]]
        public static List<int> DFS(int[,] graph, int start)
        {
            bool[] visited = new bool[graph.GetLength(0)];
            for (int i = 0; i < visited.Length; i++)
                visited[i] = false;

            List<int> cOrder = new List<int>(graph.GetLength(0));
            for (int i = 0; i < visited.Length; i++)
            {
                ProcessDFS(graph, graph[i, 0], cOrder, visited);
            }
            return cOrder;
        }
        private static void ProcessDFS(int[,] graph, int edge, List<int> dfs, bool[] visited)
        {
            if(!dfs.Contains(edge))
            {
                dfs.Add(edge);
            }
                

                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    if (!visited[j])
                    {
                        if (graph[j, 0] == edge)
                        {
                            visited[j] = true;
                            ProcessDFS(graph, graph[j, 1], dfs, visited);
                        }
                    }
                }  
        }


    }
}
