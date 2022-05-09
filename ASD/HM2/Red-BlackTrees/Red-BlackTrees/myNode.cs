namespace Red_BlackTrees;

public enum Color
{
    Red, 
    Black
}
    
public class myNode
{
    public myNode? Parent { get; set; }
    public myNode? Left { get; set; }
    public myNode? Right { get; set; }
    public Color Color { get; set; }
    public int Data { get; set; }

    public myNode(int data)
    {
        Parent = null;
        Left = null;
        Right = null;
        Data = data;
        Color = Color.Red;
    }
    public myNode(int data, myNode? parent, myNode? left, myNode? right)
    {
        Parent = parent;
        Left = left;
        Right = right;
        Data = data;
        Color = Color.Red;
    }

    public bool IsRelative(myNode node) => Parent == node || node.Parent == this;
}