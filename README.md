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

## 🚀 Quick Start
```cs
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

##📜 License
MIT License — do whatever you want, just don’t sue me.
