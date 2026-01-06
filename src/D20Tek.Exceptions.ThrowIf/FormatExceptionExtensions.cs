namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="FormatException"/> when values cannot be parsed.
/// </summary>
public static class FormatExceptionExtensions
{
    extension(FormatException)
    {
        /// <summary>
        /// Throws a <see cref="FormatException"/> if the string cannot be parsed to the specified type.
        /// </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <param name="value">The string to parse.</param>
        /// <param name="result">The parsed result if successful.</param>
        /// <param name="paramName">The parameter name.</param>
        /// <exception cref="FormatException">Thrown when parsing fails.</exception>
        public static void ThrowIfInvalidFormat<T>(
            string value,
            out T result,
            [CallerArgumentExpression(nameof(value))] string? paramName = Constants.NoneParam)
            where T : IParsable<T>
        {
            if (!T.TryParse(value, null, out result!))
            {
                throw new FormatException(string.Format(Constants.InvalidFormat, paramName, typeof(T).Name, value));
            }
        }
    }
}