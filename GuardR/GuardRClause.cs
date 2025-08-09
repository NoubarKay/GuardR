using System.Runtime.CompilerServices;
using GuardR.Extensions;

namespace GuardR;

public class GuardClause<T>
{
    protected T Value { get; }
    protected string ParamName { get; }

    protected GuardClause(T value, string paramName)
    {
        Value = value;
        ParamName = paramName;
    }
}


public static class Guard
{
    public static NumericGuardClause<T> Numeric<T>(T value, 
        [CallerArgumentExpression("value")] string paramName = "")
        where T : struct, IComparable<T>
    {
        return new NumericGuardClause<T>(value, paramName ?? nameof(value));
    }
    
    public static StringGuardClause String(string value, 
        [CallerArgumentExpression("value")] string paramName = "")
    {
        return new StringGuardClause(value, paramName ?? nameof(value));
    }
}