using System.Runtime.CompilerServices;

namespace GuardR;

public class GuardClause<T>
{
    public T Value { get; }
    public string ParamName { get; }

    public GuardClause(T value, string paramName)
    {
        Value = value;
        ParamName = paramName;
    }
}


public static class Guard
{
    public static GuardClause<T> For<T>(
        T value,
        [CallerArgumentExpression("value")] string paramName = ""
    )
    {
        return new GuardClause<T>(value, paramName);
    }
}