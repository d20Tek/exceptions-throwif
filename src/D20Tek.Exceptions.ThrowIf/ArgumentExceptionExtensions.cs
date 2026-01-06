using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="ArgumentException"/> to validate arguments.
/// </summary>
public static class ArgumentExceptionExtensions
{
    extension(ArgumentException)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if the specified type is not assignable to the target type.
        /// </summary>
        /// <typeparam name="TBase">The base type or interface to check assignability against.</typeparam>
        /// <param name="type">The type to check for assignability.</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when <paramref name="type"/> is not assignable to <typeparamref name="TBase"/>.</exception>
        /// <example>
        /// <code>
        /// // Validate that FileStream is assignable to Stream
        /// ArgumentException.ThrowIfNotAssignableTo&lt;Stream&gt;(typeof(FileStream));
        /// </code>
        /// </example>
        public static void ThrowIfNotAssignableTo<TBase>(
            Type type,
            [CallerArgumentExpression(nameof(type))] string? paramName = Constants.NoneParam)
        {
            ArgumentNullException.ThrowIfNull(type, paramName);
            if (!typeof(TBase).IsAssignableFrom(type))
            {
                ThrowNotAssignableTo(
                    type.FullName,
                    typeof(TBase).FullName,
                    paramName,
                    Constants.Argument_TypeNotAssignable);
            }
        }

        [DoesNotReturn]
        private static void ThrowNotAssignableTo(
            string? typeName,
            string? assignableTo,
            string? paramName,
            string messageFormat) =>
            throw new ArgumentException(string.Format(messageFormat, paramName, typeName, assignableTo), paramName);
    }
}
