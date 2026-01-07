namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides extension methods for <see cref="InvalidOperationException"/> to validate condition.
/// </summary>
public static class InvalidOperationExceptionExtensions
{
    extension(InvalidOperationException)
    {
        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> if the specified condition is true.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="message">The error message.</param>
        /// <exception cref="InvalidOperationException">Thrown when condition is true.</exception>
        public static void ThrowIf(bool condition, string message)
        {
            if (condition)
            {
                throw new InvalidOperationException(message);
            }
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> if the specified condition is true.
        /// </summary>
        /// <param name="condition">The conditional function to evaluate.</param>
        /// <param name="message">The error message.</param>
        /// <exception cref="InvalidOperationException">Thrown when condition is true.</exception>
        public static void ThrowIf(Func<bool> condition, string message) => ThrowIf(condition(), message);

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> if the object is disposed.
        /// </summary>
        /// <param name="isDisposed">Whether the object is disposed.</param>
        /// <param name="objectName">The name of the disposed object.</param>
        /// <exception cref="InvalidOperationException">Thrown when object is disposed.</exception>
        public static void ThrowIfDisposed(
            bool isDisposed,
            [CallerArgumentExpression(nameof(isDisposed))] string? objectName = Constants.NoneParam)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException(string.Format(Constants.DisposedExceptionMessage, objectName));
            }
        }

        /// <summary>
        /// Throws an <see cref="InvalidOperationException"/> if the object is disposed.
        /// </summary>
        /// <param name="isDisposed">Conditional function to test whether the object is disposed.</param>
        /// <param name="objectName">The name of the disposed object.</param>
        /// <exception cref="InvalidOperationException">Thrown when object is disposed.</exception>
        public static void ThrowIfDisposed(
            Func<bool> isDisposed,
            [CallerArgumentExpression(nameof(isDisposed))] string? objectName = Constants.NoneParam) =>
            ThrowIfDisposed(isDisposed(), objectName);
    }
}