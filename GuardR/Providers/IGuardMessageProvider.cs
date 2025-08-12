namespace GuardR.Providers;

public interface IGuardMessageProvider
{
    string MustBeAtLeast(string paramName, object min);
    string MustBeAtMost(string paramName, object max);
    string MustBeNegative(string paramName);
    string MustBePositive(string paramName);
    string MustBeZero(string paramName);
    string MustBeLessThan(string paramName, object value);
    string MustBeLessThanOrEqualTo(string paramName, object value);
    string MustBeGreaterThan(string paramName, object value);
    string MustBeGreaterThanOrEqualTo(string paramName, object value);
    string MustBeInRange(string paramName, object min, object max);
    
    string MustBeNullOrEmpty(string paramName);
}

public class DefaultGuardMessageProvider : IGuardMessageProvider
{
    public string MustBeAtLeast(string paramName, object min) => $"{paramName} must be at least {min}.";
    public string MustBeAtMost(string paramName, object max) => $"{paramName} must be at most {max}.";
    public string MustBeNegative(string paramName) => $"{paramName} must be negative.";
    public string MustBePositive(string paramName) => $"{paramName} must be positive.";
    public string MustBeZero(string paramName) => $"{paramName} must be zero.";
    public string MustBeLessThan(string paramName, object value) => $"{paramName} must be less than {value}.";
    public string MustBeLessThanOrEqualTo(string paramName, object value) => $"{paramName} must be less than or equal to {value}.";
    public string MustBeGreaterThan(string paramName, object value) => $"{paramName} must be greater than {value}.";
    public string MustBeGreaterThanOrEqualTo(string paramName, object value) => $"{paramName} must be greater than or equal to {value}.";
    public string MustBeInRange(string paramName, object min, object max) => $"{paramName} must be between {min} and {max} (inclusive).";
    
    public string MustBeNullOrEmpty(string paramName) => $"{paramName} must not be null or empty.";

    
}

public static class GuardSettings
{
    public static IGuardMessageProvider MessageProvider { get; set; } = new DefaultGuardMessageProvider();
}