namespace Lab2;

public class AVLTree
{
    public class Node
    {
        public Node(int data)
        {
            Data = data;

            BalanceDifference = 0;
        }

        public Node(int data, Node parent)
        {
            Data = data;
            Parent = parent;
            Parent = parent;
        }
        
        public int Data { get; set; }
        public Node? Parent { get; set; }
        public Node? LeftChild { get; set; } = null;
        public Node? RightChild { get; set; } = null;
        /// <summary>
        /// Balance difference between left and right child
        /// </summary>
        public int BalanceDifference { get; set; } = 0;

    }

    private Node? Root { get; set; }

    public AVLTree()
    {
        Root = null;
    }
        
    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node(value);
            return;
        }

        var currentNode = Root;
        while (currentNode is not null)
        {
            if (currentNode.Data < value)
            {
                if (currentNode.RightChild is null)
                {
                    currentNode.RightChild = new Node(value, currentNode);
                    BalanceInsertion(currentNode, -1);
                    return;
                }
                currentNode = currentNode.RightChild;
            }
            else if (currentNode.Data > value)
            {
                if (currentNode.LeftChild is null)
                {
                    currentNode.LeftChild = new Node(value, currentNode);
                    BalanceInsertion(currentNode, 1);
                    return;
                }
                currentNode = currentNode.LeftChild;
            }
            else return;
        }
    }
    
    private void BalanceInsertion(Node node, int addBalance)
    {
        while (node is not null)
        {
            node.BalanceDifference += addBalance; 

            switch (node.BalanceDifference)
            {
                case 0:
                    return;
                case 2:
                {
                    if (node.LeftChild.BalanceDifference == 1) 
                        RotateLeftLeft(node);
                    else
                        RotateLeftRight(node);
                    return;
                }
                case -2:
                {
                    if (node.RightChild.BalanceDifference == -1)
                        RotateRightRight(node);
                    else
                        RotateRightLeft(node);
                    return;
                }
            }

            if (node.Parent is not null)
            {
                if (node.Parent.LeftChild == node)
                    addBalance = 1;
                else
                    addBalance = -1;
            }
            node = node.Parent;
        }
    }

    private void RotateRightRight(Node node)
    {
        var rightChild = node.RightChild;
        Node rightLeftChild = null;
        var parent = node.Parent;

        if (rightChild is not null)
        {
            rightLeftChild = rightChild.LeftChild;
            rightChild.Parent = parent;
            rightChild.LeftChild = node;
            rightChild.BalanceDifference++;
            node.BalanceDifference = -rightChild.BalanceDifference;
        }

        node.RightChild = rightLeftChild;
        node.Parent = rightChild;

        if (rightLeftChild is not null)
            rightLeftChild.Parent = node;
        
        if (node == Root)
            Root = rightChild;
        else if (parent.RightChild == node)
            parent.RightChild = rightChild;
        else
            parent.LeftChild = rightChild;
    }

    private void RotateLeftLeft(Node node)
    {
        Node leftChild = node.LeftChild;
        Node leftRightChild = null;
        Node parent = node.Parent;

        if (leftChild is not null)
        {
            leftRightChild = leftChild.RightChild;
            leftChild.Parent = parent;
            leftChild.RightChild = node;
            leftChild.BalanceDifference--;
            node.BalanceDifference = -leftChild.BalanceDifference;
        }

        node.Parent = leftChild;
        node.LeftChild = leftRightChild;

        if (leftRightChild is not null)
        {
            leftRightChild.Parent = node;
        }

        if (node == Root)
        {
            Root = leftChild;
        }
        else if (parent.LeftChild == node)
        {
            parent.LeftChild = leftChild;
        }
        else
        {
            parent.RightChild = leftChild;
        }

    }
    
    private void RotateRightLeft(Node node)
    {
        Node rightChild = node.RightChild;
        Node rightLeftChild = null;
        Node rightLeftRightChild = null;

        if (rightChild is not null)
        {
            rightLeftChild = rightChild.LeftChild;
        }
        if (rightLeftChild is not null)
        {
            rightLeftRightChild = rightLeftChild.RightChild;
        }

        node.RightChild = rightLeftChild;

        if (rightLeftChild is not null)
        {
            rightLeftChild.Parent = node;
            rightLeftChild.RightChild = rightChild;
            rightLeftChild.BalanceDifference--;
        }

        if (rightChild is not null)
        {
            rightChild.Parent = rightLeftChild;
            rightChild.LeftChild = rightLeftRightChild;
            rightChild.BalanceDifference--;
        }

        if (rightLeftRightChild is not null)
        {
            rightLeftRightChild.Parent = rightChild;
        }

        RotateRightRight(node);
    }
    
    private void RotateLeftRight(Node node)
    {
        var leftChild = node.LeftChild;
        var leftRightChild = leftChild.RightChild;
        Node? leftRightLeftChild = null;
        if (leftRightChild is not null)
        {
            leftRightLeftChild = leftRightChild.LeftChild;
        }

        node.LeftChild = leftRightChild;

        if (leftRightChild is not null)
        {
            leftRightChild.Parent = node;
            leftRightChild.LeftChild = leftChild;
            leftRightChild.BalanceDifference++;
        }

        if (leftChild is not null)
        {
            leftChild.Parent = leftRightChild;
            leftChild.RightChild = leftRightLeftChild;
            leftChild.BalanceDifference++;
        }

        if (leftRightLeftChild is not null)
        {
            leftRightLeftChild.Parent = leftChild;
        }
        
        RotateLeftLeft(node);
    }
    
    public void Remove(int value)
    {
        Node? current = Root;
        while (current is not null)
        {
            if (current.Data < value)
                current = current.RightChild;
            else if (current.Data > value)
                current = current.LeftChild;
            else //Found the key.
            {
                if (current.LeftChild == null && current.RightChild == null)
                {
                    if (current == Root)
                        Root = null;
                    else if (current.Parent.RightChild == current)
                    {
                        current.Parent.RightChild = null;
                        BalanceRemoving(current.Parent, 1);
                    }
                    else
                    {
                        current.Parent.LeftChild = null;
                        BalanceRemoving(current.Parent, -1);
                    }
                }
                else if (current.LeftChild is not null) //Get the biggest node from the left subtree.
                {
                    var rightMost = current.LeftChild;
                    while (rightMost.RightChild is not null)
                    {
                        rightMost = rightMost.RightChild;
                    }

                    ReplaceNodes(current, rightMost);
                    BalanceRemoving(rightMost.Parent, 1);
                }
                else //Get the smallest node from the right subtree.
                {
                    var leftMost = current.RightChild;
                    while (leftMost.LeftChild is not null)
                    {
                        leftMost = leftMost.LeftChild;
                    }

                    ReplaceNodes(current, leftMost);
                    BalanceRemoving(leftMost.Parent, -1);
                }
                break;
            }
        }
    }
    
    private void ReplaceNodes(Node sourceNode, Node subtreeNode)
    {
        sourceNode.Data = subtreeNode.Data;
        if (subtreeNode.Parent is null) return;
        
        if (subtreeNode.LeftChild is not null)
        {
            subtreeNode.LeftChild.Parent = subtreeNode.Parent;
            
            if (subtreeNode.Parent.LeftChild == subtreeNode)
                subtreeNode.Parent.LeftChild = subtreeNode.LeftChild;
            else
                subtreeNode.Parent.RightChild = subtreeNode.LeftChild;
        }
        else if (subtreeNode.RightChild is not null)
        {
            subtreeNode.RightChild.Parent = subtreeNode.Parent;
            
            if (subtreeNode.Parent.LeftChild == subtreeNode)
                subtreeNode.Parent.LeftChild = subtreeNode.RightChild;
            else
                subtreeNode.Parent.RightChild = subtreeNode.RightChild;
        }
        else
        {
            if (subtreeNode.Parent.LeftChild == subtreeNode)
                subtreeNode.Parent.LeftChild = null;
            else
                subtreeNode.Parent.RightChild = null;
        }
    }
    
    private void BalanceRemoving(Node node, int addBalance)
    {
        while (node is not null)
        {
            node.BalanceDifference += addBalance;
            addBalance = node.BalanceDifference; 

            if (node.BalanceDifference == 2)
            {
                if (node.LeftChild is not null && node.LeftChild.BalanceDifference >= 0)
                {
                    RotateLeftLeft(node);

                    if (node.BalanceDifference == -1)
                        return;
                }
                else
                {
                    RotateLeftRight(node);
                }
            }
            else if (node.BalanceDifference == -2)
            {
                if (node.RightChild is not null && node.RightChild.BalanceDifference <= 0)
                {
                    RotateRightRight(node);

                    if (node.BalanceDifference == 1)
                    {
                        return;
                    }
                }
                else
                {
                    RotateRightLeft(node);
                }
            }
            else if (node.BalanceDifference is not 0)
            {
                return;
            }

            Node? parent = node.Parent;

            if (parent is not null)
            {
                if (parent.LeftChild == node)
                {
                    addBalance = -1;
                }
                else
                {
                    addBalance = 1;
                }
            }
            node = parent;
        }
    }
}