using System;
using System.Collections;
using System.Collections.Generic;

namespace Binary_Tree
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
        /// <summary> Creates a constructor with a value of 0. </summary>
        public Node()
        {
            value = 0;
            left = null;
            right = null;
        }
        /// <summary> Creates a constructor with an inputted value. </summary>
        /// <param name="val">Inputted integer used as the value for the constructor. </param>
        public Node(int val)
        {
            value = val;
            left = null;
            right = null;
        }
    }
    class BinaryTree
    {
        public Node root;
        /// <summary> Creates a binary tree with a root node equal to null. </summary>
        public BinaryTree() { root = null; }
        /// <summary> Returns the value of the root of the binary tree. </summary>
        /// <returns> Node called root. </returns>
        public Node ReturnRoot() { return root; }
        /// <summary> Inserts a new node into the binary tree. </summary>
        /// <param name="val"></param>
        public void InsertNode(int val)
        {
            Node nodeNew = new Node(val);
            if (root == null) { root = nodeNew; }
            else
            {
                Node current = root;
                while (true)
                {
                    if (val < current.value)
                    {
                        if (current.left == null) { current.left = nodeNew; break; }
                        else { current = current.left; }
                    }
                    else
                    {
                        if (current.right == null) { current.right = nodeNew; break; }
                        else { current = current.right; }
                    }
                }
            }
        }
        /// <summary> Performs a preorder traversal of the binary tree starting from the inputted node. </summary>
        /// <param name="root"> Node value that the traversal starts from. </param>
        public void Preorder(Node root)
        {
            if (root == null) { return; }
            else
            {
                Console.WriteLine(root.value + " ");
                Preorder(root.left);
                Preorder(root.right);
            }
        }
        /// <summary> Performs an inorder traversal of the binary tree starting from the inputted node. </summary>
        /// <param name="root"> Node value that the traversal starts from. </param>
        public void Inorder(Node root)
        {
            if (root == null) { return; }
            else
            {
                Inorder(root.left);
                Console.WriteLine(root.value + " ");
                Inorder(root.right);
            }
        }
        /// <summary> Performs a postorder traversal of the binary tree starting from the inputted node. </summary>
        /// <param name="root"> Node value that the traversal starts from. </param>
        public void Postorder(Node root)
        {
            //Start from the Root
            if (root == null) { return; }
            else
            {
                Postorder(root.left);
                Postorder(root.right);
                Console.WriteLine(root.value + " ");
            }
        }
        /// <summary> Checks to see whether the inputted Node is in the inputted list. </summary>
        /// <param name="node"> Node called node that is to be searched for in the list. </param>
        /// <param name="Visited"> List called Visited which contains all visited Nodes. </param>
        /// <returns> A boolean answer to whether the node is inside of the inputted list. </returns>
        public Boolean InVisited(Node node, List<Node> Visited)
        {
            if (Visited == null) { return false; }
            foreach (Node item in Visited)
            {
                if (item == node) { return true; }
            }
            return false;
        }
        /// <summary> Performs a depth-first search on the binary tree to find the inputted value. </summary>
        /// <param name="node"> Node called node that is the root of the tree. </param>
        /// <param name="desirable"> Int value that is what the method is searching for. </param>
        /// <returns> A string saying whether the desired node is inside of the tree. </returns>
        public String DepthFirstSearch(Node node, int desirable)
        {
            String path = "";
            Node root = node;
            Stack<Node> stack = new Stack<Node>();
            List<Node> Visited = new List<Node>();
            while (stack != null && root != null)
            {
                if (root.value == desirable)
                {
                    stack.Push(root);
                    foreach (Node stacking in stack) { path = stacking.value + ", " + path; }
                    path = "The path to the value " + desirable + " is: " + path;
                    return (path.Trim(',', ' '));
                }
                if ((InVisited(root, Visited) == false) && (root.left != null))
                {
                    stack.Push(root);
                    Visited.Add(root);
                    root = root.left;
                }
                else if ((InVisited(root, Visited) == false) && (root.right != null))
                {
                    stack.Push(root);
                    Visited.Add(root);
                    root = root.right;
                }
                else if ((InVisited(root, Visited) == true) && (root.right != null) && (InVisited(root.right, Visited) == false))
                {
                    stack.Push(root);
                    Visited.Add(root);
                    root = root.right;
                }
                else if (InVisited(root.right, Visited) == true && stack.Count == 0)
                {
                    stack = null;
                }
                else if (InVisited(root.right, Visited) == true) 
                {
                    root = stack.Pop();
                }
                else
                {
                    Visited.Add(root);
                    root = stack.Pop();
                }
                Console.WriteLine(root.value);
            }
            return ("The value " + desirable + " is not in the tree.");
        }
        /// <summary>  Performs a breadth-first search on the binary tree to find the inputted value. </summary>
        /// <param name="node"> Node called node that is the root of the tree. </param>
        /// <param name="desirable"> Int value that is what the method is searching for. </param>
        public void BreadthFirstSearch(Node node, int desirable)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);
            bool found = false;
            while (q.Count > 0)
            {
                Node newnode = q.Dequeue();
                Console.WriteLine(newnode.value);
                if (newnode.value == desirable)
                {
                    found = true;
                    Console.WriteLine("The value " + desirable + " is in the tree.");
                    break;
                }
                if (newnode.left != null)
                {
                    q.Enqueue(newnode.left);
                }
                if (newnode.right != null)
                {
                    q.Enqueue(newnode.right);
                }
            }
            if (found == false)  { Console.WriteLine("The value " + desirable + " is not in the tree."); }
        }
        /// <summary> Performs a recursion search on the binary tree to find the inputted value. </summary>
        /// <param name="node"> Node called node that is the root of the tree. </param>
        /// <param name="desirable"> Int value that is what the method is searching for. </param>
        public void RecursionSearch(Node node, int desirable)
        {
            if (node == null) { return; }
            if (node.value == desirable) { Console.WriteLine("The value " + desirable + " is in the tree."); return; }
            else
            { 
                Console.WriteLine(node.value + " ");
                RecursionSearch(node.left, desirable);
                RecursionSearch(node.right, desirable);
                return;
            }
            Console.WriteLine("The value " + desirable + " is not in the tree.");
        }
        class Program
        {
            static void Main(string[] args)
            {
                // Creating the tree
                BinaryTree myTree = new BinaryTree();
                int[] values = new int[12] { 25, 15, 26, 13, 22, 30, 20, 23, 28, 33, 16, 17 };
                foreach (int i in values) { myTree.InsertNode(i); }
                Node root = myTree.ReturnRoot();

                // Part 1 - Depth-First Traversals
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Inorder Traversal");
                myTree.Inorder(root);

                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Preorder Traversal");
                myTree.Preorder(root);
                
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Postorder Traversal");
                myTree.Postorder(root);
                
                Console.WriteLine("---------------------------------------------------------------------------");
                // Part 2 - Searching For A Value Using Depth-First
                Console.WriteLine("Depth First Search For The Value 20");
                Console.WriteLine( myTree.DepthFirstSearch(root, 20));
                
                Console.WriteLine("---------------------------------------------------------------------------");
                // Part 3 - Searching For A Value Using Breadth-First
                Console.WriteLine("Breadth First Search For The Value 30");
                myTree.BreadthFirstSearch(root, 30);
                
                Console.WriteLine("---------------------------------------------------------------------------");
                // Part 4 - Searching For A Value Using Recursion
                Console.WriteLine("Recursion Search For The Value 20");
                myTree.RecursionSearch(root, 20);
                
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("Recursion Search For The Value 30");
                myTree.RecursionSearch(root, 30);
                Console.WriteLine("---------------------------------------------------------------------------");
            }
        }
    }
}
