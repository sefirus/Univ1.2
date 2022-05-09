namespace Lab2;

public class SearchTree
{
    public class Node
    {
        public Node? Parent { get; set; }
        public Node? Right { get; set; }
        public Node? Left { get; set; }
        public int Data { get; set; }

        public Node(int value)
        {
            Parent = null;
            Right = null;
            Left = null;
            Data = value;
        }

        public Node(int value, Node parent)
        {
            Parent = Parent;
            Right = null;
            Left = null;
            Data = value;
        }
    }
    public Node Root { get; set; }

    
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
                return iterator;
            }
        }

        return null;
    }

    public bool IsContain(int value) => Find(value) is not null;

    public bool Add(int value)
    {
        var newNode = new Node(value);
        if (Root is null)
        {
            Root = newNode;
            return true;
        }

        if (IsContain(value)) return false;

        Node? buff = null, iterator = Root;
        while (iterator is not null)
        {
            buff = iterator;
            iterator = value < iterator.Data ? iterator.Left : iterator.Right;
        }

        if (value < buff?.Data)
            buff.Left = newNode;
        else
            buff.Right = newNode;
        return true;
    }

    public int MinElement() => MinElement(Root);

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

    public int MaxElement() => MaxElement(Root);

    public int MaxElement(Node parent)
    {
        Node? buff = null, iterator = parent;
        while (iterator is not null)
        {
            buff = iterator;
            iterator = iterator.Right;
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

        return parent;
    }
}