# Streamline Exception Handling in .NET with D20Tek.Exceptions.ThrowIf

Exception handling is a critical aspect of writing robust .NET applications. While .NET provides excellent built-in exception types, validating input parameters and throwing appropriate exceptions can lead to verbose, repetitive code. Enter **D20Tek.Exceptions.ThrowIf** - a powerful library that simplifies exception throwing with an elegant, fluent API that leverages .NET 10's new Extension Members feature.

## The Problem: Verbose Exception Handling

Consider a typical validation scenario in a .NET method:

```csharp
public void ProcessOrder(Order order, int quantity, string customerId)
{
    if (order == null)
        throw new ArgumentNullException(nameof(order));
    
    if (quantity <= 0)
        throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be positive");
    
    if (string.IsNullOrEmpty(customerId))
        throw new ArgumentNullException(nameof(customerId));
    
    // Actual business logic here...
}
```

This pattern is repeated throughout codebases, leading to boilerplate code that obscures the actual business logic. While .NET introduced `ArgumentNullException.ThrowIfNull` to address some of these concerns, many common validation scenarios still require manual exception throwing.

## The Solution: D20Tek.Exceptions.ThrowIf

D20Tek.Exceptions.ThrowIf extends .NET's exception handling capabilities by adding static extension methods directly to exception types. This creates a seamless, discoverable API that feels native to the framework.

### Key Features

- **Fluent API**: Clean, readable syntax that integrates naturally with existing .NET code
- **Extension Members**: Uses .NET 10's new extension members feature to add static methods to exception types
- **Comprehensive Coverage**: Supports multiple exception types including `ArgumentException`, `ArgumentOutOfRangeException`, `InvalidOperationException`, `FormatException`, and more
- **Type Safety**: Leverages generic constraints and modern C# features for compile-time safety
- **CallerArgumentExpression**: Automatically captures parameter names for better error messages

## Installation

Installing the library is straightforward via NuGet:

```cmd
PM> Install-Package D20Tek.Exceptions.ThrowIf
```

Or via the .NET CLI:

```sh
dotnet add package D20Tek.Exceptions.ThrowIf
```

## Real-World Examples

Let's explore how D20Tek.Exceptions.ThrowIf simplifies common validation scenarios:

### 1. Collection Validation

**Before:**
```csharp
if (items == null)
    throw new ArgumentNullException(nameof(items));
if (!items.Any())
    throw new ArgumentException("Collection cannot be empty", nameof(items));
```

**After:**

```csharp
ArgumentNullException.ThrowIfNullOrEmpty(items);
```

### 2. Range Validation

**Before:**
```csharp
if (temperature < -273.15 || temperature > 5778)
    throw new ArgumentOutOfRangeException(nameof(temperature), 
        $"Temperature must be between -273.15 and 5778");
```

**After:**

```csharp
ArgumentOutOfRangeException.ThrowIfOutOfRange(temperature, -273.15, 5778.0);
```

The library also supports exclusive ranges for scenarios where boundary values aren't allowed:

```csharp
// Value must be strictly between 0 and 100 (excluding 0 and 100)
ArgumentOutOfRangeException.ThrowIfOutOfRangeExclusive(percentage, 0, 100);
```

### 3. Numeric Validation

Validate that numeric values meet specific criteria:

```csharp
// Ensure age is not negative
ArgumentOutOfRangeException.ThrowIfNegative(age);

// Ensure quantity is positive (not zero or negative)
ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
```

### 4. Dictionary Key Validation

**Before:**
```csharp
if (!userCache.ContainsKey(userId))
    throw new KeyNotFoundException($"User with ID '{userId}' not found");
```

**After:**

```csharp
KeyNotFoundException.ThrowIf(userCache, userId);
```

### 5. Default Value Validation

Ensure that value types aren't their default values:

```csharp
Guid orderId = GetOrderId();
ArgumentNullException.ThrowIfNullOrDefault(orderId); // Throws if orderId is Guid.Empty
```

### 6. Format Validation with Parsing

Validate and parse strings in a single operation:

```csharp
string input = "123.45";
FormatException.ThrowIfInvalidFormat<decimal>(input, out var price);
// price now contains 123.45 as a decimal
```

This works with any type implementing `IParsable<T>`, including `int`, `DateTime`, `Guid`, and more.

### 7. Authorization Checks

Validate user permissions and authentication:

```csharp
// Simple permission check
bool hasAccess = user.HasPermission("DeleteResource");
UnauthorizedAccessException.ThrowIfUnauthorized(hasAccess, "critical-resource");

// Claims-based authorization
ClaimsPrincipal currentUser = GetCurrentUser();
UnauthorizedAccessException.ThrowIfUnauthorized(currentUser, "Admin", "admin-panel");
```

### 8. Path Validation

Ensure file paths don't contain invalid characters:

