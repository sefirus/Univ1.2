namespace BinTree;

public class Tree
{
    public Node Root { get; set; }

    public Node? Find(int value)
    {
        var iterator = Root;

        while (iterator is not null)
        {
            if (value < iterator.Data)
                iterator = iterator.LeftNode;
            else if (value > iterator.Data)
                iterator = iterator.RightNode;
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
        var newNode = new Node
        {
            Data = value
        };
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
            iterator = value < iterator.Data ? iterator.LeftNode : iterator.RightNode;
        }

        if (value < buff.Data)
            buff.LeftNode = newNode;
        else
            buff.RightNode = newNode;
        return true;
    }

    public int MinElement() => MinElement(Root);

    public int MinElement(Node parent)
    {
        Node? buff = null, iterator = parent;
        while (iterator is not null)
        {
            buff = iterator;
            iterator = iterator.LeftNode;
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
            iterator = iterator.RightNode;
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
            parent.LeftNode = RemoveWithParent(parent.LeftNode, value);
        else if (value > parent.Data)
            parent.RightNode = RemoveWithParent(parent.RightNode, value);
        else
        {
            // If only one child  
            if (parent.LeftNode == null)
                return parent.RightNode;
            if (parent.RightNode == null)
                return parent.LeftNode;

            parent.Data = MinElement(parent.RightNode);

            parent.RightNode = RemoveWithParent(parent.RightNode, parent.Data);
        }

        return parent;
    }
}