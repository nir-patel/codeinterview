using System;
using System.Collections.Generic;

namespace LinkedListExample
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Clear();
           
            LinkedList<int> sentence = new LinkedList<int>(new int[] { 1, 2, 8, 9, 12, 16 });


            SingleLinkedList slist = new SingleLinkedList();
            slist.CreateList(new int[] { 1, 2, 8, 9, 12, 16 });
            Node n = slist.head;
            Console.WriteLine("Last Node: " + slist.GetLastNode().data);
            slist.PrintLinkedList(slist.head);
            Console.Write("Enter node value to Delete that node:-> ");
            var key = Console.ReadLine();
            int data = Convert.ToInt32(key);
            slist.DeleteNode(data);
            slist.PrintLinkedList(slist.head);
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
            
            Node current = new Node(0);
            for (int i = 0; i < arr.Length; i++)
            {
                Node n = new Node(arr[i]);
                if (head == null)
                {
                    head = n;
                    current = head;
                }
                else
                {
                    current.next = n;
                    current = n;
                }
            }
        }

        public Node GetLastNode()
        {
            Node n = head;
            while(n.next != null)
            {
                n = n.next;
            }
            return n;
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

        public void DeleteNode(int data)
        {
            Node current = head;
            Node previous = null;
            if(current.data == data &&current.next != null)
            {
                head = current.next;
                return;
            }
            while(current != null)
            {
                if(current.data == data)
                {
                    previous.next = current.next;
                    if(previous == null && current.next == null) // One node only
                    {
                        head = null;
                    }
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
            Node previuos = new Node(0);
            while(current.next != null)
            {
                
            }
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

}
