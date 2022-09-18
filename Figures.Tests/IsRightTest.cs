using Xunit;

namespace Figures.Tests;

public class IsRightTest
{
    [Fact]
    public void Test()
    {
        Assert.True(new Triangle(5,4,3).IsRight);
        Assert.True(new Triangle(5,3,4).IsRight);
        Assert.True(new Triangle(4,5,3).IsRight);
        Assert.True(new Triangle(4,3,5).IsRight);
        Assert.True(new Triangle(3,5,4).IsRight);
        Assert.True(new Triangle(3,4,5).IsRight);
        
        Assert.False(new Triangle(2,2,1).IsRight);
        Assert.False(new Triangle(2,1,2).IsRight);
        Assert.False(new Triangle(1,2,2).IsRight);
        Assert.False(new Triangle(1,1,1).IsRight);

    }
}