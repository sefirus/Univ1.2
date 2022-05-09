namespace Lab2;

public class RedBlackTree
{
    public enum Color
    {
        Black,
        Red
    }
    public class Node
    {
        public Node? Parent { get; set; }
        public Node? Right { get; set; }
        public Node? Left { get; set; }
        public int Data { get; set; }
        public Color Color { get; set; }

        public Node(int value)
        {
            Parent = null;
            Right = null;
            Left = null;
            Data = value;
            Color = Color.Red;
        }

        public Node(int value, Node parent)
        {
            Parent = Parent;
            Right = null;
            Left = null;
            Data = value;
            Color = Color.Red;
        }
    }
    public Node? Root { get; private set; }
    public RedBlackTree(Node root) => Root = root;


    private void LeftRotate(Node rotate)
    {
        //if(rotate.Parent is null) return;
        var rightSubtree = rotate.Right;
        rotate.Right = rightSubtree.Left;
        if (rightSubtree.Left is not null) 
            rightSubtree.Left.Parent = rotate;
        rightSubtree.Parent = rotate.Parent;
        if (rotate.Parent is null)
        
            Root = rightSubtree;
        else if (rotate == rotate.Parent.Left)
            rotate.Parent.Left = rightSubtree;
        else
            rotate.Parent.Right = rightSubtree;
        rightSubtree.Left = rotate;
        rotate.Parent = rightSubtree;
    }


    private void RightRotate(Node rotate)
    {
        //if(rotate.Parent is null) return;
        var leftSubtree = rotate.Left;
        rotate.Left = leftSubtree.Right;
        if (leftSubtree.Right is not null)
            leftSubtree.Right.Parent = rotate;
        leftSubtree.Parent = rotate.Parent;
        if (rotate.Parent is null)
        
            Root = leftSubtree;
        else if (rotate == rotate.Parent.Left)
            rotate.Parent.Left = leftSubtree;
        else
            rotate.Parent.Right = leftSubtree;
        leftSubtree.Right = rotate;
        rotate.Parent = leftSubtree;
    }

    private void Fix(Node parent)
    {
        while (parent.Parent.Color == Color.Red)
        {
            if (parent.Parent == parent.Parent.Parent.Right)
            {
                var leftAunt = parent.Parent.Parent.Left;
                if (leftAunt is not null && leftAunt.Color == Color.Red)
                {
                    leftAunt.Color = Color.Black;
                    parent.Parent.Color = Color.Black;
                    parent.Parent.Parent.Color = Color.Red;
                    parent = parent.Parent.Parent;
                }
                else
                {
                    if (parent == parent.Parent.Left)
                    {
                        parent = parent.Parent;
                        RightRotate(parent);
                    }

                    parent.Parent.Color = Color.Black;
                    parent.Parent.Parent.Color = Color.Red;
                    LeftRotate(parent.Parent.Parent);
                }
            }
            else
            {
                var rightAunt = parent.Parent.Parent.Right;

                if (rightAunt is not null && rightAunt.Color == Color.Red)
                {
                    rightAunt.Color = Color.Black;
                    parent.Parent.Color = Color.Black;
                    parent.Parent.Parent.Color = Color.Red;
                    parent = parent.Parent.Parent;
                }
                else
                {
                    if (parent == parent.Parent.Right)
                    {
                        parent = parent.Parent;
                        LeftRotate(parent);
                    }

                    parent.Parent.Color = Color.Black;
                    parent.Parent.Parent.Color = Color.Red;
                    RightRotate(parent.Parent.Parent);
                }
            }

            if (parent == Root) break;
        }

        Root.Color = Color.Black;
    }
    
    public Node? Find(int value)
    {
        var iterator = Root;

        while (iterator is not null)
        {
            if (value < iterator.Data)
                iterator = iterator.Left;
            else if (value > iterator.Data)
                iterator = iterator.Right;
            else
            {
                break;
            }
        }

        return iterator;
    }
    public bool IsContain(int value) => Find(value) is not null;

    public Node Insert(int value)
    {
        var newNode = new Node(value);

        Node newNodeParent = null;
        var iterator = Root;

        while (iterator is not null)
        {
            newNodeParent = iterator;
            if (newNode.Data < iterator.Data)
                iterator = iterator.Left;
            else
                iterator = iterator.Right;
        }

        newNode.Parent = newNodeParent;
        if (newNodeParent is null)
            Root = newNode;
        else if (newNode.Data < newNodeParent.Data)
            newNodeParent.Left = newNode;
        else
            newNodeParent.Right = newNode;

        if (newNode.Parent is null)
        {
            newNode.Color = Color.Black;
            return newNode;
        }

        if (newNode.Parent.Parent is null) return newNode;

        Fix(newNode);
        return newNode;
    }
    
    public int MinElement(Node parent)
    {
        Node? buff = null, iterator = parent;
        while (iterator is not null)
        {
            buff = iterator;
            iterator = iterator.Left;
        }

        return buff.Data;
    }
    
    public void Remove(int value)
    {
        if (!IsContain(value)) return;
        RemoveWithParent(Root, value);
    }

    private Node RemoveWithParent(Node parent, int value)
    {
        if (parent is null) return parent;

        if (value < parent.Data)
            parent.Left = RemoveWithParent(parent.Left, value);
        else if (value > parent.Data)
            parent.Right = RemoveWithParent(parent.Right, value);
        else
        {
            // If only one child  
            if (parent.Left == null)
                return parent.Right;
            if (parent.Right == null)
                return parent.Left;

            parent.Data = MinElement(parent.Right);

            parent.Right = RemoveWithParent(parent.Right, parent.Data);
        }
        
        if(parent != Root)Fix(parent);
        return parent;
    }
}