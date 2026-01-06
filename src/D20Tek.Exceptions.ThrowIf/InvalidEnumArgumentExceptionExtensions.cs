using System.ComponentModel;

namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="InvalidEnumArgumentException"/> to validate enum values.
/// </summary>
public static class InvalidEnumArgumentExceptionExtensions
{
    extension(InvalidEnumArgumentException)
    {
        /// <summary>
        /// Throws an <see cref="InvalidEnumArgumentException"/> if the specified enum value is not defined in the enum type.
        /// </summary>
        /// <typeparam name="TEnum">The enum type to validate against.</typeparam>
        /// <param name="value">The enum value to validate.</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="InvalidEnumArgumentException">Thrown when <paramref name="value"/> is not a defined value in <typeparamref name="TEnum"/>.</exception>
        /// <example>
        /// <code>
        /// public enum Status { Active, Inactive, Pending }
        /// 
        /// var status = Status.Active;
        /// InvalidEnumArgumentException.ThrowIfInvalidEnum(status); // OK
        /// 
        /// var invalid = (Status)99;
        /// InvalidEnumArgumentException.ThrowIfInvalidEnum(invalid); // Throws
        /// </code>
        /// </example>
        public static void ThrowIfInvalidEnum<TEnum>(
            TEnum value, [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
            where TEnum : struct, Enum
        {
            if (Enum.IsDefined(value) is false)
            {
                throw new InvalidEnumArgumentException(
                    string.Format(Constants.InvalidEnumMessage, paramName, typeof(TEnum).Name, value));
            }
        }
    }
}
