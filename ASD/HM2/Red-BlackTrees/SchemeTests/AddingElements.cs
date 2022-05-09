using Red_BlackTrees;
using Xunit;

namespace SchemeTests;

public class UnitTest1
{
    [Fact]
    public void Intersecting2()
    {
        var s = new IntegralScheme();
        
        s.AddElement(1, 1, 4, 3);
        
        Assert.False(s.AddElement(3, 2, 5, 4));
    }
    
    [Fact]
    public void Intersecting3()
    {
        var s = new IntegralScheme();
        
        s.AddElement(1, 1, 4, 3);
        s.AddElement(6, 5, 8, 7);
        
        Assert.False(s.AddElement(3, 2, 5, 4));
    }
    
    [Fact]
    public void Intersecting4()
    {
        var s = new IntegralScheme();
        
        s.AddElement(1, 1, 4, 3);
        
         Assert.False(s.AddElement(2, 1, 4, 3));
    }
    
    [Fact]
    public void NotInter()
    {
        var s = new IntegralScheme();
        
        s.AddElement(1, 1, 4, 3);
        
        Assert.True(s.AddElement(1, 4, 4, 6));
    }
    
    [Fact]
    public void TouchCorner()
    {
        var s = new IntegralScheme();
        
        s.AddElement(1, 1, 4, 3);
        
        Assert.True(s.AddElement(4, 3, 5, 4));
    }
    
    [Fact]
    public void TouchVertical()
    {
        var s = new IntegralScheme();
        
        s.AddElement(1, 1, 4, 3);
        
        Assert.True(s.AddElement(1, 3, 5, 4));
    }
    
    [Fact]
    public void TouchHorizontal()
    {
        var s = new IntegralScheme();
        
        s.AddElement(1, 1, 4, 3);
        
        Assert.True(s.AddElement(4, 1, 5, 4));
    }
    
    [Fact]
    public void NotInter3()
    {
        var s = new IntegralScheme();

        s.AddElement(2, 5, 3, 6);
        s.AddElement(2, 2, 3, 3);
        s.AddElement(6, 6, 7, 7);
        s.AddElement(6, 2, 7, 3);
        
        
        Assert.True(s.AddElement(4, 4, 5, 5));
    }
    
    [Fact]
    public void NotInter4()
    {
        var s = new IntegralScheme();
        
        s.AddElement(-5, -2, 0, 2);
        s.AddElement(5, 2, 8, 6);

        Assert.True(s.AddElement(1, 1, 4, 3));
    }
    
    [Fact]
    public void NewSquareOverMany()
    {
        var s = new IntegralScheme();
        
        s.AddElement(1, 1, 2, 2);
        s.AddElement(2, 2, 3, 3);
        s.AddElement(4, 4, 5, 5);
        s.AddElement(6, 6, 7, 7);
        
        Assert.False(s.AddElement(0, 0, 9, 9));
    }
}