namespace Red_BlackTrees;

public class IntegralScheme
{
    private RedBlackTree x;
    private RedBlackTree y;

    public IntegralScheme()
    {
        x = new RedBlackTree();
        y = new RedBlackTree();
    }

    public bool AddElement(int x1, int y1, int x2, int y2)
    {
        var a1 = y.Insert(y1);
        var a2 = y.Insert(y2);
    
        var b1 = x.Insert(x1);
        var b2 = x.Insert(x2);

        return a1.IsRelative(a2) || b1.IsRelative(b2);
    }
}