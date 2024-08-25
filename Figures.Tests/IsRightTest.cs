using Figures.Base.Triangle;
using Xunit;

namespace Figures.Tests;

public class IsRightTest
{
    [Fact]
    public void Test()
    {
        Assert.True(new DoubleTriangle(5,4,3).IsRectangular);
        Assert.True(new DoubleTriangle(5,3,4).IsRectangular);
        Assert.True(new DoubleTriangle(4,5,3).IsRectangular);
        Assert.True(new DoubleTriangle(4,3,5).IsRectangular);
        Assert.True(new DoubleTriangle(3,5,4).IsRectangular);
        Assert.True(new DoubleTriangle(3,4,5).IsRectangular);
        
        Assert.False(new DoubleTriangle(2,2,1).IsRectangular);
        Assert.False(new DoubleTriangle(2,1,2).IsRectangular);
        Assert.False(new DoubleTriangle(1,2,2).IsRectangular);
        Assert.False(new DoubleTriangle(1,1,1).IsRectangular);
    }
}