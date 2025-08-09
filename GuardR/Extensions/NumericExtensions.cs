namespace GuardR.Extensions;

public static class NumericExtensions
{
    public static GuardClause<T> Min<T>(this GuardClause<T> guard, T min) 
        where T : IComparable<T>
    {
        if (guard.Value.CompareTo(min) < 0)
        {
            throw new ArgumentOutOfRangeException(
                guard.ParamName,
                $"{guard.ParamName} must be at least {min}."
            );
        }

        return guard;
    }
    
    public static GuardClause<T> Max<T>(this GuardClause<T> guard, T min) 
        where T : IComparable<T>
    {
        if (guard.Value.CompareTo(min) > 0)
        {
            throw new ArgumentOutOfRangeException(
                guard.ParamName,
                $"{guard.ParamName} must be at most {min}."
            );
        }

        return guard;
    }
}