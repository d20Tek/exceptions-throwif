using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class ArgumentExceptionExt : ArgumentException
{
    public static void ThrowIfNotAssignableTo<TBase>(
        Type type, [CallerArgumentExpression(nameof(type))] string? paramName = Constants.NoneParam)
    {
        ArgumentNullException.ThrowIfNull(type, paramName);
        if (!typeof(TBase).IsAssignableFrom(type))
            ThrowNotAssignableTo(type.FullName, typeof(TBase).FullName, paramName, Constants.Argument_TypeNotAssignable);
    }

    [DoesNotReturn]
    private static void ThrowNotAssignableTo(
        string? typeName, string? assignableTo, string? paramName, string messageFormat) =>
        throw new ArgumentException(string.Format(messageFormat, paramName, typeName, assignableTo), paramName);
}
