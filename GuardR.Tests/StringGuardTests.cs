using Xunit;
using Assert = NUnit.Framework.Assert;

namespace GuardR.Tests;

public class StringGuardTests
{
    [Fact]
    public void IsLessThan_ShouldNotThrow_WhenValueIsLessThan()
    {
        var age = "Test";
        var ex = Record.Exception(() => Guard.String(age).LengthIsLessThan(6));
        Assert.That(ex, Is.Null);
    }
    
    [Fact]
    public void IsLessThan_ShouldThrow_WhenValueIsGreaterThan()
    {
        var age = "Testings";
        var ex = Record.Exception(() => Guard.String(age).LengthIsLessThan(6));
        Assert.That(ex.Message, Does.Contain("length must be less than"));
    }
}