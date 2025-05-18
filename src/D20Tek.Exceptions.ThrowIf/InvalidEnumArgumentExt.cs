using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class InvalidEnumArgumentExceptionExt : InvalidEnumArgumentException
{
    public static void ThrowIfInvalidEnum<TEnum>(
        TEnum value, [CallerArgumentExpression(nameof(value))] string paramName = "none")
        where TEnum : struct, Enum
    {
        if (Enum.IsDefined(value) is false)
            throw new InvalidEnumArgumentException(
                string.Format(InvalidEnumMessage, paramName, typeof(TEnum).Name, value));
    }

    private const string InvalidEnumMessage = "The parameter {0} has an invalid value for enum type {1}: {2}.";
}
