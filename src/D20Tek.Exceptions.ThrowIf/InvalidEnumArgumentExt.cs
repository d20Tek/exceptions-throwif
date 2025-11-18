using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public class InvalidEnumArgumentExceptionExt : InvalidEnumArgumentException
{
    public static void ThrowIfInvalidEnum<TEnum>(
        TEnum value, [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
        where TEnum : struct, Enum
    {
        if (Enum.IsDefined(value) is false)
            throw new InvalidEnumArgumentException(
                string.Format(Constants.InvalidEnumMessage, paramName, typeof(TEnum).Name, value));
    }
}
