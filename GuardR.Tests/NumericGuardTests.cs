using GuardR.Extensions;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace GuardR.Tests;

public class NumericGuardTests
{
    [Fact]
    public void Min_ShouldNotThrow_WhenValueIsAboveMinimum()
    {
        var age = 20;
        var ex = Record.Exception(() => Guard.For(age).Min(18));
        Assert.That(ex, Is.Null);
    }
    
    
    [Fact]
    public void Min_ShouldThrow_WhenValueIsAboveMinimum()
    {
        var age = 17;
        var ex = Record.Exception(() => Guard.For(age).Min(18));
        Assert.That(ex.Message.Contains("must be at least 18"), Is.True);
    }
    
    
    [Fact]
    public void Max_ShouldNotThrow_WhenValueIsAboveMaximum()
    {
        var age = 17;
        var ex = Record.Exception(() => Guard.For(age).Max(18));
        Assert.That(ex, Is.Null);
    }
    
    
    [Fact]
    public void Max_ShouldThrow_WhenValueIsAboveMaximum()
    {
        var age = 20;
        var ex = Record.Exception(() => Guard.For(age).Max(18));
        Assert.That(ex.Message.Contains("must be at most 18"), Is.True);
    }
}