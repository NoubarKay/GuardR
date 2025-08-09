# GuardR

**GuardR** is a lightweight, type-safe **fluent guard clause** library for .NET.  
It helps you validate parameters in a clean, expressive way — so your methods fail fast with clear, consistent error messages.

---

## ✨ Features
- **Fluent, readable syntax**: `Guard.For(age).GreaterThan(18).LessThanOrEqualsTo(72)`
- **Type-specific guards** — IntelliSense only shows methods relevant to the parameter type
- **Strongly typed** — no boxing, runtime guessing, or string magic
- Supports **numbers, strings, dates**, and is easily extensible
- Consistent, human-readable exception messages

---
## Why Use GuardR? A Before/After Example

### Before (using `if` statements)

```csharp
public void RegisterUser(string username, int age)
{
    if (string.IsNullOrWhiteSpace(username))
        throw new ArgumentException("username cannot be null or whitespace", nameof(username));

    if (age < 18)
        throw new ArgumentOutOfRangeException(nameof(age), "age must be at least 18");

    if (age > 120)
        throw new ArgumentOutOfRangeException(nameof(age), "age must be less than or equal to 120");

    // ...rest of the method
}
```
### After (using GuardR)
```csharp
public void RegisterUser(string username, int age)
{
    Guard.For(username, nameof(username))
         .NotNullOrWhiteSpace();

    Guard.For(age, nameof(age))
         .Min(18)
         .Max(72);

    // ...rest of the method
}
```
### Benefits:
- Cleaner & more readable: Less boilerplate and repetitive if statements
- Consistent error messages: All guards throw the same exception types with clear, standardized messages
- Fluent chaining: Validate multiple conditions on the same parameter without repetition
- Centralized validation logic: Easier to extend and maintain guards across your codebase
---

## 🚀 Quick Start
```csharp
using GuardR;

// Numeric validation
Guard.For(age)
     .GreaterThan(0)
     .LessThanOrEqualTo(120);

// String validation
Guard.For(name)
     .NotNullOrWhiteSpace()
     .MaxLength(50);

// Date validation
Guard.For(startDate)
     .Before(endDate);
```

## 📜 License
MIT License — do whatever you want, just don’t sue me.
