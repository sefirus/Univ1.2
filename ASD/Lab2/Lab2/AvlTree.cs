namespace Lab2;

public class AvlTree
{
    public class Node
    {
        public int Height { get; set; }
        public Node? Left { get; set; }
        public Node? Right { get; set; }
        public int Data { get; set; }

        public Node(int d)
        {
            Data = d;
            Height = 1;
            Left = null;
            Right = null;
        }
    }

    public Node? Root { get; set; }

    public AvlTree(Node root) => Root = root;

    private int GetHeight(Node? node) => node?.Height ?? 0;

    private int Max(int a, int b) => (a > b) ? a : b;

    private Node RightRotate(Node y)
    {
        Node x = y.Left;
        Node T2 = x.Right;
 
        // Perform rotation
        x.Right = y;
        y.Left = T2;
        
        // Update heights
        y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
        x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
 
        // Return new root
        return x;
    }

    private Node LeftRotate(Node x)
    {
        Node y = x.Right;
        Node T2 = y.Left;
 
        // Perform rotation
        y.Left = x;
        x.Right = T2;
 
        // Update heights
        x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
        y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
 
        // Return new root
        return y;
    }

    private int GetHighDifference(Node? node) => node is null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);

    public void Insert(int value) => Insert(Root, value);

    Node Insert(Node node, int key)
    {
        /* 1. Perform the normal BST rotation */
        if (node == null)
            return (new Node(key));

        if (key < node.Data)
            node.Left = Insert(node.Left, key);
        else if (key > node.Data)
            node.Right = Insert(node.Right, key);
        else // Equal keys not allowed
            return node;

        /* 2. Update height of this ancestor node */
        node.Height = 1 + Max(GetHeight(node.Left),
            GetHeight(node.Right));

        /* 3. Get the balance factor of this ancestor
        node to check whether this node became
        Wunbalanced */
        int balance = GetHighDifference(node);

        // If this node becomes unbalanced, then
        // there are 4 cases Left Left Case
        if (balance > 1 && key < node.Left.Data)
            return RightRotate(node);

        // Right Right Case
        if (balance < -1 && key > node.Right.Data)
            return LeftRotate(node);

        // Left Right Case
        if (balance > 1 && key > node.Left.Data)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Right Left Case
        if (balance < -1 && key < node.Right.Data)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        /* return the (unchanged) node pointer */
        return node;
    }
}

/* Given a non-empty binary search tree, return the
node with minimum key value found in that tree.
Note that the entire tree does not need to be


private Node MinNode(Node node)
{
    Node iterator = node, buff = node;

    while (iterator.Left is not null)
    {
        buff = iterator;
        iterator = iterator.Left;
    }

    return buff;
}

public Node Remove(Node node, int value)
{
    if (value < node.Data)
        node.Left = Remove(node.Left, value);
    else if (value > node.Data)
        node.Right = Remove(node.Right, value);
    else
    {
        //If only one child  
        if (node.Left == null)
            return node.Right;
        if (node.Right == null)
            return node.Left;

        Node temp = MinNode(node.Right);

        node.Data = temp.Data;

        node.Right = Remove(node.Right, temp.Data);
    }

    if (node is null) return node;

    node.Height = Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
    
    int balance = GetHighDifference(node);
    
    switch (balance)
    {
        //Left Left Case
        case > 1 when GetHighDifference(node.Left) >= 0:
            return RightRotate(node);
        //Left Right Case
        case > 1 when GetHighDifference(node.Left) < 0:
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        //Right Right Case
        case < -1 when GetHighDifference(node.Right) <= 0:
            return LeftRotate(node);
        //Right Left Case
        case < -1 when GetHighDifference(node.Right) > 0:
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        default:
            return node;
    }
}
}*/
