using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="ArgumentOutOfRangeException"/> to validate range constraints.
/// </summary>
public static class ArgumentOutOfRangeExceptionExtensions
{
    extension(ArgumentOutOfRangeException)
    {
        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value is outside the specified inclusive range.
        /// </summary>
        /// <typeparam name="T">The type of value that implements <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="value">The value to validate.</param>
        /// <param name="min">The minimum allowed value (inclusive).</param>
        /// <param name="max">The maximum allowed value (inclusive).</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than <paramref name="min"/> or greater than <paramref name="max"/>,
        /// or when <paramref name="min"/> is greater than <paramref name="max"/>.
        /// </exception>
        /// <example>
        /// <code>
        /// var check = 3.14f;
        /// ArgumentOutOfRangeException.ThrowIfOutOfRange(check, 1.0f, 10.0f);
        /// 
        /// // This will throw because 15 is outside the range [1, 10]
        /// ArgumentOutOfRangeException.ThrowIfOutOfRange(15, 1, 10);
        /// </code>
        /// </example>
        public static void ThrowIfOutOfRange<T>(
            T value, T min, T max, [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
            where T : IComparable<T>
        {
            if (min.CompareTo(max) > 0)
            {
                throw CreateException(min, max, paramName, Constants.ArgumentOutOfRange_MinMax);
            }

            if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
            {
                throw CreateException(value, min, max, paramName, Constants.ArgumentOutOfRange_MustBeInRange);
            }
        }

        /// <summary>
        /// Throws an <see cref="ArgumentOutOfRangeException"/> if the value is outside the specified exclusive range.
        /// The value must be strictly greater than <paramref name="min"/> and strictly less than <paramref name="max"/>.
        /// </summary>
        /// <typeparam name="T">The type of value that implements <see cref="IComparable{T}"/>.</typeparam>
        /// <param name="value">The value to validate.</param>
        /// <param name="min">The minimum boundary (exclusive).</param>
        /// <param name="max">The maximum boundary (exclusive).</param>
        /// <param name="paramName">The name of the parameter being validated.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="value"/> is less than or equal to <paramref name="min"/>, 
        /// or greater than or equal to <paramref name="max"/>,
        /// or when <paramref name="min"/> is greater than <paramref name="max"/>.
        /// </exception>
        /// <example>
        /// <code>
        /// // Value must be in range (1, 10) - excluding 1 and 10
        /// ArgumentOutOfRangeException.ThrowIfOutOfRangeExclusive(5, 1, 10); // OK
        /// 
        /// // This will throw because 10 is not in the exclusive range (1, 10)
        /// ArgumentOutOfRangeException.ThrowIfOutOfRangeExclusive(10, 1, 10);
        /// </code>
        /// </example>
        public static void ThrowIfOutOfRangeExclusive<T>(
            T value, T min, T max, [CallerArgumentExpression(nameof(value))] string paramName = Constants.NoneParam)
            where T : IComparable<T>
        {
            if (min.CompareTo(max) > 0)
            {
                throw CreateException(min, max, paramName, Constants.ArgumentOutOfRange_MinMax);
            }

            if (value.CompareTo(min) <= 0 || value.CompareTo(max) >= 0)
            {
                throw CreateException(value, min, max, paramName, Constants.ArgumentOutOfRange_MustBeInRangeExclusive);
            }
        }

        private static ArgumentOutOfRangeException CreateException<T>(
            T min, T max, string paramName, string messageFormat) =>
            new(paramName, string.Format(messageFormat, min, max));

        private static ArgumentOutOfRangeException CreateException<T>(
            T value, T min, T max, string paramName, string messageFormat) =>
            new(paramName, value, string.Format(messageFormat, value, paramName, min, max));
    }
}
