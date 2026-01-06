namespace D20Tek.Exceptions.ThrowIf;

/// <summary>
/// Provides generic extension methods for <see cref="Exception"/> to conditionally throw exceptions.
/// </summary>
public static class ExceptionExtensions
{
    extension(Exception)
    {
        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if the specified condition is <c>true</c>.
        /// </summary>
        /// <typeparam name="TException">The type of exception to throw. Must have a constructor that accepts a string message.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="message">The error message for the exception.</param>
        /// <exception cref="MissingMethodException">
        /// Thrown when <typeparamref name="TException"/> does not have a constructor that accepts a string parameter.
        /// </exception>
        /// <example>
        /// <code>
        /// int value = 10;
        /// Exception.ThrowIf&lt;ArgumentException&gt;(value &lt; 0, "Value cannot be negative");
        /// </code>
        /// </example>
        public static void ThrowIf<TException>(bool condition, string message) where TException : Exception
        {
            if (condition)
            {
                var exception = (TException?)Activator.CreateInstance(typeof(TException), message);
                throw exception!;
            }
        }

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if the specified condition is <c>false</c>.
        /// </summary>
        /// <typeparam name="TException">The type of exception to throw. Must have a constructor that accepts a string message.</typeparam>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="message">The error message for the exception.</param>
        /// <exception cref="MissingMethodException">
        /// Thrown when <typeparamref name="TException"/> does not have a constructor that accepts a string parameter.
        /// </exception>
        /// <example>
        /// <code>
        /// bool isValid = ValidateInput();
        /// Exception.ThrowIfNot&lt;InvalidOperationException&gt;(isValid, "Input validation failed");
        /// </code>
        /// </example>
        public static void ThrowIfNot<TException>(bool condition, string message) where TException : Exception =>
            ThrowIf<TException>(!condition, message);


        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if the specified condition function returns <c>true</c>.
        /// </summary>
        /// <typeparam name="TException">The type of exception to throw. Must have a constructor that accepts a string message.</typeparam>
        /// <param name="condition">A function that returns the condition to evaluate.</param>
        /// <param name="message">The error message for the exception.</param>
        /// <exception cref="MissingMethodException">
        /// Thrown when <typeparamref name="TException"/> does not have a constructor that accepts a string parameter.
        /// </exception>
        /// <example>
        /// <code>
        /// int value = 10;
        /// Exception.ThrowIf&lt;ArgumentException&gt;(() => value &lt; 0, "Value cannot be negative");
        /// </code>
        /// </example>
        public static void ThrowIf<TException>(Func<bool> condition, string message) where TException : Exception =>
            ThrowIf<TException>(condition(), message);

        /// <summary>
        /// Throws an exception of type <typeparamref name="TException"/> if the specified condition function returns <c>false</c>.
        /// </summary>
        /// <typeparam name="TException">The type of exception to throw. Must have a constructor that accepts a string message.</typeparam>
        /// <param name="condition">A function that returns the condition to evaluate.</param>
        /// <param name="message">The error message for the exception.</param>
        /// <exception cref="MissingMethodException">
        /// Thrown when <typeparamref name="TException"/> does not have a constructor that accepts a string parameter.
        /// </exception>
        /// <example>
        /// <code>
        /// Exception.ThrowIfNot&lt;InvalidOperationException&gt;(() => IsSystemReady(), "System is not ready");
        /// </code>
        /// </example>
        public static void ThrowIfNot<TException>(Func<bool> condition, string message) where TException : Exception =>
            ThrowIf<TException>(!condition(), message);
    }
}
