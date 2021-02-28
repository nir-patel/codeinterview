using System;

namespace BSTExample
{
    class Program
    {
        static void Main(string[] args)
        {
            BTS bst = new BTS();
            //bst.InsertNode(50);
            //bst.InsertNode(30);
            //bst.InsertNode(20);
            //bst.InsertNode(40);
            //bst.InsertNode(70);
            //bst.InsertNode(60);
            //bst.InsertNode(80);

            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(20);
            bst.Insert(40);
            bst.Insert(70);
            bst.Insert(60);
            bst.Insert(80);

            bst.DisplayTree();
            
        }
    }

    public class Node
    {
        public int key;
        public Node right;
        public Node left;

        public Node(int item)
        {
            key = item;
            right = null;
            left = null;
        }
    }

    public class BTS
    {
        public Node root;
        public BTS()
        {
            root = null;
        }

        public void Insert(int key)
        {
            Node newnode = new Node(key) ;
            if (root == null)
            {
                root = newnode;
             
            }
            else
            {
                Node parent;
                Node current = root;
                while (true)
                {
                    parent = current;
                    if (key < current.key)
                    {
                        current = current.left;
                        if(current == null)
                        {
                            parent.left = newnode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newnode;
                            break;
                        }
                    }
                }
            }
        }

        public void InsertNode(int key)
        {
            root = InsertRec(root, key);
        }
        private Node InsertRec(Node root, int key)
        {
            if (root == null)
            {
                root = new Node(key);
                return root;
            }
            else if (key < root.key)
            {
                root.left = InsertRec(root.left, key);
            }
            else if (key > root.key)
            {
                root.right = InsertRec(root.right, key);
            }
            return root;
        }



        public void DisplayTree()
        {
            inorderRec(root);
        }
        // Inorder traversal of BST
        void inorderRec(Node root)
        {
            if (root != null)
            {
                inorderRec(root.left);
                Console.WriteLine(root.key);
                inorderRec(root.right);
            }
        }

    }
}
