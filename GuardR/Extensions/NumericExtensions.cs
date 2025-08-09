using System;

namespace GuardR.Extensions;

public interface INumericGuards<T> where T : IComparable<T>
{
    /// <summary>
    /// Ensures that the value encapsulated by this <see cref="GuardClause{T}"/> instance
    /// is greater than or equal to the specified minimum value.
    /// </summary>
    /// <param name="min">The minimum allowable value for the guarded value.</param>
    /// <returns>
    /// Returns the current <see cref="GuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the guarded value is less than the specified <paramref name="min"/>.
    /// The exception message will indicate that the parameter must be at least the specified minimum value.
    /// </exception>
    /// <remarks>
    /// If the guarded value is less than <paramref name="min"/>, it fails validation and an exception is thrown.
    /// Use this method to enforce a lower bound constraint on numeric or comparable values.
    /// </remarks>
    GuardClause<T> Min(T min);
    
    /// <summary>
    /// Ensures that the value encapsulated by this <see cref="GuardClause{T}"/> instance
    /// is less than or equal to the specified maximum value.
    /// </summary>
    /// <param name="max">The maximum allowable value for the guarded value.</param>
    /// <returns>
    /// Returns the current <see cref="GuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the guarded value is greater than the specified <paramref name="max"/>.
    /// The exception message will indicate that the parameter must be at most the specified maximum value.
    /// </exception>
    /// <remarks>
    /// If the guarded value is greater than <paramref name="max"/>, it fails validation and an exception is thrown.
    /// Use this method to enforce a upper bound constraint on numeric or comparable values.
    /// </remarks>
    GuardClause<T> Max(T max);
    GuardClause<T> IsNegative();
    GuardClause<T> IsPositive();
    GuardClause<T> IsZero();
    GuardClause<T> IsLessThan(T value);
    GuardClause<T> IsLessThanOrEqualTo(T value);
    GuardClause<T> IsGreaterThan(T value);
    GuardClause<T> IsGreaterThanOrEqualTo(T value);

    GuardClause<T> IsInRange(T min, T max);
}

public class NumericGuardClause<T> : GuardClause<T>, INumericGuards<T>
    where T : IComparable<T>
{
    public NumericGuardClause(T value, string paramName) : base(value, paramName)
    {
    }

    public GuardClause<T> Min(T min)
    {
        if (Value.CompareTo(min) < 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be at least {min}."
            );
        }
        return this;
    }

    public GuardClause<T> Max(T max)
    {
        if (Value.CompareTo(max) > 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be at most {max}."
            );
        }
        return this;
    }

    public GuardClause<T> IsNegative()
    {
        // Negative means less than zero
        if (Value.CompareTo(default(T)) >= 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be negative."
            );
        }
        return this;
    }

    public GuardClause<T> IsPositive()
    {
        // Positive means greater than zero
        if (Value.CompareTo(default(T)) <= 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be positive."
            );
        }
        return this;
    }

    public GuardClause<T> IsZero()
    {
        var zero = default(T);
        if (Value.CompareTo(zero) != 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be zero."
            );
        }
        return this;
    }

    public GuardClause<T> IsLessThan(T value)
    {
        if (Value.CompareTo(value) >= 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be less than {value}."
            );
        }
        return this;
    }

    public GuardClause<T> IsLessThanOrEqualTo(T value)
    {
        if (Value.CompareTo(value) > 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be less than or equal to {value}."
            );
        }
        return this;
    }

    public GuardClause<T> IsGreaterThan(T value)
    {
        if (Value.CompareTo(value) <= 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be greater than {value}."
            );
        }
        return this;
    }

    public GuardClause<T> IsGreaterThanOrEqualTo(T value)
    {
        if (Value.CompareTo(value) < 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be greater than or equal to {value}."
            );
        }
        return this;
    }

    //inclusive
    public GuardClause<T> IsInRange(T min, T max)
    {
        if (Value.CompareTo(min) < 0 || Value.CompareTo(max) > 0)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} must be between {min} and {max} (inclusive)."
            );
        }
        return this;
    }
}