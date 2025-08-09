using System.Text.RegularExpressions;

namespace GuardR.Extensions;

public interface IStringGuards
{
    GuardClause<string> NotNullOrEmpty();
    GuardClause<string> NullOrEmpty();
    GuardClause<string> NotNullOrWhiteSpace();
    GuardClause<string> NullOrWhiteSpace();
    
    /// <summary>
    /// Ensures that the length of the string encapsulated by this <see cref="GuardClause{T}"/> instance
    /// is strictly less than the specified maximum length.
    /// </summary>
    /// <param name="length">The exclusive upper bound on the string length.</param>
    /// <returns>
    /// Returns the current <see cref="GuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the length of the guarded string is greater than or equal to the specified <paramref name="length"/>.
    /// The exception message will indicate that the parameter's length must be less than the specified value.
    /// </exception>
    /// <remarks>
    /// Use this method to enforce an upper-bound constraint on the length of a string value.
    /// </remarks>
    /// <example>
    /// <code language="csharp">
    /// // Throws if length is 5 or more
    /// new StringGuardClause("greeting").LengthIsLessThan(5); // Throws
    ///
    /// // Passes because length is 4 which is less than 5
    /// new StringGuardClause("Test").LengthIsLessThan(5); // OK
    /// </code>
    /// </example>
    GuardClause<string> LengthIsLessThan(int length);

    /// <summary>
    /// Ensures that the length of the string encapsulated by this <see cref="GuardClause{T}"/> instance
    /// is less than or equal to the specified maximum length.
    /// </summary>
    /// <param name="length">The inclusive upper bound on the string length.</param>
    /// <returns>
    /// Returns the current <see cref="GuardClause{T}"/> instance to allow for fluent chaining of guard clauses.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the length of the guarded string is greater than the specified <paramref name="length"/>.
    /// The exception message will indicate that the parameter's length must be less than or equal to the specified value.
    /// </exception>
    /// <remarks>
    /// Use this method to enforce an upper-bound constraint, including equality, on the length of a string value.
    /// </remarks>
    GuardClause<string> LengthIsLessThanOrEqualsTo(int length);
    
    GuardClause<string> Matches(string pattern);
}

public class StringGuardClause(string value, string paramName) : GuardClause<string>(value, paramName), IStringGuards
{
    public GuardClause<string> NotNullOrEmpty()
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} should not be null or empty."
            );
        }

        return this;
    }
    
    public GuardClause<string> NullOrEmpty()
    {
        if (!string.IsNullOrEmpty(value))
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} should be null or empty."
            );
        }

        return this;
    }

    public GuardClause<string> NotNullOrWhiteSpace()
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} should not be null or whitespace."
            );
        }

        return this;
    }
    
    public GuardClause<string> NullOrWhiteSpace()
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} should be null or whitespace."
            );
        }

        return this;
    }

    public GuardClause<string> LengthIsLessThan(int length)
    {
        if (Value != null && Value.Length >= length)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} length must be less than {length}."
            );
        }
        return this;
    }
    
    public GuardClause<string> LengthIsLessThanOrEqualsTo(int length)
    {
        if (Value != null && Value.Length > length)
        {
            throw new ArgumentOutOfRangeException(
                ParamName,
                $"{ParamName} length must be less than or equal to {length}."
            );
        }
        return this;
    }

    public GuardClause<string> Matches(string pattern)
    {
        if (Value == null || !Regex.IsMatch(Value, pattern))
        {
            throw new ArgumentException(
                $"{ParamName} must match the pattern '{pattern}'.",
                ParamName
            );
        }
        return this;
    }
}
