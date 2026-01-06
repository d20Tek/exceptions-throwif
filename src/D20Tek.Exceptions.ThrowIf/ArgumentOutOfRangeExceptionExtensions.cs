using System.Runtime.CompilerServices;

namespace D20Tek.Exceptions.ThrowIf;

public static class ArgumentOutOfRangeExceptionExtensions
{
    extension(ArgumentOutOfRangeException)
    {
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
