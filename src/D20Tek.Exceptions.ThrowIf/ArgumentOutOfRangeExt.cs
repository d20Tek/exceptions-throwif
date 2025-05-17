using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class ArgumentOutOfRangeExceptionExt : ArgumentOutOfRangeException
{
    public static void ThrowIfOutOfRange<T>(
        T value, T min, T max, [CallerArgumentExpression(nameof(value))] string paramName = "none")
        where T : IComparable<T>
    {
        if (min.CompareTo(max) > 0) 
            throw new ArgumentOutOfRangeException(paramName, string.Format(ArgumentOutOfRange_MinMax, min, max));

        if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            ThrowOutOfRange(value, min, max, paramName, ArgumentOutOfRange_MustBeInRange);
    }

    public static void ThrowIfOutOfRangeExclusive<T>(
        T value, T min, T max, [CallerArgumentExpression(nameof(value))] string paramName = "none")
        where T : IComparable<T>
    {
        if (min.CompareTo(max) > 0)
            throw new ArgumentOutOfRangeException(paramName, string.Format(ArgumentOutOfRange_MinMax, min, max));

        if (value.CompareTo(min) <= 0 || value.CompareTo(max) >= 0)
            ThrowOutOfRange(value, min, max, paramName, ArgumentOutOfRange_MustBeInRangeExclusive);
    }

    public const string ArgumentOutOfRange_MinMax =
        "The value for min '{0}' must be less than or equal to max '{1}'.";
    public const string ArgumentOutOfRange_MustBeInRange =
        "The value '{0}' for parameter '{1}' must be in the range [{2}, {3}].";
    public const string ArgumentOutOfRange_MustBeInRangeExclusive =
        "The value '{0}' for parameter '{1}' must be in the range ({2}, {3}) - excluding the min max.";

    [DoesNotReturn]
    private static void ThrowOutOfRange<T>(T value , T min, T max, string paramName, string messageFormat) =>
        throw new ArgumentOutOfRangeException(
            paramName,
            value,
            string.Format(messageFormat, value, paramName, min, max));
}
