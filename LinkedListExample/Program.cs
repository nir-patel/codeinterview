﻿using System;
using System.Collections.Generic;

namespace LinkedListExample
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Clear();
           
            //LinkedList<int> sentence = new LinkedList<int>(new int[] { 1, 2, 8, 9, 12, 16 });


            SingleLinkedList slist = new SingleLinkedList();//1,2,8,9,12,16
            slist.CreateList(new int[] { 1, 2, 8, 4 ,9, 12, 16 });//2, 15, 8, 9, 16, 12
            slist.PrintLinkedList(slist.head);
            Console.WriteLine("Last Node: " + slist.GetLastNode().data);

            slist.ReverseOperation();

            slist.ReverseList();
            slist.PrintLinkedList(slist.head);
            Console.WriteLine("Last Node: " + slist.GetLastNode().data);

            //Console.Write("Enter node value to Delete that node:-> ");
            //var key = int.Parse(Console.ReadLine());
            //slist.DeleteNode(key);

            //slist.AddNode(10);
            //slist.PrintLinkedList(slist.head);
            //Console.WriteLine("Last Node: " + slist.GetLastNode().data);
            ////Console.WriteLine("Middle Node: " + slist.GetMiddleNode(slist.head).data);

            //slist.MergeSort(slist.head);
            //Console.WriteLine("Sorted List");
            //slist.PrintLinkedList(slist.head);
        }
    }

    public class Node
    {
        public int data;
        public Node next;
        public Node(int item)
        {
            data = item;
            next = null;
        }
    }

    public class SingleLinkedList
    {
        public Node head;

        public SingleLinkedList()
        {
            head = null;
        }

        public void CreateList(int[] arr)
        {
           
            foreach(int i in arr)
            {
                AddNode(i);
            }

        }
        public void PrintLinkedList(Node head)
        {
    
            Node n = head;
            while(n != null)
            {
                Console.Write(n.data + "->");
                n = n.next;
            }
            Console.WriteLine();
        }
        public Node GetLastNode()
        {
            if(head == null || head.next == null)
            {
                return head;
            }
            Node n = head;
            while (n.next != null)
            {
                n = n.next;
            }
            return n;
        }
        public void AddNode(int data)
        {
            if (head == null)
            {
                head = new Node(data);
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new Node(data);
            }
        }

        //------------------------------------
        public void ReverseOperation()
        {
            Node current = head;
            Node newlist = null;
            Node previous = null;
            while (current != null)
            {
                if (current.data % 2 == 0)
                {
                    newlist = Createnewlist(newlist, current.data);
                }
                else
                {
                    if(previous != null && newlist != null)
                    {
                        newlist = ReverseList1(newlist);
                        //get last node and lastnode.next = current
                        newlist.next = current;
                        previous.next = newlist;
                        newlist = null;
                        
                    }
                    previous = current;
                }
                current = current.next;
            }

        }
        private Node Createnewlist(Node newlist, int data)
        {
            if (newlist == null)
            {
                newlist = new Node(data);
            }
            else
            {
                Node current = newlist;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new Node(data);
            }
            return newlist;
        }
        private Node ReverseList1(Node head)
        {
            Node current = head;
            Node prev = null, next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
            return head;
        }
        //-----------------------------------------

        public void PushNode(int data)
        {
            Node newnode = new Node(data);
            newnode.next = head;
            head = newnode;
        }

        public Node GetMiddleNode(Node h)
        {
            if(h == null)
            {
                return h;
            }
            Node middle;
            Node fastptr = h.next;
            Node slowptr = h;

            while(fastptr != null){
                fastptr = fastptr.next;
                if(fastptr != null)
                {
                    slowptr = slowptr.next;
                    fastptr = fastptr.next;
                }
            }
            middle = slowptr;
            return middle;
        }

        public Node MergeSort(Node h)
        {
            if(h == null || h.next == null)
            {
                return h;
            }

            Node middle = GetMiddleNode(h);
            Node middleofnext = middle.next;

            middle.next = null;

            Node left = MergeSort(h);

            Node right = MergeSort(middleofnext);

            Node sortedlist = sortedMerge(left, right);
            return sortedlist;

        }

        public Node sortedMerge(Node a, Node b)
        {
            Node result = null;
            /* Base cases */
            if (a == null)
                return b;
            if (b == null)
                return a;

            /* Pick either a or b, and recur */
            if (a.data <= b.data)
            {
                result = a;
                result.next = sortedMerge(a.next, b);
            }
            else
            {
                result = b;
                result.next = sortedMerge(a, b.next);
            }
            return result;
        }

        public void DeleteNode(int data)
        {
            Node current = head;
            Node previous = null;
            if(current.data == data) //if first node match
            {
                if(current.next != null)
                {
                    head = current.next;
                }
                else
                {
                    head = null;
                }
                return;
            }
            while(current != null)
            {
                if(current.data == data)
                {
                    previous.next = current.next;
                    return;
                }
                else
                {
                    previous = current;
                    current = current.next;
                }
            }
        }

        public void ReverseList()
        {
            Node current = head;
            Node prev = null, next = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            head = prev;
        }

    }


}
