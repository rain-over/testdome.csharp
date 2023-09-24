namespace testdome;

/*
 * Binary Search Tree (BST) is a binary tree where the value of each node is larger or equal to the values in all the nodes in that node's left subtree
 * and is smaller than the values in all the nodes in that node's right subtree.
 * 
 * Write a function that, efficiently checks if a given binary search tree contains a given value.
 * 
 * For example, for the following tree:
 * 
 * *n1 (Value: 1, Left: null, Right: null)                    n2
 * *n2 (Value: 2, Left: n1, Right: n3)                      /    \  
 * *n3 (Value: 3, Left: null, Right: null)                 n1    n3
 * 
 * Call to Contains(n2, 3) should return tue since a tree with root at n2 contains number 3.
 */

public class Node
{
    public int Value { get; set; }

    public Node Left { get; set; }

    public Node Right { get; set; }

    public Node(int value, Node left, Node right)
    {
        Value = value;
        Left = left;
        Right = right;
    }
}

public static class BinarySearchTree
{

    public static bool Contains(Node root, int value)
    {
        if (root == null) return false;
        if (root.Value > value)
        {
            //return root.Left != null;
            return Contains(root.Left, value);
        }
        else if (root.Value < value)
        {
            //return root.Right != null;
            return Contains(root.Right, value);
        }
        else return true;
    }

    public static void Print()
    {
        /*
        Node n1 = new Node(1, null, null);
        Node n3 = new Node(3, null, null);
        Node n2 = new Node(2, n1, n3);
        */

        Node n1 = new Node(1, null, null);
        Node n4 = new Node(4, null, null);
        Node n7 = new Node(7, null, null);
        Node n6 = new Node(6, n4, n7);
        Node n3 = new Node(3, n1, n6);
        Node n13 = new Node(1, null, null);
        Node n14 = new Node(14, n13, null);
        Node n10 = new Node(10, null, n14);
        Node n8 = new Node(8, n3, n10);

        Console.WriteLine(Contains(n8, 5));
    }
}