using GuardR.Extensions;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace GuardR.Tests;

public class NumericGuardTests
{
    [Fact]
    public void Min_ShouldNotThrow_WhenValueIsEqualToMinimum()
    {
        var age = 18;
        var ex = Record.Exception(() => Guard.Numeric(age).Min(18));
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void Min_ShouldNotThrow_WhenValueIsAboveMinimum()
    {
        var age = 20;
        var ex = Record.Exception(() => Guard.Numeric(age).Min(18));
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void Min_ShouldThrow_WhenValueIsBelowMinimum()
    {
        var age = 17;
        var ex = Record.Exception(() => Guard.Numeric(age).Min(18));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be at least 18"));
    }

    [Fact]
    public void Max_ShouldNotThrow_WhenValueIsEqualToMaximum()
    {
        var age = 18;
        var ex = Record.Exception(() => Guard.Numeric(age).Max(18));
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void Max_ShouldNotThrow_WhenValueIsBelowMaximum()
    {
        var age = 17;
        var ex = Record.Exception(() => Guard.Numeric(age).Max(18));
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void Max_ShouldThrow_WhenValueIsAboveMaximum()
    {
        var age = 20;
        var ex = Record.Exception(() => Guard.Numeric(age).Max(18));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be at most 18"));
    }

    [Fact]
    public void IsNegative_ShouldNotThrow_WhenValueIsNegative()
    {
        var age = -1;
        var ex = Record.Exception(() => Guard.Numeric(age).IsNegative());
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void IsNegative_ShouldThrow_WhenValueIsZero()
    {
        var age = 0;
        var ex = Record.Exception(() => Guard.Numeric(age).IsNegative());
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be negative"));
    }

    [Fact]
    public void IsNegative_ShouldThrow_WhenValueIsPositive()
    {
        var age = 1;
        var ex = Record.Exception(() => Guard.Numeric(age).IsNegative());
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be negative"));
    }

    [Fact]
    public void IsPositive_ShouldNotThrow_WhenValueIsPositive()
    {
        var age = 1;
        var ex = Record.Exception(() => Guard.Numeric(age).IsPositive());
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void IsPositive_ShouldThrow_WhenValueIsZero()
    {
        var age = 0;
        var ex = Record.Exception(() => Guard.Numeric(age).IsPositive());
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be positive"));
    }

    [Fact]
    public void IsPositive_ShouldThrow_WhenValueIsNegative()
    {
        var age = -1;
        var ex = Record.Exception(() => Guard.Numeric(age).IsPositive());
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be positive"));
    }

    [Fact]
    public void IsLessThan_ShouldNotThrow_WhenValueIsLessThan()
    {
        var age = 1;
        var ex = Record.Exception(() => Guard.Numeric(age).IsLessThan(20));
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void IsLessThan_ShouldThrow_WhenValueIsEqualTo()
    {
        var age = 20;
        var ex = Record.Exception(() => Guard.Numeric(age).IsLessThan(20));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be less than"));
    }

    [Fact]
    public void IsLessThan_ShouldThrow_WhenValueIsGreaterThan()
    {
        var age = 21;
        var ex = Record.Exception(() => Guard.Numeric(age).IsLessThan(20));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be less than"));
    }

    [Fact]
    public void IsLessThanOrEqualTo_ShouldNotThrow_WhenValueIsLessThan()
    {
        var age = 19;
        var ex = Record.Exception(() => Guard.Numeric(age).IsLessThanOrEqualTo(20));
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void IsLessThanOrEqualTo_ShouldNotThrow_WhenValueIsEqualTo()
    {
        var age = 20;
        var ex = Record.Exception(() => Guard.Numeric(age).IsLessThanOrEqualTo(20));
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void IsLessThanOrEqualTo_ShouldThrow_WhenValueIsGreaterThan()
    {
        var age = 21;
        var ex = Record.Exception(() => Guard.Numeric(age).IsLessThanOrEqualTo(20));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be less than or equal to"));
    }
    
    [Fact]
    public void IsGreaterThan_ShouldNotThrow_WhenValueIsGreaterThan()
    {
        var age = 21;
        var ex = Record.Exception(() => Guard.Numeric(age).IsGreaterThan(20));
        Assert.That(ex, Is.Null);
    }

    [Fact]
    public void IsGreaterThan_ShouldThrow_WhenValueIsEqualTo()
    {
        var age = 20;
        var ex = Record.Exception(() => Guard.Numeric(age).IsGreaterThan(20));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be greater than"));
    }

    [Fact]
    public void IsGreaterThan_ShouldThrow_WhenValueIsLessThan()
    {
        var age = 18;
        var ex = Record.Exception(() => Guard.Numeric(age).IsGreaterThan(21));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain("must be greater than"));
    }
}
