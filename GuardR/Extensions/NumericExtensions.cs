using System;
using System.Runtime.CompilerServices;
using GuardR.Providers;

namespace GuardR.Extensions;

/// <summary>
/// Provides guard clause validations for numeric types.
/// </summary>
/// <typeparam name="T">A numeric or comparable value type.</typeparam>
public readonly struct NumericGuardClause<T>(T value, string paramName)
    where T : struct, IComparable<T>
{
    private T Value { get; } = value;
    private string ParamName { get; } = paramName;

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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> Min(T min)
    {
        if (Value.CompareTo(min) < 0)
        {
            var message = GuardSettings.MessageProvider.MustBeAtLeast(ParamName, min);
            throw new ArgumentOutOfRangeException(ParamName, message);
        }
        return this;
    }

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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> Max(T max)
    {
        if (Value.CompareTo(max) > 0)
        {
            var message = GuardSettings.MessageProvider.MustBeAtMost(ParamName, max);
            throw new ArgumentOutOfRangeException(ParamName, message);
        }
        return this;
    }
    
    /// <summary>
    /// Ensures that the value encapsulated by this <see cref="NumericGuardClause{T}"/> instance
    /// is less than zero (i.e., negative).
    /// </summary>
    /// <returns>
    /// Returns the current <see cref="NumericGuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the guarded value is zero or greater.
    /// The exception message will indicate that the parameter must be negative.
    /// </exception>
    /// <remarks>
    /// Use this method to enforce that the numeric value is strictly negative.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> IsNegative()
    {
        if (Value.CompareTo(default) >= 0)
        {
            var message = GuardSettings.MessageProvider.MustBeNegative(ParamName);
            throw new ArgumentOutOfRangeException(ParamName, message);
        }
        return this;
    }

    /// <summary>
    /// Ensures that the value encapsulated by this <see cref="NumericGuardClause{T}"/> instance
    /// is greater than zero (i.e., positive).
    /// </summary>
    /// <returns>
    /// Returns the current <see cref="NumericGuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the guarded value is zero or less.
    /// The exception message will indicate that the parameter must be positive.
    /// </exception>
    /// <remarks>
    /// Use this method to enforce that the numeric value is strictly positive.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> IsPositive()
    {
        if (Value.CompareTo(default) <= 0)
        {
            var message = GuardSettings.MessageProvider.MustBePositive(ParamName);
            throw new ArgumentOutOfRangeException(ParamName, message);
        }
        return this;
    }

    /// <summary>
    /// Ensures that the value encapsulated by this <see cref="NumericGuardClause{T}"/> instance
    /// is equal to zero.
    /// </summary>
    /// <returns>
    /// Returns the current <see cref="NumericGuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the guarded value is not zero.
    /// The exception message will indicate that the parameter must be zero.
    /// </exception>
    /// <remarks>
    /// Use this method to enforce that the numeric value is exactly zero.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> IsZero()
    {
        if (Value.CompareTo(default) != 0)
        {
            var message = GuardSettings.MessageProvider.MustBeZero(ParamName);   
            throw new ArgumentOutOfRangeException(ParamName, message);
        }
        return this;
    }

    /// <summary>
    /// Ensures that the value encapsulated by this <see cref="NumericGuardClause{T}"/> instance
    /// is less than the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to compare against.</param>
    /// <returns>
    /// Returns the current <see cref="NumericGuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the guarded value is greater than or equal to <paramref name="value"/>.
    /// The exception message will indicate that the parameter must be less than the specified value.
    /// </exception>
    /// <remarks>
    /// Use this method to enforce an upper bound (exclusive) constraint on the numeric value.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> IsLessThan(T value)
    {
        if (Value.CompareTo(value) >= 0)
        {
            var message =  GuardSettings.MessageProvider.MustBeLessThan(ParamName, value);   
            throw new ArgumentOutOfRangeException(ParamName, message);
        }
        return this;
    }

    /// <summary>
    /// Ensures that the value encapsulated by this <see cref="NumericGuardClause{T}"/> instance
    /// is less than or equal to the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to compare against.</param>
    /// <returns>
    /// Returns the current <see cref="NumericGuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the guarded value is greater than <paramref name="value"/>.
    /// The exception message will indicate that the parameter must be less than or equal to the specified value.
    /// </exception>
    /// <remarks>
    /// Use this method to enforce an upper bound (inclusive) constraint on the numeric value.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> IsLessThanOrEqualTo(T value)
    {
        if (Value.CompareTo(value) > 0)
        {
            var message =  GuardSettings.MessageProvider.MustBeLessThanOrEqualTo(ParamName, value);   
            throw new ArgumentOutOfRangeException(ParamName, message);
        }
        return this;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> IsGreaterThan(T value)
    {
        if (Value.CompareTo(value) <= 0)
        {
            var message = GuardSettings.MessageProvider.MustBeGreaterThan(ParamName, value);   
            throw new ArgumentOutOfRangeException(ParamName, message);
        }
        return this;
    }

    /// <summary>
    /// Ensures that the value encapsulated by this <see cref="NumericGuardClause{T}"/> instance
    /// is greater than the specified <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to compare against.</param>
    /// <returns>
    /// Returns the current <see cref="NumericGuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the guarded value is less than or equal to <paramref name="value"/>.
    /// The exception message will indicate that the parameter must be greater than the specified value.
    /// </exception>
    /// <remarks>
    /// Use this method to enforce a lower bound (exclusive) constraint on the numeric value.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> IsGreaterThanOrEqualTo(T value)
    {
        if (Value.CompareTo(value) < 0)
            throw new ArgumentOutOfRangeException(ParamName, $"{ParamName} must be greater than or equal to {value}.");
        return this;
    }

    /// <summary>
    /// Ensures that the value encapsulated by this <see cref="NumericGuardClause{T}"/> instance
    /// is within the specified range, inclusive of <paramref name="min"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="min">The inclusive minimum allowable value.</param>
    /// <param name="max">The inclusive maximum allowable value.</param>
    /// <returns>
    /// Returns the current <see cref="NumericGuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the guarded value is less than <paramref name="min"/> or greater than <paramref name="max"/>.
    /// The exception message will indicate that the parameter must be within the specified range.
    /// </exception>
    /// <remarks>
    /// Use this method to enforce that the numeric value falls within a specific inclusive range.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public NumericGuardClause<T> IsInRange(T min, T max)
    {
        if (Value.CompareTo(min) < 0 || Value.CompareTo(max) > 0)
            throw new ArgumentOutOfRangeException(ParamName, $"{ParamName} must be between {min} and {max} (inclusive).");
        return this;
    }
}
