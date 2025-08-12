using System.Runtime.CompilerServices;
using GuardR.Extensions;

namespace GuardR;

public readonly struct GuardClause<T>(T value, string paramName)
{
    public T Value { get; } = value;
    public string ParamName { get; } = paramName;
}


public static class Guard
{
    public static NumericGuardClause<T> Numeric<T>(
        T value,
        [CallerArgumentExpression("value")] string paramName = "")
        where T : struct, IComparable<T>
    {
        return new NumericGuardClause<T>(value, paramName ?? nameof(value));
    }
    
    // public static StringGuardClause String(
    //     string value,
    //     [CallerArgumentExpression("value")] string paramName = "")
    // {
    //     return new StringGuardClause(value, paramName ?? nameof(value));
    // }
}