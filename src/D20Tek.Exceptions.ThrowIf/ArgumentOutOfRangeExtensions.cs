using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public static class ArgumentOutOfRangeExtensions
{
    public static void ThrowIfOutOfRange<T>(
        this ArgumentOutOfRangeException ex, T value, T min, T max, [CallerArgumentExpression(nameof(value))] string paramName = "none")
        where T : IComparable<T>
    {
        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            ThrowOutOfRange(value, min, max, paramName ?? "value", ArgumentOutOfRange_MustBeInRange);
    }

    public static void ThrowIfOutOfRangeExclusive<T>(
        this ArgumentOutOfRangeException ex, T value, T min, T max, [CallerArgumentExpression(nameof(value))] string paramName = "none")
        where T : IComparable<T>
    {
        if (value.CompareTo(min) <= 0 || value.CompareTo(max) >= 0)
            ThrowOutOfRange(value, min, max, paramName, ArgumentOutOfRange_MustBeInRangeExclusive);
    }

    public const string ArgumentOutOfRange_MustBeInRange =
        "The value '{0}' for parameter '{1}' must be in the range [{2}, {3}].";
    public const string ArgumentOutOfRange_MustBeInRangeExclusive =
        "The value '{0}' for parameter '{1}' must be in the range ({2}, {3}) - excluding the min max.";

    [DoesNotReturn]
    private static void ThrowOutOfRange(object? value, object? min, object? max, string paramName, string messageFormat) =>
        throw new ArgumentOutOfRangeException(
            paramName,
            value,
            string.Format(messageFormat, value ?? "null", paramName, min ?? "null", max ?? "null"));
}