```csharp
string userPath = GetUserInput();
ArgumentException.ThrowIfInvalidPath(userPath);
```

### 9. Custom Exception Scenarios

The library includes a powerful generic `Exception.ThrowIf` method for scenarios not covered by specific extensions:

```csharp
public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message) { }
}

int inventoryCount = GetInventoryCount();
Exception.ThrowIf<BusinessRuleException>(
    inventoryCount < minimumRequired, 
    "Insufficient inventory to fulfill order");
```

This is particularly useful for custom exception types and domain-specific validation rules.

## Advanced Scenarios

### Complex Conditional Logic

The library supports both direct boolean conditions and lambda expressions:

```csharp
// Direct boolean
InvalidOperationException.ThrowIf(system.IsShutdown, "System is shutting down");

// Lambda expression for complex logic
InvalidOperationException.ThrowIf(
    () => system.IsShutdown || system.IsUnderMaintenance,
    "System is unavailable");
```

### Disposal State Validation

Track and validate disposal state of your resources:

```csharp
public class DatabaseConnection : IDisposable
{
    private bool _disposed;

    public void ExecuteQuery(string query)
    {
        InvalidOperationException.ThrowIfDisposed(_disposed);
        // Execute query logic...
    }

    public void Dispose()
    {
        _disposed = true;
    }
}
```

### Type Assignability Checks

Validate that types can be assigned to specific base types or interfaces:

```csharp
Type pluginType = GetPluginType();
ArgumentException.ThrowIfNotAssignableTo<IPlugin>(pluginType);
// Now safe to instantiate pluginType as IPlugin
```

### Enum Validation

Ensure enum values are defined:

```csharp
public enum OrderStatus { Pending, Processing, Shipped, Delivered }

OrderStatus status = (OrderStatus)99; // Invalid cast
InvalidEnumArgumentException.ThrowIfInvalidEnum(status); // Throws
```

## Benefits

### 1. **Improved Readability**
The fluent API makes validation logic immediately clear:
```csharp
ArgumentNullException.ThrowIfNullOrEmpty(users);
ArgumentOutOfRangeException.ThrowIfNegative(quantity);
```

### 2. **Reduced Boilerplate**
Replace 3-5 lines of validation code with a single expressive method call.

### 3. **Automatic Parameter Names**
Using `CallerArgumentExpression`, the library automatically captures parameter names for exception messages, eliminating the need for `nameof()`.

### 4. **Type Safety**
Generic constraints ensure compile-time validation of your validation logic.

### 5. **Consistency**
Establish consistent validation patterns across your codebase.

### 6. **Discoverability**
Because methods are extensions on exception types, they're easily discoverable through IntelliSense when working with specific exception scenarios.

## Real-World Application

Here's a complete example showing how the library streamlines a typical service method:

```csharp
public class OrderService
{
    private readonly Dictionary<string, Order> _orderCache;
    
    public void ProcessOrder(
        string orderId,
        List<OrderItem> items,
        decimal totalAmount,
        ClaimsPrincipal user)
    {
        // Validate all inputs concisely
        ArgumentNullException.ThrowIfNullOrEmpty(orderId);
        ArgumentNullException.ThrowIfNullOrEmpty(items);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(totalAmount);
        UnauthorizedAccessException.ThrowIfUnauthorized(user, "OrderProcessor", "orders");
        
        // Validate order exists
        KeyNotFoundException.ThrowIf(_orderCache, orderId);
        
        // Process order...
    }
}
```

Compare this to the traditional approach requiring 20+ lines of validation code!

## Getting Started

1. **Install the package** via NuGet
2. **Add the using directive**:
```csharp
using D20Tek.Exceptions.ThrowIf;
```
3. **Start using the extensions** - they're available on the exception types themselves

## Best Practices

- **Use at Method Boundaries**: Apply these validations at public API boundaries where untrusted input enters your system
- **Fail Fast**: Validate early and throw exceptions immediately when constraints are violated
- **Meaningful Messages**: The library provides sensible default messages, but custom messages are supported where needed
- **Combine with Guard Clauses**: Use these extensions as part of a comprehensive guard clause strategy

## Conclusion

D20Tek.Exceptions.ThrowIf represents a modern approach to exception handling in .NET. By leveraging .NET 10's extension members feature, it provides a natural, fluent API that reduces boilerplate while improving code clarity. Whether you're building APIs, services, or applications, this library helps you write cleaner, more maintainable validation code.

The library is actively maintained and open to community contributions. If you have suggestions for additional exception extensions or find issues, visit the [GitHub repository](https://github.com/d20Tek/exceptions-throwif) to contribute.

**Try it today** and experience how much cleaner your validation code can be!

---

*D20Tek.Exceptions.ThrowIf is available on NuGet and compatible with .NET 10 and later. Full documentation and samples are available in the [GitHub repository](https://github.com/d20Tek/exceptions-throwif).*
